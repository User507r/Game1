using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{

    public static SaveLoad saveLoad;

    public int CurrentLevel;


    private void Awake()
    {
        if (saveLoad == null)
        {
            saveLoad = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    public void NextLevel() 
    {
        CurrentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
        SceneManager.LoadScene("Level_" + SaveLoad.saveLoad.CurrentLevel);
    }


    public void Reset() 
    {
        PlayerPrefs.DeleteAll();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.F1)) Reset();
    }
}
