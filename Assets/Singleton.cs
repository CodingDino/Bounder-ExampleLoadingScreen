// ************************************************************************ 
// File Name:   Singleton.cs 
// Purpose:    	Singleton pattern
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
// Class: Singleton
// ************************************************************************ 
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ********************************************************************
    // Static Data Members 
    // ********************************************************************
    protected static T s_instance;


    // ********************************************************************
    // Properties 
    // ********************************************************************
    public static T instance  { get {
            // Check if the instance already exists in the scene
            if (s_instance == null)
                s_instance = (T)FindObjectOfType(typeof(T));

            // Creates an instance if it doesn't exist
            //if (s_instance == null)
            //{
            //    GameObject newGameObject = new GameObject();
            //    newGameObject.AddComponent(typeof(T));
            //    s_instance = (T)newGameObject.GetComponent(typeof(T));
            //}

            return s_instance;
        }
    }
}
