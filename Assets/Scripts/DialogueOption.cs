using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption : MonoBehaviour
{
    public Color dialogueColor = Color.white;
    public string[] dialogue;
    public int index, option;
    public bool showDlg;
    private void OnGUI()
    {
        if(showDlg)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            //makes half the screen into a dialogue box
            string text = "<color=\"#" + ColorUtility.ToHtmlStringRGB(dialogueColor) + "\">" + dialogue[index] + "</color>";

            GUI.Box(new Rect(0, scr.y * 6,Screen.width, scr.y*3), text);
            if(!(index >= dialogue.Length-1 || index == option))
            {
                //reads the different lines in order
                if (GUI.Button(new Rect(scr.x*14,scr.y*8,scr.x*2,scr.y),"Next"))
                {
                    index++;
                }
            }
            else if(index == option)
            {
                //makes you end the dialogue early
                if (GUI.Button(new Rect(scr.x * 14, scr.y * 8, scr.x * 2, scr.y), "Fuck Off"))
                {
                    index = dialogue.Length - 1;
                }
                //continues the dialogue in order
                if (GUI.Button(new Rect(scr.x * 10, scr.y * 8, scr.x * 2, scr.y), "Next"))
                {
                    index++;
                }
            }
            else
            {
                //allows you to leave after the dialogue is over 
                if (GUI.Button(new Rect(scr.x * 14, scr.y * 8, scr.x * 2, scr.y), "Bye"))
                {
                    index = 0;
                    showDlg = false;
                }
            }
        }
    }
}
