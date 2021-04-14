using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class HightScore : MonoBehaviour
{
    public Text[] coinHight;
    public Text scoreHight;
    public Text[] keyHight;
    public static int coinHightCounter;
    public static int scoreHightCounter;
    public static int keyHightCounter;

    [HideInInspector] private const string leaderBoard = "CgkIg6eBlLwCEAIQAQ";
    void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {

            }
            else
            {

            }
        });

        if (PlayerPrefs.HasKey("SaveCoin"))
        {
            coinHightCounter = PlayerPrefs.GetInt("SaveCoin");
        }

        if (PlayerPrefs.HasKey("SaveScore"))
        {
            scoreHightCounter = PlayerPrefs.GetInt("SaveScore");
        }

        if (PlayerPrefs.HasKey("SaveKey"))
        {
            keyHightCounter = PlayerPrefs.GetInt("SaveKey");
        }
        Counter();
    }

    
    private void OnEnable()
    {        
        scoreHight.text = "" + scoreHightCounter;
    }

    public void Counter()
    {
        scoreHight.text = "" + scoreHightCounter;
        for (int i = 0; i < coinHight.Length; i++)
        {
            coinHight[i].text = "" + coinHightCounter;
            keyHight[i].text = "" + keyHightCounter;
        }
        
    }


    public static void HightKey()
    {
        keyHightCounter--;
        PlayerPrefs.SetInt("SaveKey", keyHightCounter);

    }
    public static void HightCoin()
    {
        coinHightCounter = HudScr.coinCounter + coinHightCounter;
        PlayerPrefs.SetInt("SaveCoin", coinHightCounter);
        
    }

    public static void HightScoreCounter()
    {
        if (HudScr.scoreCounter > scoreHightCounter)
        {
            scoreHightCounter = HudScr.scoreCounter;
            PlayerPrefs.SetInt("SaveScore", scoreHightCounter);
            Social.ReportScore(scoreHightCounter, leaderBoard, (bool success) => { });
        }
    }

    public static void Prefs()
    {
        PlayerPrefs.SetInt("SaveCoin", coinHightCounter);
    }   

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        coinHightCounter = 0;
        scoreHightCounter = 0;
        keyHightCounter = 0;
        
        Counter();
    }

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    private void OnDisable()
    {
        PlayGamesPlatform.Instance.SignOut();
    }
}
