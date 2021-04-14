using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Paus : MonoBehaviour
{
    public GameObject paus;
    public GameObject preExit;
    public GameObject spawnAsteroid;
    public GameObject swipe;
    public GameObject gun;
    public GameObject help;
    public void StartLevel()
    {
        swipe.SetActive(true);
        //gun.SetActive(true);
    }

    public void StartMenuPaus()
    {
        help.SetActive(false);
        swipe.SetActive(false);
        //gun.SetActive(false);
        paus.SetActive(true);
        Time.timeScale = 0f;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().ResetLevel();

    }
    public void Play()
    {
        swipe.SetActive(true);
        paus.SetActive(false);
        Time.timeScale = 1f;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().StartLevel();
    }
    public void PreExit()
    {
        if (!preExit.activeSelf)
        {
            preExit.SetActive(true);
            paus.SetActive(false);
        }
        else
        {
            preExit.SetActive(false);
            paus.SetActive(true);
        }
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        OverMenu.cost = HudScr.coinCounter;
        spawnAsteroid.GetComponent<SpawnAsteroid>().ResetLevel();
        preExit.SetActive(false);
        GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().ExitGame();
    }

    public void SoundClick()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Click").GetComponent<AudioSource>().Play();
        }
    }
}
