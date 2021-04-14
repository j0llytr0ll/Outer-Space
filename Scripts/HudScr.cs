using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HudScr : MonoBehaviour
{
    public Text coin;
    public Text km;
    public Text score;
    public Text scorefactor;
    public Text coinfactor;
    public GameObject newRecords;
    public static int coinCounter;
    public static int scoreCounter;
    public static decimal kmCounter;
    public static int scoreObj;
    public static int factor;
    public static int coinObj;
    public static float speedBrick;
    public static float spawnWaitR;
    public static float spawnWaitL;


    bool status = false;

    public static float repeatObj;
    public static float repeatSpeed;

    public GameObject plusScore;
    public Text plusScoreText;
    public static int plusScoreInt;

    public GameObject plusCoin;
    public Text plusCoinText;
    public static int plusCoinInt;

    private void OnEnable()
    {
        StartInt();
        FactorStart();
    }

    public void PlusScore()
    {
        plusScoreText.text = "+" + plusScoreInt;
        plusScore.SetActive(false);
        plusScore.SetActive(true);        
    }

    public void PlusCoin()
    {
        plusCoinText.text = "+" + plusCoinInt;
        plusCoin.SetActive(false);
        plusCoin.SetActive(true);
    }

    private void OnDisable()
    {
        plusCoin.SetActive(false);
        plusScore.SetActive(false);
        newRecords.SetActive(false);
        score.color = new Color(255, 255, 255);
    }

    public void FactorStart()
    {
        scorefactor.text = "x" + (scoreObj * factor);
        coinfactor.text = "x" + (coinObj * factor);
        coin.text = "" + coinCounter;
        score.text = "" + scoreCounter;
        km.text = "km: " + Math.Truncate(kmCounter);
    }

    public void StartInt()
    {
        scoreObj = 1;
        factor = 1;
        coinObj = 1;
        coinCounter = 0;
        kmCounter = 0;
        scoreCounter = 0;
        speedBrick = 800;
        spawnWaitR = 3;
        spawnWaitL = 2.5f;
        //spawnWaitR = 0.2f;
        //spawnWaitL = 0.05f;
        //spawnWaitR = 1f;
        //spawnWaitL = 0.5f;

    }

    public void StartLevel()
    {
        //StartInt();
        //FactorStart();
        status = true;
        StartCoroutine(Km());
    }
    public void ResetLevel()
    {
        status = false;
        StopCoroutine(Km());
    }
    IEnumerator Km()
    {
        yield return new WaitForSeconds(0);
        while (status == true)
        {                       
            kmCounter += 0.0333333334m;
            km.text = "km: " + Math.Truncate(kmCounter);
            repeatObj += 0.02f;
            repeatSpeed += 0.02f;
            if (repeatObj > 60)
            {
                bust();
                repeatObj = 0;
            }
            
            if (repeatSpeed > 15)
            {
                ScoreWawes();
                repeatSpeed = 0;
            }           
            yield return new WaitForSeconds(0);
        }
        
    }

    public void CoinText()
    {
        coin.text = "" + coinCounter;
    }

    public void ScoreText()
    {
        if (scoreCounter > HightScore.scoreHightCounter)
        {
            if (!newRecords.activeSelf)
            {
                newRecords.SetActive(true);
                score.color = new Color(0.7f, 0, 1);
                SoundVictory();
            }
        }
        score.text = "" + scoreCounter;
    }

    public void bust()
    {
        scoreObj++;
        coinObj++;
        scorefactor.text = "x" + (scoreObj * factor);
        coinfactor.text = "x" + (coinObj * factor);
    }

    public void ScoreWawes()
    {
        if (speedBrick < 1200)
        {
            speedBrick += 100;
        }
        else if (speedBrick < 1600)
            speedBrick += 12.5f;

        if (spawnWaitR > 1)
        {
            spawnWaitR -= 0.25f;
            spawnWaitL -= 0.25f;
        }
        else if (spawnWaitR > 0.2f)
        {
            spawnWaitR -= 0.025f;
            spawnWaitL -= 0.0140625f;
        }
    }

    private void SoundVictory()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Victory").GetComponent<AudioSource>().Play();
        }
    }
}
