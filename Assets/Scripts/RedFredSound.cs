using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHughSoundDestroy : MonoBehaviour {
	public float NumberOsSecondToWait;

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroySelf ());
	}
	
	IEnumerator DestroySelf(){
		yield return new WaitForSeconds(NumberOsSecondToWait);
		Destroy (gameObject);
	}
}
