using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public GameObject badPickUpEffect;
	public Text gameoverText;
	public GameObject gameoverPanel;

	public GameManager gameManager;

	//void Start() {

	//	gameoverText.text = "";
	//}

	// Update is called once per frame
	void Update () {

		if ((GameManager.lifes == 0) && (!GameManager.endGame)) {
			gameoverText.text = "GAME OVER";
			//gameManager.gameOver.Play();
			GameManager.endGame = true;
			gameoverPanel.SetActive(true);
			Time.timeScale = 0f;
			//gameManager.LoadNextLevel(GameManager.currentLevel,gameManager.gameOver.clip.length+0.5f);

			// StartCoroutine(gameManager.CoResetGame()) // Esto tambien funciona...
		}
	}

	void OnTriggerEnter(Collider info) {
		
		if (info.gameObject.CompareTag ("Bad Pick Up")) {

			GameObject effect = (GameObject) Instantiate (badPickUpEffect,info.transform.position,info.transform.rotation);
			Destroy(effect,2);
			GameManager.lifes -= 1;
			GameManager.badPickups += 1;
			info.gameObject.SetActive (false);
		}
	}
}
