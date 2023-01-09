using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Data.SqlClient;

public class GameManager : MonoBehaviour {

	//public AudioSource gameOver;

	//public Transform musicManagerPrefab;

	//public Text hpText;
	//public Text scoreText;
	public string userName;
	public static int currentScore = 0;
	public static int lifes = 3;
	public static int currentLevel = 1;
	public static bool endGame = false;
	//static
	public static int finalScore = 0;
	public static int killedEnemys = 0;
	public static int badPickups = 0;
	private string connectionString;
	SqlConnection connection;
	public int testScore;

	public int testLifes;
	public int testCurrentLevel;
	//public int testFinalScore;
	public int testKilledEnemys;
	public int testBadPickups;

	public GameObject player;
	public Skin skin;
	SqlCommand cmd;
	SqlDataReader reader;

	void Start() {

		Renderer renderer = player.GetComponent<Renderer>();
		renderer.material = skin.material;

		Time.timeScale = 1f;

		lifes = 3;
		endGame = false;

		currentLevel = Application.loadedLevel;

		if (!GameObject.FindGameObjectWithTag ("Music Manager")) {
			//Object musicManager = Instantiate(musicManagerPrefab, musicManagerPrefab.position, musicManagerPrefab.rotation);
			//musicManager.name = musicManagerPrefab.name;
			//DontDestroyOnLoad(musicManager);
		}
		
	}



	// Update is called once per frame
	void Update () {

		testScore = currentScore;
		testLifes = lifes;
		testCurrentLevel = currentLevel;
		//testFinalScore = Level2Controller.level2Point + Level1Controller.level1Point;
		testKilledEnemys = killedEnemys;
		testBadPickups = badPickups;
		//hpText.text = lifes.ToString();
		//scoreText.text = currentScore.ToString();
	}

	// We created this helper function so that it can be called by the PlayerHealth script.
	//  mac du no hoat dong tot bang cach dung coroutine truc tiep tu script ngoai
	public void LoadNextLevel(int level, float delay) {
		
		StartCoroutine(CoLoadNextLevel(level,delay));
	}
	
	public IEnumerator CoLoadNextLevel(int level, float delay) {

		finalScore = currentScore;

		// yield return new WaitForSeconds(gameOver.clip.length+0.5f);
		yield return new WaitForSeconds(delay);

		currentScore = 0;
		lifes = 3;

		if (currentLevel < Application.levelCount - 1)
			Application.LoadLevel ("Level_" + currentLevel);    // This will load a particular level
		else
			Application.LoadLevel(Application.loadedLevel + 1); // This loads the next level according to the order in the Build Settings
	}
	public void TryAgainButton()
	{
		//LoadNextLevel(currentLevel, gameOver.clip.length + 0.5f);
		Application.LoadLevel("Level_1");
		Time.timeScale = 1f;
	}

	public void BackButton()
	{
		//LoadNextLevel(currentLevel, gameOver.clip.length + 0.5f);
		Application.LoadLevel("Summary");
		Time.timeScale = 1f;
	}
	public void SummaryBackButton()
    {

		Application.LoadLevel("Menu");
		Time.timeScale = 1f;
	}
}
