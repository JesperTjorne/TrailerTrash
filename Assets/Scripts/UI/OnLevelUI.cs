﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnLevelUI : MonoBehaviour 
{
	bool firstSpace = true;

	private GameObject missionWinObject;
	private MissionWinUI missionWinUI;

	public float maxTime = 30.0f;
	public float timeLeft;
	private Truck truck;

	GameObject tutorialObject;

	//fields
	GameObject timeObject;
	private Text time;

	GameObject nextObject;
	private Text next;

	GameObject cargoImageObject;
	Image cargoImage;

	GameObject woodObject;
	Text wood;

	GameObject ironObject;
	Text iron;

	GameObject glassObject;
	Text glass;

	// Use this for initialization
	void Awake () 
	{
		missionWinObject = GameObject.Find ("MissionWinUI");
		missionWinUI = missionWinObject.GetComponent<MissionWinUI>();

		//fields
		timeObject = GameObject.Find ("Time");
		time = timeObject.GetComponent<Text>();

		nextObject = GameObject.Find ("Next");
		next = nextObject.GetComponent<Text>();

		woodObject = GameObject.Find ("Wood");
		wood = woodObject.GetComponent<Text> ();
		
		ironObject = GameObject.Find ("Iron");
		iron = ironObject.GetComponent<Text>();
		
		glassObject = GameObject.Find ("Glass");
		glass = glassObject.GetComponent<Text>();

		cargoImageObject = GameObject.Find ("CargoImage");
		cargoImage = cargoImageObject.GetComponent<Image>();

		truck = GameObject.Find ("Truck").GetComponent<Truck> ();
		timeLeft = maxTime;

		tutorialObject = GameObject.Find ("Tutorial");
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeLeft -= Time.deltaTime;
		
		if (timeLeft <= 0) 
		{
			timeLeft = 0;
			truck.SetActive(false);
		}
		time.text = Mathf.Ceil(timeLeft).ToString ();

		if(Input.GetKeyDown(KeyCode.Space) && firstSpace)
		{
			firstSpace = false;
			tutorialObject.GetComponent<Text> ().enabled = false;
		}
	}

	public void WriteNextCargo(GameObject cargo)
	{
		next.text = cargo.name;
		BaseCargo baseCargo = cargo.GetComponent<BaseCargo>();
		cargoImage.sprite = baseCargo.UISprite;
	}

	public void WriteOrder(int woodNum, int woodOrder, int ironNum, int ironOrder, int glassNum, int glassOrder)
	{
		if (wood != null && iron != null && glass != null) 
		{
			if(woodNum >= woodOrder)
			{
				wood.text = "Completed";
			}
			else
			{
				wood.text = woodNum.ToString () + "/" + woodOrder.ToString ();
			}

			if(ironNum >= ironOrder)
			{
				iron.text = "Completed";
			}
			else
			{
				iron.text = ironNum.ToString () + "/" + ironOrder.ToString ();
			}

			if(glassNum >= glassOrder)
			{
				glass.text = "Completed";
			}
			else
			{
				glass.text = glassNum.ToString () + "/" + glassOrder.ToString ();
			}
		}
	}
}
