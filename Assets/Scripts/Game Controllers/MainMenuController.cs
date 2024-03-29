﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Button musicButton;

	[SerializeField]
	private Sprite[] musicIcons;

	void Start() {
		CheckIfMusicIsOnOrOff ();
	}

	void CheckIfMusicIsOnOrOff() {
		if (GamePreferences.GetMusicState () == 0) {
			if (MusicController.instance != null) {
				MusicController.instance.PlayMusic (true);
			}
			musicButton.image.sprite = musicIcons[0];
		} else {
			musicButton.image.sprite = musicIcons[1];
		}
	}

	public void PlayGame() {
		GameManager.instance.gameStartedFromMainMenu = true;
//		Application.LoadLevel ("Gameplay");
		SceneFader.instance.LoadLevel ("Gameplay");
		
		TurnMusicOn();
	}

	public void HighScoreMenu() {
		SceneManager.LoadScene ("HighscoreMenu");
	}

	public void OptionsMenu() {
		SceneManager.LoadScene ("OptionsMenu");
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void TurnMusicOn()
	{
		MusicController.instance.PlayMusic (true);
	}

	public void TurnMusicOnOrOff() {
		if (GamePreferences.GetMusicState () == 0) {
			GamePreferences.SetMusicState (1);
			if (MusicController.instance != null) {
				MusicController.instance.PlayMusic (false);
			}
			musicButton.image.sprite = musicIcons[1];
		} else {
			GamePreferences.SetMusicState (0);
			if (MusicController.instance != null) {
				MusicController.instance.PlayMusic (true);
			}
			musicButton.image.sprite = musicIcons[0];
		}
	}

} // MainMenuController














































