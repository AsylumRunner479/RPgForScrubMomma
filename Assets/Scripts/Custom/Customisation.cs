using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Customisation : MonoBehaviour
{
    public Renderer characterRenderer;
    public List<Texture2D> skin = new List<Texture2D>();
	public List<Texture2D> mouth = new List<Texture2D>();
	public List<Texture2D> hair = new List<Texture2D>();
	public List<Texture2D> clothes = new List<Texture2D>();
	public List<Texture2D> armour = new List<Texture2D>();
	public List<Texture2D> eyes = new List<Texture2D>();
	public static int skinIndex, eyesIndex, armourIndex, hairIndex, clothesIndex, mouthIndex;
	public int skinMax, eyesMax, armourMax, hairMax, clothesMax, mouthMax;
	public static string characterName = "Adventurer";
  
	[System.Serializable]
	
    // Start is called before the first frame update
    public struct PlayerStats
	{
		public string statName;
		public int statValue;
		public int tempStat;
	};
	public static PlayerStats[] playerStats = new Stats[6];
	public static  CharacterClass charClass;
	public string[] text;
	public int index;
	public Vector2 scr;
	public static int selectedIndex, points;
  
    void Start()
    {
		points = 10;
        for	(int i = 0; i < mouthMax; i++)
		{
			Texture2D tempTexture = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
			mouth.Add(tempTexture);
		}
		for	(int i = 0; i < skinMax; i++)
		{
			Texture2D tempTexture = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
			skin.Add(tempTexture);
		}
		for	(int i = 0; i < hairMax; i++)
		{
			Texture2D tempTexture = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
			hair.Add(tempTexture);
		}
		for	(int i = 0; i < clothesMax; i++)
		{
			Texture2D tempTexture = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
			clothes.Add(tempTexture);
		}
		for	(int i = 0; i < armourMax; i++)
		{
			Texture2D tempTexture = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
			armour.Add(tempTexture);
		}
		for	(int i = 0; i < eyesMax; i++)
		{
			Texture2D tempTexture = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
			eyes.Add(tempTexture);
		}
		SetTexture("Skin", 0);
		SetTexture("Mouth", 0);
		SetTexture("Hair", 0);
		SetTexture("Clothes", 0);
		SetTexture("Armour", 0);
		SetTexture("Skin", 0);
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Save()
	{
		
	}
	public void SetTexture(string type, int dir)
	{
		int index = 0, max = 0, matIndex = 0;
		Texture2D[] textures = new Texture2D[0];
		switch(type)
		{
			case "Skin":
			index = skinIndex;
			max = skinMax;
			matIndex = 1;
			textures = skin.ToArray();
			break;
			case "Clothes":
			index = clothesIndex;
			max = clothesMax;
			matIndex = 5;
			textures = clothes.ToArray();
			break;
			case "Eyes":
			index = eyesIndex;
			max = eyesMax;
			matIndex = 2;
			textures = eyes.ToArray();
			break;
			case "Armour":
			index = armourIndex;
			max = armourMax;
			matIndex = 6;
			textures = armour.ToArray();
			break;
			case "Hair":
			index = hairIndex;
			max = hairMax;
			matIndex = 4;
			textures = hair.ToArray();
			break;
			case "Mouth":
			index = mouthIndex;
			max = mouthMax;
			matIndex = 3;
			textures = mouth.ToArray();
			break;
			
		}
		index += dir;
			if(index < 0)
			{
				index = max - 1;
			}
			if(index > max-1)
			{
				index = 0;
			}
			Material[] mat = characterRenderer.materials;
			mat[matIndex].mainTexture = textures[index];
			characterRenderer.materials = mat;
			switch(type)
		{
			case "Skin":
			skinIndex = index;
			
			break;
			case "Clothes":
			clothesIndex = index;

			break;
			case "Eyes":
			eyesIndex = index;
			
			break;
			case "Armour":
			armourIndex = index;
			
			break;
			case "Hair":
			hairIndex = index;
			
			break;
			case "Mouth":
			mouthIndex = index;
			
			break;
			
		}
	}
	private void OnGUI()
	{
		scr = new Vector2(Screen.width / 16, Screen.height / 9);
		DisplayCustom();
		DisplayStats();
	}
	void DisplayCustom()
	{
		
		int i = 0;
		if (GUI.Button(new Rect(scr.x * 0.25f,scr.y *(1 + i * 0.5f),scr.x * 0.5f,scr.y * 0.5f), "<"))
		{
			SetTexture("Skin",-1);
		}
		GUI.Button(new Rect(scr.x * 0.75f,scr.y *(1 + i * 0.5f),scr.x,scr.y * 0.5f), "Skin");
		if (GUI.Button(new Rect(scr.x * 1.75f,scr.y + i * (0.5f*scr.y),scr.x * 0.5f,scr.y * 0.5f), ">"))
		{
			SetTexture("Skin",1);
		}
		i++;
		if (GUI.Button(new Rect(scr.x * 0.25f,scr.y *(1 + i * 0.5f),scr.x * 0.5f,scr.y * 0.5f), "<"))
		{
			SetTexture("Mouth",-1);
		}
		GUI.Button(new Rect(scr.x * 0.75f,scr.y *(1 + i * 0.5f),scr.x,scr.y * 0.5f), "Mouth");
		if (GUI.Button(new Rect(scr.x * 1.75f,scr.y + i * (0.5f*scr.y),scr.x * 0.5f,scr.y * 0.5f), ">"))
		{
			SetTexture("Mouth",1);
		}
		i++;
		if (GUI.Button(new Rect(scr.x * 0.25f,scr.y *(1 + i * 0.5f),scr.x * 0.5f,scr.y * 0.5f), "<"))
		{
			SetTexture("Hair",-1);
		}
		GUI.Button(new Rect(scr.x * 0.75f,scr.y *(1 + i * 0.5f),scr.x,scr.y * 0.5f), "Hair");
		if (GUI.Button(new Rect(scr.x * 1.75f,scr.y + i * (0.5f*scr.y),scr.x * 0.5f,scr.y * 0.5f), ">"))
		{
			SetTexture("Hair",1);
		}
		i++;
		if (GUI.Button(new Rect(scr.x * 0.25f,scr.y *(1 + i * 0.5f),scr.x * 0.5f,scr.y * 0.5f), "<"))
		{
			SetTexture("Clothes",-1);
		}
		GUI.Button(new Rect(scr.x * 0.75f,scr.y *(1 + i * 0.5f),scr.x,scr.y * 0.5f), "Clothes");
		if (GUI.Button(new Rect(scr.x * 1.75f,scr.y + i * (0.5f*scr.y),scr.x * 0.5f,scr.y * 0.5f), ">"))
		{
			SetTexture("Clothes",1);
		}
		i++;
		if (GUI.Button(new Rect(scr.x * 0.25f,scr.y *(1 + i * 0.5f),scr.x * 0.5f,scr.y * 0.5f), "<"))
		{
			SetTexture("Armour",-1);
		}
		GUI.Button(new Rect(scr.x * 0.75f,scr.y *(1 + i * 0.5f),scr.x,scr.y * 0.5f), "Armour");
		if (GUI.Button(new Rect(scr.x * 1.75f,scr.y + i * (0.5f*scr.y),scr.x * 0.5f,scr.y * 0.5f), ">"))
		{
			SetTexture("Armour",1);
		}
		i++;
		if (GUI.Button(new Rect(scr.x * 0.25f,scr.y *(1 + i * 0.5f),scr.x * 0.5f,scr.y * 0.5f), "<"))
		{
			SetTexture("Eyes",-1);
		}
		GUI.Button(new Rect(scr.x * 0.75f,scr.y *(1 + i * 0.5f),scr.x,scr.y * 0.5f), "Eyes");
		if (GUI.Button(new Rect(scr.x * 1.75f,scr.y + i * (0.5f*scr.y),scr.x * 0.5f,scr.y * 0.5f), ">"))
		{
			SetTexture("Eyes",1);
		}
		i++;
		if (GUI.Button(new Rect(scr.x * 0.75f,scr.y + i * (0.5f*scr.y),scr.x,scr.y * 0.5f), "Random"))
		{
			SetTexture("Eyes",Random.Range(0,3));
			SetTexture("Skin",Random.Range(0,3));
			SetTexture("Armour",Random.Range(0,10));
			SetTexture("Hair",Random.Range(0,4));
			SetTexture("Clothes",Random.Range(0,10));
			SetTexture("Mouth",Random.Range(0,2));
		}
		i++;
		if (GUI.Button(new Rect(scr.x * 0.75f,scr.y + i * (0.5f*scr.y),scr.x,scr.y * 0.5f), "Default"))
		{
			SetTexture("Eyes",4);
			SetTexture("Skin",4);
			SetTexture("Armour",11);
			SetTexture("Hair",5);
			SetTexture("Clothes",11);
			SetTexture("Mouth",3);
		}
		i++;
        

    }
	
	void DisplayStats()
	{
	characterName = GUI.TextField(new Rect(scr.x * 2f,scr.y * 6.5f,scr.x * 12,scr.y * 0.5f), characterName, 42);
	#region StatDistribution
	int i = 0;
	if (GUI.Button(new Rect(scr.x * 13.75f,scr.y *(1 + i * 0.5f),scr.x * 0.5f,scr.y * 0.5f), "<"))
		{
			selectedIndex--;
			if(selectedIndex < 0)
			{
				selectedIndex = 3;
			}
			ChooseClass(selectedIndex);
		}
		GUI.Button(new Rect(scr.x * 14.25f,scr.y *(1 + i * 0.5f),scr.x,scr.y * 0.5f), charClass.ToString());
		if (GUI.Button(new Rect(scr.x * 15.25f,scr.y + i * (0.5f*scr.y),scr.x * 0.5f,scr.y * 0.5f), ">"))
		{
			selectedIndex++;
			if(selectedIndex > 3)
			{
				selectedIndex = 0;
			}
			ChooseClass(selectedIndex);
		}
		i++;
		GUI.Button(new Rect(scr.x * 14.25f,scr.y *(1 + i * 0.5f),scr.x * 2,scr.y * 0.5f), "Points: " + points);
		for (int s = 0; s < playerStats.Length; s++)
		{
			if(points > 0 && playerStats[s].tempStat < 10)
			{
				if(GUI.Button(new Rect(scr.x * 14.25f,scr.y *(3 + s * 0.5f),scr.x/2,scr.y * 0.5f),  "+"))
				{
					points--;
					playerStats[s].tempStat++;
				}
			}
			GUI.Button(new Rect(scr.x * 12.25f,scr.y *(3 + s * 0.5f),scr.x * 2,scr.y * 0.5f), playerStats[s].statName + ": "+(playerStats[s].statValue+playerStats[s].tempStat));
		if(points < 10  && playerStats[s].tempStat > -10)
			{
				if(GUI.Button(new Rect(scr.x * 11.75f,scr.y *(3 + s * 0.5f),scr.x/2,scr.y * 0.5f),  "-"))
				{
					points++;
					playerStats[s].tempStat--;
				}
			}
		}
        if (GUI.Button(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Save"))
        {
            PlayerDataToSave.Save();
        }
        i++;
        if (GUI.Button(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Load"))
        {
            /*PlayerData data = PlayerSaveToBinary.LoadData();
            skinIndex = data.skinIndex;
            eyesIndex = data.eyesIndex;
            armourIndex = data.armourIndex;
            hairIndex = data.hairIndex;
            clothesIndex = data.clothesIndex;
            mouthIndex = data.mouthIndex;
            stats = new int[6];
            stats[0] = data.playerStats[0].statValue;
            stats[1] = data.playerStats[1].statValue;
            stats[2] = data.playerStats[2].statValue;
            stats[3] = data.playerStats[3].statValue;
            stats[4] = data.playerStats[4].statValue;
            stats[5] = data.playerStats[5].statValue;
            className = data.className;
            points = data.points;
            character = player.characterName;*/
        }
        i++;
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
