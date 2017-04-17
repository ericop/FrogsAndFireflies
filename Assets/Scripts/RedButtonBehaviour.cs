using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class RedButtonBehaviour : MonoBehaviour
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
			//Debug.Log("red button down");
			var redFrog = GameObject.FindWithTag("RedFrog");
			var script = redFrog.GetComponent<RedFrogBehavior> ();
			script.Leap ();
		}

		else if ( !isPressed )
		{
			//Debug.Log("red button up");
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
