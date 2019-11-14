﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customisation : MonoBehaviour
{
    public Renderer characterRenderer;
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public int skinMax, eyesMax, mouthMax, hairMax, clothesMax, armourMax;
    public string characterName = "Adventurer";
    [System.Serializable]
    public struct Stats
    {
        public string statName;
        public int statValue;
        public int tempStat;
    };
    public Stats[] playerStats = new Stats[6];
    public CharacterClass charClass;
    public Vector2 scr;
    public int selectedIndex, points = 10;
    public PlayerHandler player;
    public PlayerSaveAndLoad saveNew;
    void Start()
    {
        for (int i = 0; i < skinMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            skin.Add(tempTexture);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            eyes.Add(tempTexture);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            mouth.Add(tempTexture);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            hair.Add(tempTexture);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            clothes.Add(tempTexture);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            armour.Add(tempTexture);
        }
        SetTexture("Skin", 0);
        SetTexture("Eyes", 0);
        SetTexture("Mouth", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        ChooseClass(selectedIndex);
    }
    public void Save()
    {
        player.maxHealth = 100;
        player.maxMana = 100;
        player.maxStamina = 100;

        player.curHealth = player.maxHealth;
        player.curMana = player.maxMana;
        PlayerHandler.curStamina = player.maxStamina;

        player.skinIndex = skinIndex;
        player.hairIndex = hairIndex;
        player.armourIndex = armourIndex;
        player.mouthIndex = mouthIndex;
        player.clothesIndex = clothesIndex;
        player.eyesIndex = eyesIndex;

        player.characterClass = charClass;
        player.characterName = characterName;
        for (int i = 0; i < playerStats.Length; i++)
        {
            player.stats[i].value = (playerStats[i].statValue + playerStats[i].tempStat);
        }
        saveNew.Save();
        SceneManager.LoadScene(2);
    }
    public void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                matIndex = 1;
                textures = skin.ToArray();
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                matIndex = 2;
                textures = eyes.ToArray();
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                matIndex = 3;
                textures = mouth.ToArray();
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                matIndex = 4;
                textures = hair.ToArray();
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                matIndex = 5;
                textures = clothes.ToArray();
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                matIndex = 6;
                textures = armour.ToArray();
                break;
        }
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = characterRenderer.materials;
        mat[matIndex].mainTexture = textures[index];
        characterRenderer.materials = mat;

        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
        }

    }
    public void MinusSkin()
    {
        SetTexture("Skin", -1);
    }
    public void PlusSkin()
    {
        SetTexture("Skin", 1);
    }
    public void MinusEyes()
    {
        SetTexture("Eyes", -1);
    }
    public void PlusEyes()
    {
        SetTexture("Eyes", 1);
    }
    public void MinusMouth()
    {
        SetTexture("Mouth", -1);
    }
    public void PlusMouth()
    {
        SetTexture("Mouth", 1);
    }
    public void MinusHair()
    {
        SetTexture("Hair", -1);
    }
    public void PlusHair()
    {
        SetTexture("Hair", 1);
    }
    public void MinusClothes()
    {
        SetTexture("Clothes", -1);
    }
    public void PlusClothes()
    {
        SetTexture("Clothes", 1);
    }
    public void MinusArmour()
    {
        SetTexture("Armour", -1);
    }
    public void PlusArmour()
    {
        SetTexture("Armour", 1);
    }
    public void RandomChange()
    {
        SetTexture("Skin", Random.Range(0, skinMax - 1));
        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
        SetTexture("Hair", Random.Range(0, hairMax - 1));
        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
        SetTexture("Armour", Random.Range(0, armourMax - 1));
    }
    public void ResetChange()
    {
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
    }
    
    private void OnGUI()
    {
        if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
        
        DisplayStats();
        if (GUI.Button(new Rect(scr.x * 0.25f, 0.5f * scr.y, scr.x * 0.5f, scr.y * 0.5f), "Save"))
        {
            Save();
        }
    }
    public void MinusClass()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = 3;
        }
        ChooseClass(selectedIndex);
    }
    public void PlusClass()
    {
        selectedIndex++;
        if (selectedIndex > 3)
        {
            selectedIndex = 0;
        }
        ChooseClass(selectedIndex);
    }

    public void MinusStr()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = 3;
        }
        ChooseClass(selectedIndex);
    }
    public void PlusStr()
    {
        selectedIndex++;
        if (selectedIndex > 3)
        {
            selectedIndex = 0;
        }
        ChooseClass(selectedIndex);
    }


    void DisplayStats()
    {
        characterName = GUI.TextField(new Rect(scr.x * 6, scr.y * 7.5f, scr.x * 4, scr.y * 0.5f), characterName, 20);
        int i = 0;
        #region Class
        if (GUI.Button(new Rect(scr.x * 13.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = 3;
            }
            ChooseClass(selectedIndex);
        }
        GUI.Box(new Rect(scr.x * 13.75f, scr.y + i * (0.5f * scr.y), scr.x * 1.5f, scr.y * 0.5f), charClass.ToString());
        if (GUI.Button(new Rect(scr.x * 15.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            selectedIndex++;
            if (selectedIndex > 3)
            {
                selectedIndex = 0;
            }
            ChooseClass(selectedIndex);
        }
        i++;
        #endregion
        #region StatDistribution
        //in variables public int points = 10
        GUI.Box(new Rect(scr.x * 13.25f, scr.y + i * (0.5f * scr.y), scr.x * 2.5f, scr.y * 0.5f), "Points: " + points);

        for (int s = 0; s < playerStats.Length; s++)
        {
            if (points > 0)
            {
                if (GUI.Button(new Rect(scr.x * 15.25f, 2 * scr.y + s * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "+"))
                {
                    points--;
                    playerStats[s].tempStat++;
                }
            }
            GUI.Box(new Rect(scr.x * 13.75f, 2 * scr.y + s * (0.5f * scr.y), 1.5f * scr.x, scr.y * 0.5f), playerStats[s].statName + ": " + (playerStats[s].statValue + playerStats[s].tempStat));

            if (points < 10 && playerStats[s].tempStat > 0)
            {
                if (GUI.Button(new Rect(scr.x * 13.25f, 2 * scr.y + s * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "-"))
                {
                    points++;
                    playerStats[s].tempStat--;
                }
            }
        }
        #endregion
    }
    void ChooseClass(int classID)
	{
		if(classID < 0)
		{
			
		}
	switch(classID)
	{
		case 0:
		playerStats[0].statValue = 8;
		playerStats[1].statValue = 5;
		playerStats[2].statValue = 9;
		playerStats[3].statValue = 3;
		playerStats[4].statValue = 2;
		playerStats[5].statValue = 3;
		charClass = CharacterClass.Fighter;
		break;
		case 1:
		playerStats[0].statValue = 1;
		playerStats[1].statValue = 2;
		playerStats[2].statValue = 6;
		playerStats[3].statValue = 9;
		playerStats[4].statValue = 8;
		playerStats[5].statValue = 4;
		charClass = CharacterClass.Mage;
		break;
		case 2:
		playerStats[0].statValue = 4;
		playerStats[1].statValue = 9;
		playerStats[2].statValue = 5;
		playerStats[3].statValue = 3;
		playerStats[4].statValue = 1;
		playerStats[5].statValue = 8;
		charClass = CharacterClass.Thief;
		break;
		case 3:
		playerStats[0].statValue = 5;
		playerStats[1].statValue = 5;
		playerStats[2].statValue = 5;
		playerStats[3].statValue = 5;
		playerStats[4].statValue = 5;
		playerStats[5].statValue = 5;
		charClass = CharacterClass.Normy;
		break;
	}
	}

}
public enum CharacterClass
    {
        Fighter,
        Mage,
        Thief,
        Normy
    }
