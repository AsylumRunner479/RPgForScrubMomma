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
    
  
}
