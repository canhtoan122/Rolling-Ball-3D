using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	
	public AudioClip wallHit;
	public AudioClip jumpWallHit;
	public AudioClip fallWallHit;

	public GameObject pickUpEffect;

	public GameManager gameManager;

	public Text countText;
	public Text winText;

	public int pickupMax = 12;

	private Rigidbody rb;
	private bool isFalling;
	private float distToGround;

	public Level1Controller level1;
	public Level2Controller level2;

	void Start() {

		rb = GetComponent<Rigidbody> ();
		speed = 10.0f;
		//SetCountText ();
		winText.text = "";
		jumpHeight = 8;
		isFalling = false;
		distToGround = GetComponent<Collider>().bounds.extents.y;
	}

	void FixedUpdate() {

		// Note: When applying movement calculations inside FixedUpdate, you do not need to multiply your values by
		// Time.deltaTime. This is because FixedUpdate is called on a reliable timer, independent of the frame rate

		float moveHorizontal = Input.GetAxis ("Horizontal");// left and right
		float moveVertical = Input.GetAxis ("Vertical");// up and down

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);


		rb.AddForce (movement * speed);

		// We make the ball can jump
		if (Input.GetKeyDown (KeyCode.Space) && (!GameManager.endGame)) {
			Debug.Log ("Saltaaaa");
			if (!isFalling)
			{
				rb.velocity = new Vector3(0, jumpHeight, 0);
				GetComponent<AudioSource>().clip = jumpWallHit;
				GetComponent<AudioSource>().Play();
				StartCoroutine(DelayFall());
			}
		}

		// Just for testing.....
		// 
		//		if (IsGrounded ())
		//			Debug.Log ("Toca el piso");
		//		else
		//			Debug.Log ("NO toca el piso");
	}

	void OnTriggerEnter(Collider info) {
		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		if (info.gameObject.CompareTag ("Pick Up")) {

			GameObject effect = (GameObject) Instantiate (pickUpEffect,info.transform.position,info.transform.rotation);
			Destroy(effect,3);
			info.gameObject.SetActive (false); // Or Destroy(info.gameObject);
			GameManager.currentScore += 1;
			//SetCountText();
			if(sceneName == "Level_1")
            {
				Level1Controller.level1Point += 1;
            }
			if (sceneName == "Level_2")
			{
				Level2Controller.level2Point += 1;
			}
		}
		if(info.tag == "web")
        {
			Destroy(gameObject);
			Application.LoadLevel("Summary");
        }
	}

	//void SetCountText() {

	//	countText.text = "Count: " + GameManager.currentScore.ToString ();
	//	if ((GameManager.currentScore >= pickupMax) && (!GameManager.endGame)) {
	//		winText.text = "You Win!";
	//		GameManager.endGame = true;
	//		GameManager.currentLevel += 1;
	//		gameManager.LoadNextLevel(GameManager.currentLevel,3.0f);
	//	}
	//}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.CompareTag ("Wall")) {
			GetComponent<AudioSource>().clip = wallHit;
			GetComponent<AudioSource>().Play ();
		}
	}

	// It is executed when the object is colliding with another
	void OnCollisionStay() {

		if (isFalling) {
			GetComponent<AudioSource>().pitch = Random.Range(0.5f,1.5f);
			GetComponent<AudioSource>().clip = fallWallHit;
			GetComponent<AudioSource>().Play();
			isFalling = false;
		}
	}
	// check variable is falling
	IEnumerator DelayFall() {

		yield return new WaitForSeconds(0.0f);
		isFalling = true;
	}

	// Just as a test

	bool IsGrounded() {

		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
}