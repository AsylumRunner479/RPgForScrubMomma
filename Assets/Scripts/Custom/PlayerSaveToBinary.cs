using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerSaveToBinary 
{
    //create a public static function called SavePlayerData that uses the playerHandler
    public static void SavePlayerData(PlayerHandler player)
   {
       //create a Binary formatter called formatter
        //Reference a Binary Formatter
       BinaryFormatter formatter = new BinaryFormatter();
       //Location to Save
       //create a string called path and set it to a persistentDataPath in application with a saveSlot in PlayerDataToSave
       string path = Application.persistentDataPath + "/" + PlayerDataToSave.saveSlot;
       //Create a file path
       // create FileStream called stream and set it to the path and create a file
       FileStream stream = new FileStream(path, FileMode.Create);
       //What Data to write to the file
       //create a PlayerDataToSave called data and create new playerDataToSave
       PlayerDataToSave data = new PlayerDataToSave(player);
       //write it and convert to bytes for writing to binary
       //use the formatter to serialize the stream and data
       formatter.Serialize(stream, data);
       //Ending
       //close the stream
       stream.Close();
   }
    //create a public static function called LoadData that uses the PlayerHandler
    public static PlayerDataToSave LoadData(PlayerHandler player)
    {
        //Location to Save
        //set the path to the persistentDatapath with the correct saveSlot
        string path = Application.persistentDataPath + "/" + PlayerDataToSave.saveSlot;
        //If we have the file at that path
        //if there is a File in that path then
        //set formatter to the file
        //set stream to the FileStream and open the FileMode in the path 
        //set the data to formatter and deserialise the stream to the PlayerDataToSave
        //close the stream
        if (File.Exists(path))
        {
            //get our Binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //and reat the data
            FileStream stream = new FileStream(path, FileMode.Open);
            //set the data from what it is back to usable variables
            PlayerDataToSave data = formatter.Deserialize(stream) as PlayerDataToSave;
            //Ending
            stream.Close();
            //Send usable data back to the PLayerDataSave Script
            return data;
        }
        else
        {
            return null;
        }
    }
}
