using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{

	public WordController wordController;
	private int count = 0;

	public float wordDelay = 2.5f;
	private float nextWordTime = 0f;

	

	private void Update()
	{
		Debug.Log(FindObjectsOfType<WordDisplay>());
		if (FindObjectsOfType<WordDisplay>() == null)
		{
			Debug.Log("No words");
			count = 0;
			wordController.AddWord();
		}

		if (Time.time >= nextWordTime && count < 18)
		{
			wordController.AddWord();
			nextWordTime = Time.time + wordDelay;
			wordDelay *= .99f;
			count++;
		}
        
		
	}

}
