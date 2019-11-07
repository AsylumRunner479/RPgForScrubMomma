using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerDataToSave 
{
    //Data...Get from Game
    public string playerName;
    public int level;
    public string checkPoint;
    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float posx, posy, posz;
    public float rotx, roty, rotz, rotw;
    public int selectedIndex, points;
    public static int saveSlot;
    public struct Stats
    {
        public string statName;
        public int statValue;
        public int tempStat;
    };
    public Stats[] playerStats = new Stats[6];
    public int skinIndex, eyesIndex, armourIndex, hairIndex, clothesIndex, mouthIndex;
    public int[] stats = new int[6];
    public int className;
    public string character;
    public PlayerDataToSave(PlayerHandler player)
    {
        playerName = player.name;
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
            checkPoint = player.firstCheckPoint;
            posx = 0;
            posy = 0;
            posz = 0;
        }
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = PlayerHandler.curStamina;

       
        skinIndex = player.skinIndex;
        eyesIndex = player.eyesIndex;
        armourIndex = player.armourIndex;
        hairIndex = player.hairIndex;
        clothesIndex = player.clothesIndex;
        mouthIndex = player.mouthIndex;
        stats[0] = player.playerStats[0].statValue;
        stats[1] = player.playerStats[1].statValue;
        stats[2] = player.playerStats[2].statValue;
        stats[3] = player.playerStats[3].statValue;
        stats[4] = player.playerStats[4].statValue;
        stats[5] = player.playerStats[5].statValue;
        classIndex = (int)player.characterClass;
        //points = player.points;
        character = player.character;
        // return (player);
    }
    public void Save()
    {
        PlayerSaveToBinary.SavePlayerData(this);
    }

}
