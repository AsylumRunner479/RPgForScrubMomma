using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int selectedIndex, points;
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
    public PlayerData(Customisation player)
    {
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
        className = (int)player.charClass;
        //points = player.points;
        character = player.characterName;
       // return (player);
    }
    public void Save()
    {
        PlayerSaveToBinary.SavePlayerData(this);
    }
}
