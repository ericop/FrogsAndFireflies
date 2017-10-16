using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButtonBehaviour : MonoBehaviour
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
        // no longer using isBattleMode playerpref, but setting it ass bool on object in Unity GUI
        SceneManager.LoadScene("credits");
    }
		
}
