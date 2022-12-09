using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//public AudioSource gameOver;

	//public Transform musicManagerPrefab;

	//public Text hpText;
	//public Text scoreText;

	public static int currentScore = 0;
	public static int lifes = 3;
	public static int currentLevel = 1;
	public static bool endGame = false;

	public static int finalScore = 0;
	public static int killedEnemys = 0;
	public static int badPickups = 0;

	public int testScore;
	public int testLifes;
	public int testCurrentLevel;
	public int testFinalScore;
	public int testKilledEnemys;
	public int testBadPickups;

	void Start() {

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
		testFinalScore = finalScore;
		testKilledEnemys = killedEnemys;
		testBadPickups = badPickups;
		//hpText.text = lifes.ToString();
		//scoreText.text = currentScore.ToString();
	}

	// Creamos esta funcion auxiliar para que pueda ser invocada por el script de PlayerHealth
	// Aunque tambien funciona invocando directa a la corrutina desde el script externo
	public void LoadNextLevel(int level, float delay) {
		
		StartCoroutine(CoLoadNextLevel(level,delay));
	}
	
	public IEnumerator CoLoadNextLevel(int level, float delay) {

		finalScore += currentScore;

		// yield return new WaitForSeconds(gameOver.clip.length+0.5f);
		yield return new WaitForSeconds(delay);

		currentScore = 0;
		lifes = 3;

		if (currentLevel < Application.levelCount - 1)
			Application.LoadLevel ("Level_" + currentLevel); 	// Esto cargar un nivel particular
		else
			Application.LoadLevel(Application.loadedLevel + 1); // Esto carga el siguiente nivel segun el orden en el Build Setttings
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
