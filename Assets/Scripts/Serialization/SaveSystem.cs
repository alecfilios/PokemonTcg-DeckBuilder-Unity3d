using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;



// thank you Brackeys
public static class SaveSystem
{
    public static void SaveData(List<GameObject> deckList)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/card.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        CardData data = new CardData(deckList);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CardData LoadData()
    {
        string path = Application.persistentDataPath + "/card.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CardData data =  formatter.Deserialize(stream) as CardData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
