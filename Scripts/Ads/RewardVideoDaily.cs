using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardVideoDaily : MonoBehaviour, IUnityAdsListener
{
    private readonly string videoID = "rewardedVideo";

    private readonly string videoIDBonusCoin = "rewardVideoBonusCoin";

    private readonly string videoIDBonusKey = "rewardVideoBonusKey";

    private readonly string videoIDMissions = "rewardVideoMissions";

    private readonly string videoIDResume = "rewardVideoResume";

    private readonly string videoIDEnd = "rewardVideoEnd";

    public Transform[] coinActivation;
    public GameObject[] keyActivation;
    public Text textCoinActivation;
    public GameObject[] loading;
    public GameObject[] watch;
    public GameObject loadingDaily;
    public GameObject[] watchDaily;
    public GameObject[] missionsReference;
    public GameObject[] resumeWatch;

    public int[] cost;
    public int[] key;
    public int[] table;

    private int total;
    private int randomNumber;

    public static int coinNumber;
    public static int keyNumber;

    public void Awake()
    {
        
        Advertisement.AddListener(this);
    }



    public void ShowVideo()
    {
        watchDaily[0].SetActive(false);
        watchDaily[1].SetActive(false);
        loadingDaily.SetActive(true);
        if (Advertisement.IsReady(videoID))
        {
            Advertisement.Show(videoID);
        }
    }

    public void ShowVideoEnd()
    {
       
        if (Advertisement.IsReady(videoIDEnd))
        {
            Advertisement.Show(videoIDEnd);
        }
    }

    public void ShowVideoResume()
    {
        resumeWatch[0].SetActive(false);
        resumeWatch[1].SetActive(false);
        resumeWatch[2].SetActive(true);
        resumeWatch[3].SetActive(true);
        if (Advertisement.IsReady(videoIDResume))
        {
            Advertisement.Show(videoIDResume);
        }
    }

    public void ShowVideoMissions()
    {
        missionsReference[0].SetActive(false);
        missionsReference[1].SetActive(true);
        if (Advertisement.IsReady(videoIDMissions))
        {
            Advertisement.Show(videoIDMissions);
        }
    }

    public void ButtonOne()
    {
        coinNumber = 0;
        ShowVideoBonusCoin();
    }
    public void ButtonTwo()
    {
        coinNumber = 1;
        ShowVideoBonusCoin();
    }
    public void ButtonThree()
    {
        keyNumber = 2;
        ShowVideoBonusKey();
    }
    public void ButtonFour()
    {
        coinNumber = 3;
        ShowVideoBonusCoin();
    }
    public void ButtonFive()
    {
        coinNumber = 4;
        ShowVideoBonusCoin();
    }
    public void ButtonSix()
    {
        keyNumber = 5;
        ShowVideoBonusKey();
    }
    public void ShowVideoBonusCoin()
    {
        watch[coinNumber].SetActive(false);
        loading[coinNumber].SetActive(true);

        if (Advertisement.IsReady(videoIDBonusCoin))
        {
            Advertisement.Show(videoIDBonusCoin);
        }
    }


    public void ShowVideoBonusKey()
    {
        watch[keyNumber].SetActive(false);
        loading[keyNumber].SetActive(true);

        if (Advertisement.IsReady(videoIDBonusKey))
        {
            Advertisement.Show(videoIDBonusKey);
        }
    }
    public void OnUnityAdsDidError(string message)
    {
        if (message == videoID)
        {
            Debug.Log("ошибка");
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == videoID && showResult == ShowResult.Finished)
        {

            GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().OffCostPanel();
            DublCost();
        }

        if (placementId == videoIDEnd && showResult == ShowResult.Finished)
        {
            HightScore.coinHightCounter += OverMenu.cost;
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            GameObject.FindGameObjectWithTag("EndGame").GetComponent<EndGame>().ClosePanel();
        }

        if (placementId == videoIDResume && showResult == ShowResult.Finished)
        {
            resumeWatch[0].SetActive(true);
            resumeWatch[1].SetActive(true);
            resumeWatch[2].SetActive(false);
            resumeWatch[3].SetActive(false);
            GameObject.FindGameObjectWithTag("GameOverMenu").GetComponent<GemaeOverPanel>().UseVideo();

        }

        if (placementId == videoIDMissions && showResult == ShowResult.Finished)
        {

            GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().OffCostPanel();
            MissionsDobleCoin();
        }

        if (placementId == videoIDBonusCoin && showResult == ShowResult.Finished)
        {           
            loading[coinNumber].SetActive(false);
            if (coinNumber == 0)
                gameObject.GetComponent<BonusCost>().ClaimRewardOne();
            if (coinNumber == 1)
                gameObject.GetComponent<BonusCost>().ClaimRewardTwo();
            if (coinNumber == 3)
                gameObject.GetComponent<BonusCost>().ClaimRewardOneFour();
            if (coinNumber == 4)
                gameObject.GetComponent<BonusCost>().ClaimRewardOneFive();
            ActivateCoin();
            coinNumber = 0;
            
        }

        if (placementId == videoIDBonusKey && showResult == ShowResult.Finished)
        {

            loading[keyNumber].SetActive(false);
            if (keyNumber == 2)
                gameObject.GetComponent<BonusCost>().ClaimRewardOneThree();
            if (keyNumber == 5)
                gameObject.GetComponent<BonusCost>().ClaimRewardOneSix();
            ActivateKey();
            keyNumber = 0;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        if (placementId == videoID)
        {
            
        }
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void ActivateCoin()
    {
        total = 0;
        randomNumber = 0;
        for (int i = 0; i < coinActivation.Length; i++)
        {
            coinActivation[i].gameObject.SetActive(true);
        }
        foreach (var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                textCoinActivation.text = "" + cost[i];
                HightScore.coinHightCounter = HightScore.coinHightCounter + cost[i];
                PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
                GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }

    private void ActivateKey()
    {
        total = 0;
        randomNumber = 0;
        for (int i = 0; i < keyActivation.Length; i++)
        {
            keyActivation[i].SetActive(true);
        }
        foreach (var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                textCoinActivation.text = "" + key[i];
                HightScore.keyHightCounter = HightScore.keyHightCounter + key[i];
                PlayerPrefs.SetInt("SaveKey", HightScore.keyHightCounter);
                GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }

    public void DublCost()
    {
        if (DailyGifts.costStatic != 25 && DailyGifts.costStatic != 50)
        {

            HightScore.coinHightCounter = HightScore.coinHightCounter + DailyGifts.costStatic;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();

        }
        else
        {
            HightScore.keyHightCounter = HightScore.keyHightCounter + DailyGifts.costStatic;
            PlayerPrefs.SetInt("SaveKey", HightScore.keyHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
        }
    }

    public void MissionsDobleCoin()
    {
        HightScore.coinHightCounter = HightScore.coinHightCounter + Missions.dobleCoin;
        PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
        GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
    }
}
