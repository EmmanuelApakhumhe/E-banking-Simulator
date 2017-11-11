using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmManager : MonoBehaviour 
{
	public static AtmManager instance;

	[HideInInspector] public const string ClearString = "";
	
	public InputField[] CreateAccountInputOptions;
	public GameObject[] CreateAccountPanels;

	void Awake()
	{
		//Singleton Pattern
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
	}

	public void CreateButton()
	{
		foreach (InputField item in CreateAccountInputOptions) 
		{
			item.text = ClearString;
		}

		foreach (GameObject item in CreateAccountPanels) 
		{
			if (item.activeInHierarchy == true) 
			{
				item.SetActive (false);
			}
		}
	}
		
}
