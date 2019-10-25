using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string[] text;
    public int index;
    public bool showDlg;
    private void OnGUI()
    {
        if(showDlg)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            //this is used to make half the screen black
            GUI.Box(new Rect(0, scr.y * 6,Screen.width, scr.y*3), text[index]);
            if(!(index >= text.Length-1))
            {
                //this changes the dialogue line by line
                if(GUI.Button(new Rect(scr.x*14,scr.y*8,scr.x*2,scr.y),"Next"))
                {
                    index++;
                }
            }
            else
            {
                //makes you quite the dialogue when it is finished
                if (GUI.Button(new Rect(scr.x * 14, scr.y * 8, scr.x * 2, scr.y), "Bye"))
                {
                    index = 0;
                    showDlg = false;
                }
            }
        }
    }
}
