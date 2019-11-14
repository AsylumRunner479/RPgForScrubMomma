[System.Serializable]
/*
 Serialization is the automatic process of transforming data 
 structures or object states into a format that Unity can store and reconstruct later.

Serialization is the process of converting an object 
into a stream of bytes to store the object or transmit it to memory,
a database, or a file. Its main purpose is to save the state of an
object in order to be able to recreate it when needed. 
The reverse process is called deserialization

The serialization system is written in C++
*/
public class PlayerDataToSave
{
    //Data....Get from Game
    public string playerName;
    public int level;
    public string checkPoint;
    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float posX, posY, posZ;
    public float rotX, rotY, rotZ, rotW;

    public static int saveSlot;
    public int[] stats = new int[6];
    public int classIndex;
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public PlayerDataToSave(PlayerHandler player)
    {
        playerName = player.characterName;
        level = 0;
        if (player.curCheckPoint != null)
        {
            checkPoint = player.curCheckPoint.name;
            posX = player.transform.position.x;
            posY = player.transform.position.y;
            posZ = player.transform.position.z;

            rotX = player.transform.rotation.x;
            rotY = player.transform.rotation.y;
            rotZ = player.transform.rotation.z;
            rotW = player.transform.rotation.w;
        }
        else
        {
            checkPoint = player.firstCheckPointName;
            posX = 0;
            posY = 0;
            posZ = 0;
        }
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = player.curStamina;

        for (int i = 0; i < 6; i++)
        {
            stats[i] = player.stats[i].value;
        }

        skinIndex = player.skinIndex;
        hairIndex = player.hairIndex;
        mouthIndex = player.mouthIndex;
        eyesIndex = player.eyesIndex;
        clothesIndex = player.clothesIndex;
        armourIndex = player.armourIndex;

        classIndex = (int)player.characterClass;
    }
}
