using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerDataToSave 
{
    //Data....Get from Game
    //create a string called playerName
    public string playerName;
    public int level;
    public string checkPoint;
    // create public floats for maxHealth, maxMana, maxStamina, curHealth, curMana, curStamina 
    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float posx, posy, posz;
    public float rotx, roty, rotz, rotw;
    //create a static int called saveSlot
    public static int saveSlot;
    //create an array of stats and set it to 6
    public int[] stats = new int[6];
    // create public int for classIndex, raceIndex, skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex
    public int classIndex;
    public int raceIndex;
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    //
    public PlayerDataToSave(PlayerHandler player)
    {
        //set playerName to characterName in player
        playerName = player.characterName;
        level = 0;
        if (player.curCheckPoint != null)
        {
            checkPoint = player.curCheckPoint.name;
            posx = player.transform.position.x;
            posy = player.transform.position.y;
            posz = player.transform.position.z;

            rotx = player.transform.rotation.x;
            roty = player.transform.rotation.y;
            rotz = player.transform.rotation.z;
            rotw = player.transform.rotation.w;
        }
        else
        {
            checkPoint = player.firstCheckPointName;
            posx = 0;
            posy = 0;
            posz = 0;
        }
        //set the maxHealth to maxHealth in player
        maxHealth = player.maxHealth;
        //set the maxMana to maxMana in player
        maxMana = player.maxMana;
        //set the maxStamina to maxStamina in player
        maxStamina = player.maxStamina;
        //set the curHealth to curHealth in player
        curHealth = player.curHealth;
        //set the curMana to curMana in player
        curMana = player.curMana;
        //set the curStamina to curStamina in PlayerHandler
        curStamina = PlayerHandler.curStamina;
        //set the stats array to the stats array in player
        for (int i = 0; i < 6; i++)
        {
            stats[i] = player.stats[i].value;
        }
        //set the skinIndex to skinIndex in player
        skinIndex = player.skinIndex;
        //set the hairIndex to hairIndex in player
        hairIndex = player.hairIndex;
        //set the mouthIndex to mouthIndex in player
        mouthIndex = player.mouthIndex;
        //set the eyesIndex to eyesIndex in player
        eyesIndex = player.eyesIndex;
        //set the clothesIndex to clothesIndex in player
        clothesIndex = player.clothesIndex;
        //set the armourIndex to armourIndex in player
        armourIndex = player.armourIndex;
        //set the raceIndex to characterRace used in player
        raceIndex = (int)player.characterRace;  
        //set the classIndex to charcterClass used in player
        classIndex = (int)player.characterClass;
    }

}
