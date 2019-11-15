using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public CharacterRace charRace;
    public Vector2 scr;
    public int selectedIndex, Indexselected, points = 10;
    public PlayerHandler player;
    public PlayerSaveAndLoad saveNew;
    public Text[] text;
    public Text RaceChar;
    public Text ClassChar;
    public Text pointValue;
    public InputField NameCharacter;
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
        //make the array of different options be there
        SetTexture("Skin", 0);
        SetTexture("Eyes", 0);
        SetTexture("Mouth", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        ChooseClass(selectedIndex);
        ChooseRace(Indexselected);
        //spawns in the default on the character
    }
    public void Save()
    {
        if (points == 0)
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
            player.characterRace = charRace;
            player.characterName = NameCharacter.text;
            for (int i = 0; i < playerStats.Length; i++)
            {
                player.stats[i].value = (playerStats[i].statValue + playerStats[i].tempStat);
            }
            saveNew.Save();
            SceneManager.LoadScene(2);
        }
    }
    public void Update()
    {
        //characterName = NameCharacter.text; 
}
    // is used to save your indexes you sent
    
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
                //allows you changes to the code affect the 
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
// these allow the code to loop around
    
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
        //defines the changes so they can be loaded back into the code

    
    }
    public void MinusSkin()
    {
        SetTexture("Skin", -1);
    }
// press the button to change skin back by one
    public void PlusSkin()
    {
        SetTexture("Skin", 1);
    }
    // press the button to change skin forward by one
    public void MinusEyes()
    {
        SetTexture("Eyes", -1);
    }
    // press the button to change eyes back by one
    public void PlusEyes()
    {
        SetTexture("Eyes", 1);
    }
    // press the button to change eyes forward by one
    public void MinusMouth()
    {
        SetTexture("Mouth", -1);
    }
    // press the button to change mouth back by one
    public void PlusMouth()
    {
        SetTexture("Mouth", 1);
    }
    // press the button to change mouth forward by one
    public void MinusHair()
    {
        SetTexture("Hair", -1);
    }
    // press the button to change hair back by one
    public void PlusHair()
    {
        SetTexture("Hair", 1);
    }
    // press the button to change hair forward by one
    public void MinusClothes()
    {
        SetTexture("Clothes", -1);
    }
    // press the button to change clothes back by one
    public void PlusClothes()
    {
        SetTexture("Clothes", 1);
    }
    // press the button to change clothes forward by one
    public void MinusArmour()
    {
        SetTexture("Armour", -1);
    }
    // press the button to change armour back by one
    public void PlusArmour()
    {
        SetTexture("Armour", 1);
    }
    // press the button to change armour forward by one
    public void RandomChange()
    {
        SetTexture("Skin", Random.Range(0, skinMax - 1));
        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
        SetTexture("Hair", Random.Range(0, hairMax - 1));
        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
        SetTexture("Armour", Random.Range(0, armourMax - 1));
    }
    // move all index forward a random number of spots
    public void ResetChange()
    {
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
    }
    // makes all the index go back to 0 values
    
   
    public void MinusClass()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = 3;
        }
        ChooseClass(selectedIndex);
        ClassChar.text = charClass.ToString();
    }
    // changes the class the one beforehand and displays it
    public void PlusClass()
    {
        selectedIndex++;
        if (selectedIndex > 3)
        {
            selectedIndex = 0;
        }
        ChooseClass(selectedIndex);
ClassChar.text = charClass.ToString();
    }
// changes the class the one after and displays it
     public void MinusRace()
    {
        Indexselected--;
        if (Indexselected < 0)
        {
            Indexselected = 3;
        }
        ChooseRace(Indexselected);
        RaceChar.text = charRace.ToString();
    }
    // changes the class the one beforehand and displays it
    public void PlusRace()
    {
        Indexselected++;
        if (Indexselected > 3)
        {
            Indexselected = 0;
        }
        ChooseRace(Indexselected);
RaceChar.text = charRace.ToString();
    }
// changes the class the one after and displays it
    public void PlusStat(int s)
    {
        if (points > 0)
        {
        points--;
                    playerStats[s].tempStat++;
        }
        text[s].text = playerStats[s].statName + ": " + (playerStats[s].statValue + playerStats[s].tempStat);
pointValue.text = "Points: " + points;
    }
    // allows you you to use your points to increase certain stats
    public void MinusStat(int s)
    {
      if (points < 10)
      {
        points++;
                    playerStats[s].tempStat--;
      }  
              text[s].text = playerStats[s].statName + ": " + (playerStats[s].statValue + playerStats[s].tempStat);
pointValue.text = "Points: " + points;

    }
// allows you to dump values for bonus points

    
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
    void ChooseRace(int raceID)
	{
		if(raceID < 0)
		{
			
		}
	switch(raceID)
	{
		case 0:
		playerStats[0].statValue = 8;
		playerStats[1].statValue = 2;
		playerStats[2].statValue = 5;
		playerStats[3].statValue = 5;
		playerStats[4].statValue = 2;
		playerStats[5].statValue = 4;
		charRace = CharacterRace.Elf;
		break;
		case 1:
		playerStats[0].statValue = 4;
		playerStats[1].statValue = 5;
		playerStats[2].statValue = 6;
		playerStats[3].statValue = 3;
		playerStats[4].statValue = 5;
		playerStats[5].statValue = 3;
		charRace = CharacterRace.Dwarf;
		break;
		case 2:
		playerStats[0].statValue = 5;
		playerStats[1].statValue = 9;
		playerStats[2].statValue = 5;
		playerStats[3].statValue = 9;
		playerStats[4].statValue = 8;
		playerStats[5].statValue = 8;
		charRace = CharacterRace.Human;
		break;
		case 3:
		playerStats[0].statValue = 1;
		playerStats[1].statValue = 5;
		playerStats[2].statValue = 9;
		playerStats[3].statValue = 3;
		playerStats[4].statValue = 1;
		playerStats[5].statValue = 5;
		charRace = CharacterRace.Undead;
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
    public enum CharacterRace
    {
        Elf,
        Dwarf,
        Human,
        Undead

    }
