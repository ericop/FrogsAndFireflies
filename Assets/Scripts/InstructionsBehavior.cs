using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsBehavior : MonoBehaviour
{

    public bool isBattleMode;
    bool isShowingInstructions;

    // Use this for initialization
    void Start()
    {
        var isBattleMode = PlayerPrefs.HasKey("isBattleMode") && PlayerPrefs.GetString("isBattleMode") == "true";

        //if (isBattleMode)
        //{

        //    var hasSeenBattleIntructions = PlayerPrefs.HasKey("hasSeenBattleIntructions")
        //        && PlayerPrefs.GetString("hasSeenBattleIntructions") == "true";
        //    if (hasSeenBattleIntructions)
        //    {
        //        HideInstructions();
        //    }
        //    else
        //    {
        //        isShowingInstructions = true;
        //        //set battle instruction button visible;
        //    }
        //}
        //else
        //{
        //    var hasSeenStandardIntructions = PlayerPrefs.HasKey("hasSeenStandardIntructions")
        //        && PlayerPrefs.GetString("hasSeenStandardIntructions") == "true";

        //    if (hasSeenStandardIntructions)
        //    {
        //        HideInstructions();
        //    }
        //}


        PlayerPrefs.SetString("hasSeenBattleIntructions", "true");
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
            //hide battle instructions
            isShowingInstructions = false;
            gameObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetString("hasSeenStandardIntructions", "true");
            //hide standard instructions
            isShowingInstructions = false;
            gameObject.SetActive(false);
        }
    }

    public void ToggleInstructions()
    {
        isShowingInstructions = !isShowingInstructions;
        var battleInstructions = GameObject.FindWithTag("BattleInstructions");
        //var instructions = GameObject.FindWithTag("Instructions");
        battleInstructions.SetActive(isShowingInstructions);
        //instructions.SetActive(isShowingInstructions);
    }

}
