using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsBehavior : MonoBehaviour
{
    public bool isBattleMode;
    bool isShowingInstructions = true;
    public GameObject instructionsObject;

    // Use this for initialization
    void Start()
    {

        var instructionsObject1 = instructionsObject;

        //battleInstructions = GameObject.FindWithTag("BattleInstructions");
        if (isBattleMode)
        {
            var hasSeenBattleIntructions = PlayerPrefs.HasKey("hasSeenBattleIntructions") &&
                PlayerPrefs.GetString("hasSeenBattleIntructions") == "true";
            if (hasSeenBattleIntructions)
            {
                HideInstructions();
            }
            else
            {
                isShowingInstructions = true;
                //set battle instruction button visible;
            }
        }
        else
        {
            var hasSeenStandardIntructions = PlayerPrefs.HasKey("hasSeenStandardIntructions") &&
                PlayerPrefs.GetString("hasSeenStandardIntructions") == "true";

            if (hasSeenStandardIntructions)
            {
                HideInstructions();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame
    public void HideInstructions()
    {

        if (isBattleMode)
        {
            PlayerPrefs.SetString("hasSeenBattleIntructions", "true");
        }
        else
        {
            PlayerPrefs.SetString("hasSeenStandardIntructions", "true");
        }

        ToggleInstructions();
    }

    public void ToggleInstructions()
    {
        isShowingInstructions = !isShowingInstructions;
        //var instructions = GameObject.FindWithTag("Instructions");
        instructionsObject.SetActive(isShowingInstructions);
        //instructions.SetActive(isShowingInstructions);
    }

}
