using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class BlueButtonBehaviour : MonoBehaviour
{
	public bool isPressed = false;
	//public GameObject linkedFrog;

	void Start () 
	{

	}

	void Update () 
	{
		if (isPressed)
		{
			//Debug.Log("blue button down");
			var redFrog = GameObject.FindWithTag("BlueFrog");
			var script = redFrog.GetComponent<BlueFrogBehavior> ();
			script.Leap ();
		}

		else if ( !isPressed )
		{
			//Debug.Log("blue button up");
		}
	}
	public void OnButtonDown()
	{
		isPressed = true;
	}
	public void OnButtonUp()
	{
		isPressed = false;
	}
}