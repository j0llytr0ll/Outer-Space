using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GemaeOverPanel : MonoBehaviour
{
    public Text startSec;
    public GameObject textSec;
    public GameObject[] hud;
    public GameObject visibleBoost;
    public GameObject top;

    public GameObject spawnAsteroid;
    public GameObject hudScr;

    public GameObject overMenu;
    public GameObject noKeyPanel;
    public GameObject noKeyPanelNoAds;

    public GameObject gameOver;
    



    public void RestartLevel()
    {
        StartCoroutine(OnGame());
    }
    IEnumerator OnGame()
    {
        gameOver.GetComponent<OverMenu>().TapEndGameOff();
        textSec.SetActive(true);
        startSec.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(0);
        for (int i = 3; i > 0; i--)
        {
            startSec.text = "" + i;
            yield return new WaitForSeconds(1);
        }
        StartLevel();
        SoundStartEngineShip();
        yield break;
    }

    public void StartLevel()
    {
        GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().RestartGame();
        OverMenu.gameStats = true;
        OverMenu.adsState = false;
        visibleBoost.SetActive(true);
        top.SetActive(true);
        textSec.SetActive(false);
        startSec.transform.gameObject.SetActive(false);
        for (int i = 1; i < hud.Length; i++)
        {
            hud[i].SetActive(true);
        }
        hud[2].GetComponent<SwipeController>().ResetPosition();
        GameObject.FindGameObjectWithTag("Empty").GetComponent<Gun>().OnEnableBullet();
        spawnAsteroid.GetComponent<SpawnAsteroid>().StartLevel();
        spawnAsteroid.GetComponent<BoostSpawn>().MethodStarter();
        hudScr.GetComponent<HudScr>().StartLevel();
        gameObject.SetActive(false);
        overMenu.SetActive(true);
    }

    public void NoKeyPanel()
    {
        
        if (overMenu.activeSelf)
        {
            gameOver.GetComponent<OverMenu>().TapEndGameOff();
            overMenu.SetActive(false);           
            if (OverMenu.adsCounter > 0)
            {
                noKeyPanel.SetActive(true);
            }
            else
                noKeyPanelNoAds.SetActive(true);
        }
        else
        {
            gameOver.GetComponent<OverMenu>().TapEndGameOn();
            noKeyPanelNoAds.SetActive(false);
            noKeyPanel.SetActive(false);
            overMenu.SetActive(true);           
        }
    }

    public void UseVideo()
    {
        RestartLevel();
        noKeyPanel.SetActive(false);
        overMenu.SetActive(false);
    }

    private void SoundStartEngineShip()
    {
        GameObject.FindGameObjectWithTag("AudioController_EngineShip").GetComponent<AudioSource>().Play();
    }
}
