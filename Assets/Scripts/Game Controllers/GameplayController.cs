﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private Text scoreText, lifeScore, photoScore, coinScore, gameOverScoreText, gameOverCoinScoreText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	[SerializeField]
	private GameObject readyButton;

    [SerializeField]
    public int photoCounter;

	void Awake () {
		MakeInstance ();
        //		Time.timeScale = 0f;
        photoCounter = 0;
        SetPhotoScore(photoCounter);
	}

	void Start() {
		//Time.timeScale = 0f;
		StartTheGame();
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

    public void SetPhotoScore(int scoreCounter) {
        photoScore.text = "" + scoreCounter;
    }

	public void SetScore(int score) {
		scoreText.text = "" + score;
	}

	public void SetCoinScore(int score) {
		coinScore.text = "x" + score;
	}

	public void SetLifeScore(int score) {
		lifeScore.text = "x" + score;
	}

	public void GameOverShowPanel (int gameOverScore, int gameOverCoinScore) {
		gameOverPanel.SetActive (true);
		gameOverScoreText.text = "" + gameOverScore;
		gameOverCoinScoreText.text = "" + gameOverCoinScore;
		StartCoroutine (GameOverLoadMainMenu ());
	}

	IEnumerator GameOverLoadMainMenu() {
		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(3f));
		SceneFader.instance.LoadLevel ("MainMenu");
	}

	public void PlayerDiedRestartLevel() {
		StartCoroutine (PlayerDiedRestart ());
	}

	IEnumerator PlayerDiedRestart() {
		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
		SceneFader.instance.LoadLevel ("Gameplay");
	}

	public void PauseGame() {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void QuitGame() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
//		SceneFader.instance.LoadLevel ("MainMenu");
	}

	public void StartTheGame() {
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}

} // GameplayController




































































