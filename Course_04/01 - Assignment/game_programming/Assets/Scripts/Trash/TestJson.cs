using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


[Serializable]
class DiceSaveData
{
    public int nrOfPlayers;
    public int nrOfDiceLeft;
    public int[] rolledDice;
}
public class TestJson : MonoBehaviour
{
    string fileName;
    Vector3 playerPosition;
    
    public BoardCalculator boardCalculator;




    public void Save()
    {
        //Create our saveData object
        DiceSaveData saveData = new DiceSaveData();

        //Put our data in our object
        saveData.nrOfPlayers = 2;
        saveData.nrOfDiceLeft = 6;
        saveData.rolledDice = new int[saveData.nrOfDiceLeft];

        for (int i = 0; i < saveData.nrOfDiceLeft; i++)
        {
            saveData.rolledDice[i] = boardCalculator.diceOnBoard[i];
        }


        //Convert saveData object to JSON
        string jsonString = JsonUtility.ToJson(saveData);


        // save it using PlayerPrefs
        //  PlayerPrefs.SetString("PlayerSaveData", jsonString);


        SaveToFile("saveData.json", jsonString);
    }

    public void SaveToFile(string fileName, string jsonString)
    {
        // Open a file in write mode. This will create the file if it's missing.
        // It is assumed that the path already exists.
        using (var stream = File.OpenWrite(fileName))
        {
            // Truncate the file if it exists (we want to overwrite the file)
            stream.SetLength(0);

            // Convert the string into bytes. Assume that the character-encoding is UTF8.
            // Do you not know what encoding you have? Then you have UTF-8
            var bytes = Encoding.UTF8.GetBytes(jsonString);

            // Write the bytes to the hard-drive
            stream.Write(bytes, 0, bytes.Length);

            // The "using" statement will automatically close the stream after we leave
            // the scope - this is VERY important
        }
    }

    public void Load()
    {
        //Get the saved jsonString
        // string jsonString = PlayerPrefs.GetString("PlayerSaveData");




        string jsonString = LoadFromFile("saveData.json");

        //Convert the data to a object
        DiceSaveData loadedData = JsonUtility.FromJson<DiceSaveData>(jsonString);

        //We probably would like to add some code in this function
        //that runs if we get broken or no data.
        if (loadedData != null)
        {
            //LoL
            playerPosition.x = loadedData.nrOfPlayers;
        }
    }

    public string LoadFromFile(string fileName)
    {
        // Open a stream for the supplied file name as a text file
        using (var stream = File.OpenText(fileName))
        {
            // Read the entire file and return the result. This assumes that we've written the
            // file in UTF-8
            return stream.ReadToEnd();
        }
    }
}
