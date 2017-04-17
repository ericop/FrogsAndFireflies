using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroy : MonoBehaviour {

	public  float SecondsToWait;

	void Start () 
	{
		StartCoroutine (DestroyMe ());	
	}

	IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds (SecondsToWait);
		Destroy (gameObject);
	}
}
