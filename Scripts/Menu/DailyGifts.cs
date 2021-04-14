using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.Animations;

public class DailyGifts : MonoBehaviour
{
    private int currentStreak
    {
        get => PlayerPrefs.GetInt("currentStreak", 0);
        set => PlayerPrefs.SetInt("currentStreak", value);

    }

    private DateTime? lastClaimTime
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimTime", null);

            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString("lastClaimTime", value.ToString());
            else
                PlayerPrefs.DeleteKey("lastClaimTime");
        }
    }

    [SerializeField]
    public Text[] status;
    public GameObject[] toTake;
    public GameObject[] already;
    [SerializeField]
    public Button[] claimBt;

    public GameObject[] panels;

    public int[] cost = new int[6];
    public GameObject[] activePanel;
    public Text costText;
    public static int costStatic;

    public GameObject menuButtonDeily;
    public GameObject mark;




    private bool canClaimReward;
    private int maxStreakCount = 6;
    private float claimCooldown = 24f;
    private float claimDeadline = 48f;

    private void Awake()
    {
        OnEnable();
    }
    public void OnEnable()
    {
        StartCoroutine(RewardsStateUpdater());
        panels[currentStreak].GetComponent<RectTransform>().localScale = new Vector3(1.15f, 1.15f, 1);
        for (int i = 0; i < currentStreak; i++)
        {
            //status[i].text = "Получено";
            already[i].SetActive(true);
            

        }
        for (int i = 0; i < 6; i++)
        {
            panels[i].GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            panels[i].transform.GetChild(1).GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            panels[i].transform.GetChild(2).GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            claimBt[i].interactable = false;

        }
        panels[currentStreak].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
        panels[currentStreak].transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1);
        panels[currentStreak].transform.GetChild(2).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1);
        claimBt[currentStreak].interactable = true;
        status[currentStreak].gameObject.SetActive(true);
    }

    private IEnumerator RewardsStateUpdater()
    {
        while (true)
        {
            UpdateRewardsState();
            yield return new WaitForSeconds(1);

        }
    }
    private void UpdateRewardsState()
    {

        canClaimReward = true;

        if (lastClaimTime.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTime.Value;

            if (timeSpan.TotalHours > claimDeadline)
            {
                panels[currentStreak].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
                panels[currentStreak].GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1);
                panels[currentStreak].transform.GetChild(1).GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
                panels[currentStreak].transform.GetChild(2).GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
                panels[0].GetComponent<RectTransform>().localScale = new Vector3(1.15f, 1.15f, 1);
                panels[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
                panels[0].transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1);
            panels[0].transform.GetChild(2).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1);
                lastClaimTime = null;
                currentStreak = 0;
                for (int i = 0; i < 5; i++)
                {
                    already[i].SetActive(false);
                    toTake[i].SetActive(false);
                }
                status[0].gameObject.SetActive(true);
                
            }
            else if (timeSpan.TotalHours < claimCooldown)
            {
                canClaimReward = false;
                
            }
        }
        Check();

        UpdateRewardUI();
    }

    private void UpdateRewardUI()
    {
        
        claimBt[currentStreak].interactable = canClaimReward;

        if (canClaimReward)
        {
            //status[currentStreak].text = "Забрать"; 
            toTake[currentStreak].SetActive(true);
            status[currentStreak].text = "";
            status[currentStreak].gameObject.SetActive(false);

            if (currentStreak < 5)
            {
                status[currentStreak + 1].gameObject.SetActive(true);
            }

        }
            
            
        else
        {
            var nextClaimTime = lastClaimTime.Value.AddHours(claimCooldown);
            var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            status[currentStreak].text = $"{cd}";
        }

    }

    public void ClaimReward()
    {
        OnButtonCost();


        if (currentStreak == 5)
        {
            panels[currentStreak].GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            panels[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
            panels[currentStreak].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
            panels[0].GetComponent<RectTransform>().localScale = new Vector3(1.15f, 1.15f, 1);

            panels[currentStreak].transform.GetChild(1).GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            panels[currentStreak].transform.GetChild(2).GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            panels[0].transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1);
            panels[0].transform.GetChild(2).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1);



            for (int i = 0; i < 5; i++)
            {
                already[i].SetActive(false);                
            }
            toTake[5].SetActive(false);
            status[0].gameObject.SetActive(true);
        }
        if (currentStreak != 5)
        {
            //status[currentStreak].text = "Получено";
            toTake[currentStreak].SetActive(false);
            already[currentStreak].SetActive(true);
            panels[currentStreak + 1].GetComponent<RectTransform>().localScale = new Vector3(1.15f, 1.15f, 1);
            panels[currentStreak].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);

            panels[currentStreak].GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            panels[currentStreak + 1].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);

            panels[currentStreak].transform.GetChild(1).GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            panels[currentStreak].transform.GetChild(2).GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            panels[currentStreak + 1].transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1);
            panels[currentStreak + 1].transform.GetChild(2).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1);


        }
        claimBt[currentStreak].interactable = false;
        
        if (!canClaimReward)
            return;
        lastClaimTime = DateTime.UtcNow;
        currentStreak = (currentStreak + 1) % maxStreakCount;

        UpdateRewardsState();
    }

    public void OnButtonCost()
    {
        costText.text = "" + cost[currentStreak];
        costStatic = cost[currentStreak];
        if (costStatic != 25 && costStatic != 50)
        {
            activePanel[0].SetActive(true);
            activePanel[3].SetActive(true);
            activePanel[2].SetActive(true);
            activePanel[4].SetActive(true);
            
        }
        else
        {
            activePanel[0].SetActive(true);
            activePanel[1].SetActive(true);
            activePanel[3].SetActive(true);
            activePanel[5].SetActive(true);
        }
        DublCost();
    }
    public void DublCost()
    {
        
        if (costStatic != 25 && costStatic != 50)
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + costStatic;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();

        }
        else
        {
            HightScore.keyHightCounter = HightScore.keyHightCounter + costStatic;
            PlayerPrefs.SetInt("SaveKey", HightScore.keyHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
        }
    }

    private void Check()
    {
        if (canClaimReward == true)
        {
            menuButtonDeily.SetActive(true);
            mark.SetActive(true);
        }
        else
        {
            menuButtonDeily.SetActive(false);
            mark.SetActive(false);
        }
            
    }

    public void ButtonActiveDeily()
    {
        ClaimReward();
        menuButtonDeily.SetActive(false);
        mark.SetActive(false);
    }

   
}
