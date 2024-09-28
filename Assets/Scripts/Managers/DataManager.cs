using DG.Tweening.Plugins.Core.PathCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public enum ItemType
{
    book,
    hammer,
    health,
    poison,
    speed,    
}

[Serializable]
public class Data
{
    public int health;
    public int power;
    public int stamina;
    public int wisdom;

    public int[] quantityItems;
    public ItemType[] itemTypes;

    public Data() : base()
    {
        health = 100;
        power = 5;
        stamina = 5;
        wisdom = 5;

        quantityItems = new int[10];
        itemTypes = new ItemType[10];
    }
}

public class DataManager : MonoBehaviour
{
    public Data data;

    string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "save.gamesave";

        if (File.Exists(filePath) == true)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new(filePath, FileMode.Open);
            data = (Data)bf.Deserialize(fs);
            fs.Close();
        }

        //DeleteData();

    }
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new(filePath, FileMode.Create);

        bf.Serialize(fs, data);
        fs.Close();
    }
    public void DeleteData()
    {
        File.Delete(filePath);
    }
}
