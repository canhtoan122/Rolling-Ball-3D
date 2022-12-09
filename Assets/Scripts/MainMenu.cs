using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

	public void QuitGame () {


		Application.LoadLevel("Summary");
	}
	
	public void LoadLevel (string level) {
	
		Application.LoadLevel (level);
	}

	public void SetVolume(float volume) {

		GameObject musicManager = GameObject.FindGameObjectWithTag ("Music Manager");
		if (musicManager != null) {
			Debug.Log ("Encontro music manager");
			AudioSource music = musicManager.GetComponent<AudioSource>();
			music.volume = volume;
		}

		// Para sacar el focus del Slider, sino al presionar las teclas
		// de direccion para mover la pelota se baja/sube el volumen
		EventSystem.current.SetSelectedGameObject(null);
	}

	public GameObject startButton;
	public GameObject exitButton;
	public GameObject level1Button;
	public GameObject level2Button;
	public GameObject summaryLevelButton;
	public GameObject logoutButton;
	public void StartNewLevel()
    {
		startButton.SetActive(false);
		exitButton.SetActive(false);
		logoutButton.SetActive(false);
		level1Button.SetActive(true);
		level2Button.SetActive(true);
		summaryLevelButton.SetActive(true);

	}
	public void LogOut()
    {
		Application.LoadLevel("Account");
	}
	public void decore()
    {
		Application.LoadLevel("display screen");
    }
}
