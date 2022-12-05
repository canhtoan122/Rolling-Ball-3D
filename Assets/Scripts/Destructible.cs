using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destructible : MonoBehaviour {

	public Transform player;
	public Transform pieces;

	public Text gameoverText;
	public GameObject gameoverPanel;
	public GameManager gameManager;

	public void Destroy () {

		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		gameObject.GetComponent<Collider>().enabled = false;
		//player.gameObject.SetActive (false);
		//pieces.gameObject.SetActive (true);
		gameoverText.text = "GAME OVER";
		//gameManager.gameOver.Play();
		GameManager.endGame = true;
		Time.timeScale = 0f;

		gameoverPanel.SetActive(true);
	}


}
