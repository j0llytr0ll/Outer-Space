//using AndroidAudioBypass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject panels;
    public GameObject[] music;
    public GameObject[] sound;
    public GameObject[] vibration;
    public GameObject[] language;
    public Text[] languageText;
    public GameObject game;

    public static string musicStats;
    public static string soundStats;
    public static string vibrationStats;
    public static string languageStats;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("MusicStats"))
        {
            musicStats = "true";
            PlayerPrefs.SetString("MusicStats", musicStats);
        }

        if (!PlayerPrefs.HasKey("SoundStats"))
        {
            soundStats = "true";
            PlayerPrefs.SetString("SoundStats", soundStats);
        }

        if (!PlayerPrefs.HasKey("VibrationStats"))
        {
            vibrationStats = "true";
            PlayerPrefs.SetString("VibrationStats", vibrationStats);
        }

        if (!PlayerPrefs.HasKey("LanguageStat"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
            {
                languageStats = "ru";
                PlayerPrefs.SetString("LanguageStat", languageStats);
            }
            else
            {
                languageStats = "us";
                PlayerPrefs.SetString("LanguageStat", languageStats);
            }

        }

    }

    private void Start()
    {
        AwakeMusic();
        AwakeSound();
        AwakeVibration();
        AwakeLanguage();
    }
    public void OnButton()
    {
        if (!panels.activeSelf)
        {
            panels.SetActive(true);
        }
        else
        {
            panels.SetActive(false);
        }
    }

    private void AwakeMusic()
    {
        musicStats = PlayerPrefs.GetString("MusicStats");
        if (musicStats == "true")
        {
            music[0].SetActive(true);
            music[1].SetActive(true);
        }
        else if (musicStats == "false")
        {
            music[2].SetActive(true);
            music[3].SetActive(true);
        }

    }
    public void OnMusic()
    {
        if (musicStats == "true")
        {
            music[0].SetActive(false);
            music[1].SetActive(false);
            music[2].SetActive(true);
            music[3].SetActive(true);
            musicStats = "false";
            GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().OffOption();
        }
        else if (musicStats == "false")
        {
            music[0].SetActive(true);
            music[1].SetActive(true);
            music[2].SetActive(false);
            music[3].SetActive(false);
            musicStats = "true";
            GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().OnOption();
        }
        PlayerPrefs.SetString("MusicStats", musicStats);
    }

    private void AwakeSound()
    {
        soundStats = PlayerPrefs.GetString("SoundStats");
        if (soundStats == "true")
        {
            sound[0].SetActive(true);
            sound[1].SetActive(true);
        }
        else if (soundStats == "false")
        {
            sound[2].SetActive(true);
            sound[3].SetActive(true);
        }

    }
    public void OnSound()
    {
        if (soundStats == "true")
        {
            sound[0].SetActive(false);
            sound[1].SetActive(false);
            sound[2].SetActive(true);
            sound[3].SetActive(true);
            soundStats = "false";           
            SoundStopEngineShip();
        }
        else if (soundStats == "false")
        {
            sound[0].SetActive(true);
            sound[1].SetActive(true);
            sound[2].SetActive(false);
            sound[3].SetActive(false);
            soundStats = "true";
            if (game.activeSelf)
            {
                SoundStartEngineShip();
            }
        }
        PlayerPrefs.SetString("SoundStats", soundStats);

    }

    private void AwakeVibration()
    {
        vibrationStats = PlayerPrefs.GetString("VibrationStats");
        if (vibrationStats == "true")
        {
            vibration[0].SetActive(true);
            vibration[1].SetActive(true);
        }
        else if (vibrationStats == "false")
        {
            vibration[2].SetActive(true);
            vibration[3].SetActive(true);
        }
            

    }
    public void OnVibration()
    {
        if (vibrationStats == "true")
        {
            vibration[0].SetActive(false);
            vibration[1].SetActive(false);
            vibration[2].SetActive(true);
            vibration[3].SetActive(true);
            vibrationStats = "false";
        }
        else if (vibrationStats == "false")
        {
            vibration[0].SetActive(true);
            vibration[1].SetActive(true);
            vibration[2].SetActive(false);
            vibration[3].SetActive(false);
            vibrationStats = "true";
        }
        PlayerPrefs.SetString("VibrationStats", vibrationStats);

    }

    private void AwakeLanguage()
    {
        languageStats = PlayerPrefs.GetString("LanguageStat");
        if (languageStats == "ru")
        {            
            language[0].GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
            language[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            languageText[0].color = new Color(0.7f, 0.7f, 0.7f, 1);
            languageText[1].color = new Color(1, 1, 1, 1);
        }
        else if (languageStats == "us")
        {
            language[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            language[1].GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
            languageText[0].color = new Color(1, 1, 1, 1);
            languageText[1].color = new Color(0.7f, 0.7f, 0.7f, 1);
        }

    }

    public void OnLanguageRu()
    {
        language[0].GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
        language[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        languageText[0].color = new Color(0.7f, 0.7f, 0.7f, 1);
        languageText[1].color = new Color(1, 1, 1, 1);
        languageStats = "ru";
        PlayerPrefs.SetString("LanguageStat", languageStats);
        OnButton();

    }
    public void OnLanguageUS()
    {
        language[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        language[1].GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
        languageText[0].color = new Color(1, 1, 1, 1);
        languageText[1].color = new Color(0.7f, 0.7f, 0.7f, 1);
        languageStats = "us";
        PlayerPrefs.SetString("LanguageStat", languageStats);
        OnButton();
    }


    private void SoundStartEngineShip()
    {
        GameObject.FindGameObjectWithTag("AudioController_EngineShip").GetComponent<AudioSource>().Play();
    }

    private void SoundStopEngineShip()
    {
        GameObject.FindGameObjectWithTag("AudioController_EngineShip").GetComponent<AudioSource>().Stop();
    }
}
