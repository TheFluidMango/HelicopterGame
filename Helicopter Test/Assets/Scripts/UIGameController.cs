﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameController : MonoBehaviour
{
    public Text EngineForceView;
    public GameObject RestartButton;
    public GameObject InfoButton;
    public GameObject InfoPanel;
	public GameObject Score;
	public GameObject numCivs;
	public GameObject healthHUD;

	// Use this for initialization
    public static UIGameController runtime;

    private void Awake()
    {
        runtime = this;
    }

    void Start ()
	{
	    ShowInfo();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("escape"))
			Application.LoadLevel ("Title");
	}

    private void ShowInfoPanel(bool isShow)
    {
        EngineForceView.gameObject.SetActive(!isShow);
		Score.SetActive (!isShow);
		numCivs.SetActive (!isShow);
		healthHUD.SetActive (!isShow);
        RestartButton.SetActive(!isShow);
        InfoButton.SetActive(!isShow);
        InfoPanel.SetActive(isShow);
    }

    public void ShowInfo()
    {
        ShowInfoPanel(true);
    }
    public void HideInfo()
    {
        ShowInfoPanel(false);
    }

    public void RestartGame()
    {
		Debug.Log ("failed");
        Application.LoadLevel("LevelTwo");
    }
}
