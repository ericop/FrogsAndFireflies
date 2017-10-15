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
        //Use this locally to clear playerprefs
        //PlayerPrefs.DeleteAll();

        // no longer using isBattleMode playerpref, but setting it ass bool on object in Unity GUI
        //PlayerPrefs.SetString ("isBattleMode", "true");
        SceneManager.LoadScene("battle");
	}
}
