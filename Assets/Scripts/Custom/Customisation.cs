using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customisation : MonoBehaviour
{
    public Renderer characterRenderer;
    public List<Texture2D> skin = new List<Texture2D>();
	public List<Texture2D> mouth = new List<Texture2D>();
	public List<Texture2D> hair = new List<Texture2D>();
	public List<Texture2D> clothes = new List<Texture2D>();
	public List<Texture2D> armour = new List<Texture2D>();
	public List<Texture2D> eyes = new List<Texture2D>();
	public int skinIndex, eyesIndex, armourIndex, hairIndex, clothesIndex, mouthIndex;
	public int skinMax, eyesMax, armourMax, hairMax, clothesMax, mouthMax;
	public string characterName = "Adventurer";
	[System.Serializable]
	
    // Start is called before the first frame update
    public struct Stats
	{
		public string statName;
		public int statIndex;
		public int tempStat;
	}
	public Stats[] playerStats = new Stats[6];
	public CharacterClass characterClass;
	public string[] text;
	public int index;
	public Vector2 scr;
	void Start()
    {
		
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
		
	}
	void Buttons(string type, int dir)
	{
		
	}
	void DisplayStats()
	{
		
	}
	public enum CharacterClass
	{
		Fighter,
		Mage,
		Thief,
		Cleric,
		Bard
	}
}
