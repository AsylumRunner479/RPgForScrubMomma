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
    public PlayerData(Customisation player)
    {
        skinIndex = player.skinIndex;
        eyesIndex = player.eyesIndex;
        armourIndex = player.armourIndex;
        hairIndex = player.hairIndex;
        clothesIndex = player.clothesIndex;
        mouthIndex = player.mouthIndex;
        stats = new float[6];
        stats[0] = player.playerStats[0].statValue;
        stats[1] = player.playerStats[1].statValue;
        stats[2] = player.playerStats[2].statValue;
        stats[3] = player.playerStats[3].statValue;
        stats[4] = player.playerStats[4].statValue;
        stats[5] = player.playerStats[5].statValue;
        className = player.className;
        points = player.points;
        character = player.characterName;
        return (temp);
    }
}
