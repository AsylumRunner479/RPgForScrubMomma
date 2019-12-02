using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Customisation : MonoBehaviour
{
    // have a renderer named characterRenderer be accessable in unity
    public Renderer characterRenderer;
    // have a collection of Texture2D named skin be accessable in unity
    public List<Texture2D> skin = new List<Texture2D>();
    // have a collection of Texture2D named eyes be accessable in unity
    public List<Texture2D> eyes = new List<Texture2D>();
    // have a collection of Texture2D named mouth be accessable in unity
    public List<Texture2D> mouth = new List<Texture2D>();
    // have a collection of Texture2D named hair be accessable in unity
    public List<Texture2D> hair = new List<Texture2D>();
    // have a collection of Texture2D named clothes be accessable in unity
    public List<Texture2D> clothes = new List<Texture2D>();
    // have a collection of Texture2D named armour be accessable in unity
    public List<Texture2D> armour = new List<Texture2D>();
    // have a collection of different ints for each texture group so you can change which texture you use in code later 
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    //designate the number of elements permitted in each texture group
    public int skinMax, eyesMax, mouthMax, hairMax, clothesMax, armourMax;
    //have the a string called adventurer be accessable in unity
    public string characterName = "Adventurer";
    [System.Serializable]
    // create a structure for Stats that is accessable in unity and desiginate set values for statName, statValue and tempStat
    public struct Stats
    {
        public string statName;
        public int statValue;
        public int tempStat;
    };
    //have those stats have 6 number of stats named playerStats and have them be accessable in unity 
    public Stats[] playerStats = new Stats[6];
    //have a CharacterClass named charClass and have it accessable in unity 
    public CharacterClass charClass;
    //have a CharacterRace named charRace and have it accessable in unity
    public CharacterRace charRace;

    //public Vector2 scr;
    //have a collection of different ints for the selectedIndex, IndexSelected for the race and class and have it be accessable in unity
    //desiginate an int of 10 points which you can use to improve stats 
    public int selectedIndex, Indexselected, points = 10;
    //have a playerhandler called player so you can put in parts from another script
    public PlayerHandler player;
    //have a playersaveandload called save new so you can put in parts from another script 
    public PlayerSaveAndLoad saveNew;
    //have an array of different text you can put in on a unity server
    public Text[] text;
    //have a public part which you can access from unity so you can change racechar text
    public Text RaceChar;
    //have a public part which you can access from unity so you can change classchar text
    public Text ClassChar;
    ////have a public part which you can access from unity so you can change pointvalue text
    public Text pointValue;
    //have an inputfiedl so the player in the game can change NameCharacter
    public InputField NameCharacter;
    //at start of program
    void Start()
    {
        //load resources from the resource folder up to the skinMax value to the script for when you have to change it
        for (int i = 0; i < skinMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            skin.Add(tempTexture);
        }
        //load resources from the resource folder up to the eyesMax value to the script for when you have to change it
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            eyes.Add(tempTexture);
        }
        //load resources from the resource folder up to the mouthMax value to the script for when you have to change it
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            mouth.Add(tempTexture);
        }
        //load resources from the resource folder up to the hairMax value to the script for when you have to change it
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            hair.Add(tempTexture);
        }
        //load resources from the resource folder up to the clothesMax value to the script for when you have to change it
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            clothes.Add(tempTexture);
        }
        //load resources from the resource folder up to the armourMax value to the script for when you have to change it
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            armour.Add(tempTexture);
        }
        //make the array of different options be there
        //designate a default value for the skinindex
        SetTexture("Skin", 0);
        //designate a default value for the eyeindex
        SetTexture("Eyes", 0);
        //designate a default value for the mouthindex
        SetTexture("Mouth", 0);
        //designate a default value for the hairindex
        SetTexture("Hair", 0);
        //designate a default value for the clothesindex
        SetTexture("Clothes", 0);
        //designate a default value for the armourindex
        SetTexture("Armour", 0);
        //designate a default value for the selectedindex for class
        ChooseClass(selectedIndex);
        //designate a default value for the indexselected for race
        ChooseRace(Indexselected);
        //spawns in the default on the character
    }
    //create a function called Save for the script
    public void Save()
    {
        //make the function only work when you use up the points
        if (points == 0)
        {
            //set the maxHealth in the playerhandler to 100
            player.maxHealth = 100;
            //set the maxMana in the playerhandler to 100
            player.maxMana = 100;
            //set the maxStamina in the playerhandler to 100
            player.maxStamina = 100;
            //set the curHealth in the playerhandler to maxhealth
            player.curHealth = player.maxHealth;
            //set the curMana in the playerhandler to maxMana
            player.curMana = player.maxMana;
            //set the curStamina in the playerhandler to maxStamina
            PlayerHandler.curStamina = player.maxStamina;
            //set the skinIndex in the playerhandler to the skinIndex in the customisation script
            player.skinIndex = skinIndex;
            //set the hairIndex in the playerhandler to the hairIndex in the customisation script
            player.hairIndex = hairIndex;
            //set the armourIndex in the playerhandler to the armourIndex in the customisation script
            player.armourIndex = armourIndex;
            //set the mouthIndex in the playerhandler to the mouthIndex in the customisation script
            player.mouthIndex = mouthIndex;
            //set the clothesIndex in the playerhandler to the clothesIndex in the customisation script
            player.clothesIndex = clothesIndex;
            //set the eyesIndex in the playerhandler to the eyesIndex in the customisation script
            player.eyesIndex = eyesIndex;
            //set the characterClass in the playerhandler to the charClass in the customisation script
            player.characterClass = charClass;
            //set the chracterRace in the playerhandler to the charRace in the customisation script
            player.characterRace = charRace;
            //set the characterName in the playerhandler to the text of the input field in the customisation script
            player.characterName = NameCharacter.text;
            //set the stats values in the playerhandler to the statvalue plus the tempstat in the playerStats in the customisation script
            for (int i = 0; i < playerStats.Length; i++)
            {
                player.stats[i].value = (playerStats[i].statValue + playerStats[i].tempStat);
            }
            //save it to a particular savefile
            saveNew.Save();
            //change scene to the main scene
            SceneManager.LoadScene(2);
        }
    }
    //create a function that updates automaticially
    public void Update()
    {
        //characterName = NameCharacter.text; 
}
    // is used to save your indexes you sent
    //create a function that changes the texture on the model based on type and how much
    public void SetTexture(string type, int dir)
    {

        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        switch (type)
        {
            //when the skin changes alter the texture of the resources in skin to another based on the value
            case "Skin":
                index = skinIndex;
                max = skinMax;
                matIndex = 1;
                textures = skin.ToArray();
                break;
            //when the eyes changes alter the texture of the resources in eyes to another based on the value
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                matIndex = 2;
                textures = eyes.ToArray();
                break;
            //when the mouth changes alter the texture of the resources in mouth to another based on the value
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                matIndex = 3;
                textures = mouth.ToArray();
                break;
            //when the hair changes alter the texture of the resources in skin to another base on the value
            case "Hair":
                index = hairIndex;
                max = hairMax;
                matIndex = 4;
                textures = hair.ToArray();
                break;
            //when the clothes changes alter the texture of the resources in clothes to another based on the value
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                matIndex = 5;
                textures = clothes.ToArray();
                break;
            //when the armour changes alter the texture of the resources in armour to another based on the value
            case "Armour":
                index = armourIndex;
                max = armourMax;
                matIndex = 6;
                textures = armour.ToArray();
                break;
                //allows you changes to the code affect the 
        }
        index += dir;
        //if the value goes over it max loop it back around to the beginning
        if (index < 0)
        {
            index = max - 1;
        }
        //if the value goes under a 0 loop it back around to 1 below max
        if (index > max - 1)
        {
            index = 0;
        }
// these allow the code to loop around
    

        Material[] mat = characterRenderer.materials;
        mat[matIndex].mainTexture = textures[index];
        characterRenderer.materials = mat;
        //deiginate the new value of the index to the index so you can change it again
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
    //create a function that accesses the SetTexturefunction and change the skin back by one
    public void MinusSkin()
    {
        SetTexture("Skin", -1);
    }
    // press the button to change skin back by one
    //create a function that accesses the SetTexturefunction and change the skin forward by one
    public void PlusSkin()
    {
        SetTexture("Skin", 1);
    }
    // press the button to change skin forward by one
    //create a function that accesses the SetTexturefunction and change the eyes back by one
    public void MinusEyes()
    {
        SetTexture("Eyes", -1);
    }
    // press the button to change eyes back by one
    //create a function that accesses the SetTexturefunction and change the eyes forward by one
    public void PlusEyes()
    {
        SetTexture("Eyes", 1);
    }
    // press the button to change eyes forward by one
    //create a function that accesses the SetTexturefunction and change the mouth back by one
    public void MinusMouth()
    {
        SetTexture("Mouth", -1);
    }
    // press the button to change mouth back by one
    //create a function that accesses the SetTexturefunction and change the mouth forward by one
    public void PlusMouth()
    {
        SetTexture("Mouth", 1);
    }
    // press the button to change mouth forward by one
    //create a function that accesses the SetTexturefunction and change the hair back by one
    public void MinusHair()
    {
        SetTexture("Hair", -1);
    }
    // press the button to change hair back by one
    //create a function that accesses the SetTexturefunction and change the hair forward by one
    public void PlusHair()
    {
        SetTexture("Hair", 1);
    }
    // press the button to change hair forward by one
    //create a function that accesses the SetTexturefunction and change the clothes back by one
    public void MinusClothes()
    {
        SetTexture("Clothes", -1);
    }
    // press the button to change clothes back by one
    //create a function that accesses the SetTexturefunction and change the clothes forward by one
    public void PlusClothes()
    {
        SetTexture("Clothes", 1);
    }
    // press the button to change clothes forward by one
    //create a function that accesses the SetTexturefunction and change the armour back by one
    public void MinusArmour()
    {
        SetTexture("Armour", -1);
    }
    // press the button to change armour back by one
    //create a function that accesses the SetTexturefunction and change the armour forward by one
    public void PlusArmour()
    {
        SetTexture("Armour", 1);
    }
    // press the button to change armour forward by one
    //create a function that accesses the SetTexturefunction multiple times and set all the indexes to a random value
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
    //create a function that accesses the SetTexturefunction and change all indexes back to the first value
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

    //create a function that alter the selectedIndex of the class and the text displaying it by one back
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
    //create a function that alter the selectedIndex of the class and the text displaying it by one forward
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
    //create a function that alter the Indexselected of the race and the text displaying it by one back
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
    //create a function that alter the Indexselected of the race and the text displaying it by one forward
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
    //create a function that increase the tempstats based on the index, decrease the points and alters the texts to reflect it
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
    //create a function that decrease the tempstats based on the index, increase the points and alters the text to reflect it
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

    //create a function that gives stats based on what classID is and thus what class it shows it is
    void ChooseClass(int classID)
	{
		if(classID < 0)
		{
			
		}
	switch(classID)
	{
            //give fighter class high strength and constuition
		case 0:
		playerStats[0].statValue = 8;
		playerStats[1].statValue = 5;
		playerStats[2].statValue = 9;
		playerStats[3].statValue = 3;
		playerStats[4].statValue = 2;
		playerStats[5].statValue = 3;
		charClass = CharacterClass.Fighter;
		break;
                //give mage high intelligence and wisdom
		case 1:
		playerStats[0].statValue = 1;
		playerStats[1].statValue = 2;
		playerStats[2].statValue = 6;
		playerStats[3].statValue = 9;
		playerStats[4].statValue = 8;
		playerStats[5].statValue = 4;
		charClass = CharacterClass.Mage;
		break;
                //give thief high dexterity and charsima
		case 2:
		playerStats[0].statValue = 4;
		playerStats[1].statValue = 9;
		playerStats[2].statValue = 5;
		playerStats[3].statValue = 3;
		playerStats[4].statValue = 1;
		playerStats[5].statValue = 8;
		charClass = CharacterClass.Thief;
		break;
                //give Normy average in everything
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
    //create a function that gives stats based on what raceID is and thus what race it shows it is
    void ChooseRace(int raceID)
	{
		if(raceID < 0)
		{
			
		}
	switch(raceID)
	{
            //give elf a high strength stat
		case 0:
		playerStats[0].statValue = 8;
		playerStats[1].statValue = 2;
		playerStats[2].statValue = 5;
		playerStats[3].statValue = 5;
		playerStats[4].statValue = 2;
		playerStats[5].statValue = 4;
		charRace = CharacterRace.Elf;
		break;
                //give dwarf very middling stats
		case 1:
		playerStats[0].statValue = 4;
		playerStats[1].statValue = 5;
		playerStats[2].statValue = 6;
		playerStats[3].statValue = 3;
		playerStats[4].statValue = 5;
		playerStats[5].statValue = 3;
		charRace = CharacterRace.Dwarf;
		break;
                //give human high stats in dexterity/ intelligence/ wisdom and charisma
		case 2:
		playerStats[0].statValue = 5;
		playerStats[1].statValue = 9;
		playerStats[2].statValue = 5;
		playerStats[3].statValue = 9;
		playerStats[4].statValue = 8;
		playerStats[5].statValue = 8;
		charRace = CharacterRace.Human;
		break;
                //give undead bad stats for wisdom (not very  perceptive) and strength (no muscles) but high constuition (hard to kill what's already dead)
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
//set a group of different possible classes
public enum CharacterClass
    {
        Fighter,
        Mage,
        Thief,
        Normy
    }
//set a group of different possible races

    public enum CharacterRace
    {
        Elf,
        Dwarf,
        Human,
        Undead

    }
