using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverMenu : MonoBehaviour
{
    public GameObject help;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;

    public GameObject spawnObject;
    public GameObject panelOver;


    public Text keyText;
    public Text sec;
    public GameObject gameOverPanel;
    public GameObject visibleBoost;

    public GameObject game;
    public GameObject menu;

    public GameObject top;
    public GameObject playerRef;
    public Animator cameraAnim;
    public GameObject cameraMove;

    public GameObject player;
    public GameObject empty;

    public GameObject activeEndPanel;

    public GameObject earth;
    //public Text costText;

    int buttonKey = 1;
    public Text buttonKeyText;

    public static int adsCounter = 3;
    public Text ads;
    public Button useVideo;

    public GameObject tapEndGame;

    public static bool gameStats = true;

    public static bool adsState = false;


    public static int cost;
    private void OnEnable()
    {        
        GameObject.FindGameObjectWithTag("Empty").GetComponent<Gun>().OfGun();
        cost = HudScr.coinCounter;
        spawnObject.GetComponent<SpawnAsteroid>().ResetLevel();
        buttonKeyText.text = "" + buttonKey;       
        keyText.text = "" + HightScore.keyHightCounter;
        StartCoroutine(BackMenuSec());
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().FactorStart();
        //one.SetActive(false);
        //two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
        six.SetActive(false);
        visibleBoost.SetActive(false);
        help.SetActive(false);
        ads.text = "" + adsCounter;
        if (adsCounter == 0)
        {
            useVideo.interactable = false;
        }
        GameObject.FindGameObjectWithTag("GeneralAsteroid").GetComponent<GeneralAsteroid>().CoinDisable();
        GameObject.FindGameObjectWithTag("GeneralComet").GetComponent<GeneralComet>().CoinDisable();
        GameObject.FindGameObjectWithTag("GeneralEnemy").GetComponent<GeneralEnemy>().CoinDisable();
        TapEndGameOn(); 
    }

    
    public void TapEndGameOn()
    {
        tapEndGame.SetActive(true);
    }

    public void TapEndGameOff()
    {
        tapEndGame.SetActive(false);
    }
    IEnumerator BackMenuSec()
    {       
        int seconds = 5;
        while (gameStats == true)
        {
            if (seconds == 0)
            {
                BackMenu();
                yield break;
            }
            sec.text = "" + seconds;
            seconds--;
            yield return new WaitForSeconds(1);
        }       
    }

     

    public void BackMenu()
    {
        activeEndPanel.SetActive(true);
        EndGame.coin = cost;
        EndGame.two = HudScr.scoreCounter;
        EndGame.three = HightScore.scoreHightCounter;
        Missions.SavedPlayerPrefs();
        HightScore.HightCoin();
        HightScore.HightScoreCounter();
        Exit();
    }

    public void Exit()
    {
        HudScr.coinCounter = 0;
        HudScr.kmCounter = 0;
        HudScr.scoreCounter = 0;
        HudScr.repeatObj = 0;
        HudScr.repeatSpeed = 0;
        //one.SetActive(true);
        //two.SetActive(true);
        three.SetActive(true);
        three.GetComponent<SwipeController>().ResetPosition();
        four.SetActive(true);
        five.SetActive(true);
        six.SetActive(true);
        visibleBoost.SetActive(true);
        gameOverPanel.SetActive(false);
        player.SetActive(true);
        playerRef.SetActive(true);
        top.SetActive(true);

        six.GetComponent<Boostslot>().Disabel();

        player.transform.position = new Vector3(0, 0, 0);
        empty.transform.position = new Vector3(0, 0, 0);

        game.SetActive(false);
        earth.SetActive(true);
        SoundStopEngineShip();
        menu.SetActive(true);
        cameraAnim.gameObject.SetActive(true);
        cameraMove.SetActive(false);
        cameraAnim.SetBool("Start", false);
        GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
        buttonKey = 1;
        adsState = false;
        adsCounter = 3;
        useVideo.interactable = true;
        gameStats = true;
        TapEndGameOff();
    }
    public void UseKey()
    {
        if (HightScore.keyHightCounter >= buttonKey)
        {
            panelOver.SetActive(false);
            TapEndGameOff();
            HightScore.keyHightCounter--;
            PlayerPrefs.SetInt("SaveKey", HightScore.keyHightCounter);
            //spawnObject.GetComponent<SpawnAsteroid>().ResetLevel();
            gameOverPanel.GetComponent<GemaeOverPanel>().RestartLevel();
            buttonKey *= 2;
        }
        else
        {
            gameOverPanel.GetComponent<GemaeOverPanel>().NoKeyPanel();
        }
    }

    public void UseVideo()
    {
        if (adsCounter > 0)
        {
            gameStats = false;
            GameObject.FindGameObjectWithTag("Ads").GetComponent<RewardVideoDaily>().ShowVideoResume();
            adsState = true;            
            adsCounter--;
        }

    }

    private void SoundStopEngineShip()
    {
        GameObject.FindGameObjectWithTag("AudioController_EngineShip").GetComponent<AudioSource>().Stop();
    }

}
