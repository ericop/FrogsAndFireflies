using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattleButtonBehaviour : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

	public void ButtonClick()
	{

		PlayerPrefs.SetString ("isBattleMode", "true");
		SceneManager.LoadScene("battle");
	}
}
