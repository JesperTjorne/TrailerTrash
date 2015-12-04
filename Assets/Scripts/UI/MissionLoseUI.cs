﻿using UnityEngine;
using System.Collections;

public class MissionLoseUI : MonoBehaviour 
{
	private int currentLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoseLevel()
	{
		GameObject soundObject = GameObject.Find("SoundSystem");
		SoundSystem soundSystem = soundObject.GetComponent<SoundSystem>();
		soundSystem.Save();

		GameObject buttonClickObject = GameObject.Find ("ButtonClick");
		AudioSource buttonClick = buttonClickObject.GetComponent<AudioSource>();
		buttonClick.Play ();
		Application.LoadLevel (currentLevel);
	}
}
