using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerHandler player;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            FirstLoad();
            PlayerPrefs.SetInt("Loaded", 0);
            //Save Binary Data
            Save();
        }
        else
        {
            //Load Binary
            Load();
        }
    }
    void FirstLoad()
    {
        player.maxHealth = 100;
        player.maxMana  = 100;
        player.maxStamina = 100;
        player.curCheckPoint = GameObject.Find("First CheckPoint").GetComponent<Transform>();

        player.curHealth = player.maxHealth;
        player.curMana = player.maxMana;
        PlayerHandler.curStamina = player.maxStamina;
        for (int i = 0; i < player.stats.Length; i++)
        {
            player.stats[i].value = 10;
        }
        player.transform.position = new Vector3(1, 1, 1);
        player.transform.rotation = new Quaternion(0, 0, 0, 0);

    }
    public void Save()
    {
        PlayerSaveToBinary.SavePlayerData(player);
    }

    public void Load()
    {
        PlayerDataToSave data = PlayerSaveToBinary.LoadData(player);
        player.name = data.playerName;
        player.curCheckPoint = GameObject.Find(data.checkPoint).GetComponent<Transform>();
        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;
        for (int i = 0; i < data.stats.Length; i++)
        {
            player.stats[i].value = data.stats[i];
        }
        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        PlayerHandler.curStamina = data.curStamina;

        player.transform.position = new Vector3(data.posx, data.posy, data.posz);
        player.transform.rotation = new Quaternion(data.rotx, data.roty, data.rotz, data.rotw);
    }
}
