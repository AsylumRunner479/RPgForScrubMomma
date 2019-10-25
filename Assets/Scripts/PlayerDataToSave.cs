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
    public PlayerDataToSave(PlayerHandler player)
    {
        playerName = player.name;
        level = 0;
        checkPoint = player.curCheckPoint.name;
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = PlayerHandler.curStamina;

        posx = player.transform.position.x;
        posy = player.transform.position.y;
        posz = player.transform.position.z;

        rotx = player.transform.rotation.x;
        roty = player.transform.rotation.y;
        rotz = player.transform.rotation.z;
        rotw = player.transform.rotation.w;

    }

}
