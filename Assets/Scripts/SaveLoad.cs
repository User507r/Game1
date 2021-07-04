using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{

    public static SaveLoad saveLoad;

    public float SoundVolume = 0.5f;
    public List<int> MapDoneList = new List<int>();


    private void Awake()
    {
        saveLoad = this;
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            MapDoneList.Add(0);
        }

        Load();

        //MapList.mapList.SetList();
    }

    public void SaveMapStatus ( int index, int status)
    {
        MapDoneList[index] = status;
        Save();
    }


    public void Save()
    {
        PlayerPrefs.SetFloat("SoundVolume", SoundVolume);
        int count = 0;
        MapDoneList.ForEach( map =>
        {
            map = Random.Range(0,2);
            PlayerPrefs.SetInt(count.ToString(), map);
            count++;
        });



        PlayerPrefs.Save();
    
    }

    public void Load()
    {
        
        SoundVolume = PlayerPrefs.GetFloat("SoundVolume");

        MapDoneList = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            MapDoneList.Add(PlayerPrefs.GetInt(i.ToString()));
            Debug.Log(i+"     "+PlayerPrefs.GetInt(i.ToString()));
        }
    }


}
