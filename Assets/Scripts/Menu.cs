using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Button StartButton;
    public Button ExitButton;
    public Slider MusicSlider;
    public Slider SoundSlider;

 
    void Start()
    {
        SetSound();





        if (PlayerPrefs.HasKey("CurrentLevel"))
            SaveLoad.saveLoad.CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
        else
            SaveLoad.saveLoad.CurrentLevel = 0;

        StartButton.onClick.AddListener(delegate { MenuScenes("Level_"+ SaveLoad.saveLoad.CurrentLevel); });
        ExitButton.onClick.AddListener(delegate { Exit(); });

    }



    public void MenuScenes(string numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }

    public void Exit()
    {
        Application.Quit();
    }





    void SetSound()
    {
        if (!PlayerPrefs.HasKey("MusicVolum"))
            MusicSlider.value = 0.5f;
        else
            MusicSlider.value = PlayerPrefs.GetFloat("MusicVolum");
        Sound.sound.SetMusicVolume(MusicSlider.value);
        MusicSlider.onValueChanged.AddListener(delegate { Sound.sound.SetMusicVolume(MusicSlider.value); });

        if (!PlayerPrefs.HasKey("SoundVolum"))
            SoundSlider.value = 0.5f;
        else
            SoundSlider.value = PlayerPrefs.GetFloat("SoundVolum");
        Sound.sound.SetSoundVolume(SoundSlider.value);
        SoundSlider.onValueChanged.AddListener(delegate { Sound.sound.SetSoundVolume(SoundSlider.value); });
    }

}
