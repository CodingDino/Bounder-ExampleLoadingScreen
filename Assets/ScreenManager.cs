// ************************************************************************ 
// File Name:   ScreenManager.cs 
// Purpose:    	Transfers between scenes
// Project:		Framework
// Author:      Sarah Herzog  
// Copyright: 	2015 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
// Imports 
// ************************************************************************ 
using UnityEngine;
using System.Collections;


// ************************************************************************ 
// Class: ScreenManager
// ************************************************************************
public class ScreenManager : MonoBehaviour {
	
	
	// ********************************************************************
	// Exposed Data Members 
	// ********************************************************************
	[SerializeField]
	private FadeSprite m_blackScreenCover;
	[SerializeField]
	private float m_minDuration = 1.5f;
	
	
	// ********************************************************************
	// Function:	Update()
	// Purpose:		Called once per frame.
	// ********************************************************************
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			StartCoroutine(LoadSceneAsync("GameScreen"));
		}
	}
	
	
	// ********************************************************************
	// Function:	LoadScene()
	// Purpose:		Loads the supplied scene
	// ********************************************************************
	public IEnumerator LoadSceneAsync(string sceneName)
	{
		// Fade to black
		yield return StartCoroutine(m_blackScreenCover.FadeIn());
		
		// Load loading screen
		yield return Application.LoadLevelAsync("LoadingScreen");
		
		// !!! unload old screen (automatic)
		
		// Fade to loading screen
		yield return StartCoroutine(m_blackScreenCover.FadeOut());
		
		float endTime = Time.time + m_minDuration;
		
		// Load level async
		yield return Application.LoadLevelAdditiveAsync(sceneName);
		
		while (Time.time < endTime)
			yield return null;
		
		// Play music or perform other misc tasks
		
		// Fade to black
		yield return StartCoroutine(m_blackScreenCover.FadeIn());
		
		// !!! unload loading screen
		LoadingSceneManager.UnloadLoadingScene();
		
		// Fade to new screen
		yield return StartCoroutine(m_blackScreenCover.FadeOut());
	}


}
