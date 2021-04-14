using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class BonusCost : MonoBehaviour
{
    private DateTime? lastClaimTimeBonusOne
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimTimeBonusOne", null);

            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString("lastClaimTimeBonusOne", value.ToString());
            else
                PlayerPrefs.DeleteKey("lastClaimTimeBonusOne");
        }
    }

    private DateTime? lastClaimTimeBonusTwo
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimTimeBonusTwo", null);

            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString("lastClaimTimeBonusTwo", value.ToString());
            else
                PlayerPrefs.DeleteKey("lastClaimTimeBonusTwo");
        }
    }

    private DateTime? lastClaimTimeBonusThree
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimTimeBonusThree", null);

            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString("lastClaimTimeBonusThree", value.ToString());
            else
                PlayerPrefs.DeleteKey("lastClaimTimeBonusThree");
        }
    }

    private DateTime? lastClaimTimeBonusFour
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimTimeBonusFour", null);

            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString("lastClaimTimeBonusFour", value.ToString());
            else
                PlayerPrefs.DeleteKey("lastClaimTimeBonusFour");
        }
    }

    private DateTime? lastClaimTimeBonusFive
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimTimeBonusFive", null);

            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString("lastClaimTimeBonusFive", value.ToString());
            else
                PlayerPrefs.DeleteKey("lastClaimTimeBonusFive");
        }
    }

    private DateTime? lastClaimTimeBonusSix
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimTimeBonusSix", null);

            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString("lastClaimTimeBonusSix", value.ToString());
            else
                PlayerPrefs.DeleteKey("lastClaimTimeBonusSix");
        }
    }

    public Text[] sec;
    public GameObject[] watch;
    public Button[] claimBt;
    public GameObject[] loading;
    public GameObject menuButtonCoin;
    public GameObject menuButtonKey;
    private bool statusCoin;
    private bool statusKey;
    public GameObject[] loadingMenuButton;
    public GameObject[] watchMenuButton;
    private string statusButtonCoin;
    private string statusButtonKey;

    public GameObject noAdsPanel;
    public GameObject adsPanel;
    public GameObject noCoin;

    private bool corOne = true;
    private bool corTwo = true;
    private bool corThree = true;
    private bool corFour = true;
    private bool corFive = true;
    private bool corSix = true;

    private bool canClaimRewardOne;
    private bool canClaimRewardTwo;
    private bool canClaimRewardThree;
    private bool canClaimRewardFour;
    private bool canClaimRewardFive;
    private bool canClaimRewardSix;
    private float claimCooldown = 24f / 24 * 2;

    private void Awake()
    {
        OnEnable();
    }
    public void OnEnable()
    {
        
        StartBonusOne();
        StartBonusTwo();
        StartBonusThree();
        StartBonusFour();
        StartBonusFive();
        StartBonusSix();
        ChekCoin();
        ChekKey();
    }

    public void StartCheck()
    {
        StartBonusOne();
        StartBonusTwo();
        StartBonusThree();
        StartBonusFour();
        StartBonusFive();
        StartBonusSix();
    }

    //-----------------------------------------------------------------------------
    private void StartBonusOne()
    {
        if (canClaimRewardOne)
        {
            watch[0].SetActive(true);

        }
        else
        {
            sec[0].gameObject.SetActive(true);
        }
        StartCoroutine(RewardsStateUpdaterOne());
    }

    private IEnumerator RewardsStateUpdaterOne()
    {
        while (corOne)
        {
            UpdateRewardsStateOne();
            yield return new WaitForSeconds(1);

        }
    }
    private void UpdateRewardsStateOne()
    {

        canClaimRewardOne = true;

        if (lastClaimTimeBonusOne.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTimeBonusOne.Value;

            if (timeSpan.TotalHours < claimCooldown)
            {
                canClaimRewardOne = false;
            }
        }

        UpdateRewardUIOne();
    }
    
    private void UpdateRewardUIOne()
    {

        claimBt[0].interactable = canClaimRewardOne;

        if (canClaimRewardOne)
        {
            watch[0].SetActive(true);
            sec[0].gameObject.SetActive(false);
            corOne = false;
            StopCoroutine(RewardsStateUpdaterOne());
        }
        else
        {
            var nextClaimTime = lastClaimTimeBonusOne.Value.AddHours(claimCooldown);
            var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            sec[0].text = $"    {cd}";
        }

    }

    public void ClaimRewardOne()
    {
        loadingMenuButton[0].SetActive(false);
        watchMenuButton[0].SetActive(true);       
        claimBt[0].interactable = false;
        watch[0].SetActive(false);
        sec[0].gameObject.SetActive(true);
        if (!canClaimRewardOne)
            return;
        lastClaimTimeBonusOne = DateTime.UtcNow;

        corOne = true;
        StartCoroutine(RewardsStateUpdaterOne());
        
        ChekCoin();
    }

    //-----------------------------------------------------------------------------

    private void StartBonusTwo()
    {
        if (canClaimRewardTwo)
        {
            watch[1].SetActive(true);

        }
        else
        {
            sec[1].gameObject.SetActive(true);
        }
        StartCoroutine(RewardsStateUpdaterTwo());
    }

    private IEnumerator RewardsStateUpdaterTwo()
    {
        while (corTwo)
        {
            UpdateRewardsStateTwo();
            yield return new WaitForSeconds(1);

        }
    }
    private void UpdateRewardsStateTwo()
    {

        canClaimRewardTwo = true;

        if (lastClaimTimeBonusTwo.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTimeBonusTwo.Value;

            if (timeSpan.TotalHours < claimCooldown)
            {
                canClaimRewardTwo = false;
            }
        }

        UpdateRewardUITwo();
    }

    private void UpdateRewardUITwo()
    {

        claimBt[1].interactable = canClaimRewardTwo;

        if (canClaimRewardTwo)
        {
            watch[1].SetActive(true);
            sec[1].gameObject.SetActive(false);
            corTwo = false;
            StopCoroutine(RewardsStateUpdaterTwo());
        }
        else
        {
            var nextClaimTime = lastClaimTimeBonusTwo.Value.AddHours(claimCooldown);
            var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            sec[1].text = $"    {cd}";
        }

    }

    public void ClaimRewardTwo()
    {
        loadingMenuButton[0].SetActive(false);
        watchMenuButton[0].SetActive(true);
        claimBt[1].interactable = false;
        watch[1].SetActive(false);
        sec[1].gameObject.SetActive(true);
        if (!canClaimRewardTwo)
            return;
        lastClaimTimeBonusTwo = DateTime.UtcNow;

        corTwo = true;
        StartCoroutine(RewardsStateUpdaterTwo());
        ChekCoin();
    }

    //-----------------------------------------------------------------------------

    private void StartBonusThree()
    {
        if (canClaimRewardThree)
        {
            watch[2].SetActive(true);

        }
        else
        {
            sec[2].gameObject.SetActive(true);
        }
        StartCoroutine(RewardsStateUpdaterThree());
    }

    private IEnumerator RewardsStateUpdaterThree()
    {
        while (corThree)
        {
            UpdateRewardsStateThree();
            yield return new WaitForSeconds(1);

        }
    }
    private void UpdateRewardsStateThree()
    {

        canClaimRewardThree = true;

        if (lastClaimTimeBonusThree.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTimeBonusThree.Value;

            if (timeSpan.TotalHours < claimCooldown)
            {
                canClaimRewardThree = false;
            }
        }

        UpdateRewardUIThree();
    }

    private void UpdateRewardUIThree()
    {

        claimBt[2].interactable = canClaimRewardThree;

        if (canClaimRewardThree)
        {
            watch[2].SetActive(true);
            sec[2].gameObject.SetActive(false);
            corThree = false;
            StopCoroutine(RewardsStateUpdaterThree());
        }
        else
        {
            var nextClaimTime = lastClaimTimeBonusThree.Value.AddHours(claimCooldown);
            var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            sec[2].text = $"    {cd}";
        }

    }

    public void ClaimRewardOneThree()
    {
        loadingMenuButton[1].SetActive(false);
        watchMenuButton[1].SetActive(true);
        claimBt[2].interactable = false;
        watch[2].SetActive(false);
        sec[2].gameObject.SetActive(true);
        if (!canClaimRewardThree)
            return;
        lastClaimTimeBonusThree = DateTime.UtcNow;

        corThree = true;
        StartCoroutine(RewardsStateUpdaterThree());
        ChekKey();
    }

    //-----------------------------------------------------------------------------

    private void StartBonusFour()
    {
        if (canClaimRewardFour)
        {
            watch[3].SetActive(true);

        }
        else
        {
            sec[3].gameObject.SetActive(true);
        }
        StartCoroutine(RewardsStateUpdaterFour());
    }

    private IEnumerator RewardsStateUpdaterFour()
    {
        while (corFour)
        {
            UpdateRewardsStateFour();
            yield return new WaitForSeconds(1);

        }
    }
    private void UpdateRewardsStateFour()
    {

        canClaimRewardFour = true;

        if (lastClaimTimeBonusFour.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTimeBonusFour.Value;

            if (timeSpan.TotalHours < claimCooldown)
            {
                canClaimRewardFour = false;
            }
        }

        UpdateRewardUIFour();
    }

    private void UpdateRewardUIFour()
    {

        claimBt[3].interactable = canClaimRewardFour;

        if (canClaimRewardFour)
        {
            watch[3].SetActive(true);
            sec[3].gameObject.SetActive(false);
            corFour = false;
            StopCoroutine(RewardsStateUpdaterFour());
        }
        else
        {
            var nextClaimTime = lastClaimTimeBonusFour.Value.AddHours(claimCooldown);
            var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            sec[3].text = $"    {cd}";
        }

    }

    public void ClaimRewardOneFour()
    {
        loadingMenuButton[0].SetActive(false);
        watchMenuButton[0].SetActive(true);
        claimBt[3].interactable = false;
        watch[3].SetActive(false);
        sec[3].gameObject.SetActive(true);
        if (!canClaimRewardFour)
            return;
        lastClaimTimeBonusFour = DateTime.UtcNow;

        corFour = true;
        StartCoroutine(RewardsStateUpdaterFour());
        ChekCoin();
    }

    //-----------------------------------------------------------------------------

    private void StartBonusFive()
    {
        if (canClaimRewardFive)
        {
            watch[4].SetActive(true);

        }
        else
        {
            sec[4].gameObject.SetActive(true);
        }
        StartCoroutine(RewardsStateUpdaterFive());
    }

    private IEnumerator RewardsStateUpdaterFive()
    {
        while (corFive)
        {
            UpdateRewardsStateFive();
            yield return new WaitForSeconds(1);

        }
    }
    private void UpdateRewardsStateFive()
    {

        canClaimRewardFive = true;

        if (lastClaimTimeBonusFive.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTimeBonusFive.Value;

            if (timeSpan.TotalHours < claimCooldown)
            {
                canClaimRewardFive = false;
            }
        }

        UpdateRewardUIFive();
    }

    private void UpdateRewardUIFive()
    {

        claimBt[4].interactable = canClaimRewardFive;

        if (canClaimRewardFive)
        {
            watch[4].SetActive(true);
            sec[4].gameObject.SetActive(false);
            corFive = false;
            StopCoroutine(RewardsStateUpdaterFive());
        }
        else
        {
            var nextClaimTime = lastClaimTimeBonusFive.Value.AddHours(claimCooldown);
            var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            sec[4].text = $"    {cd}";
        }

    }

    public void ClaimRewardOneFive()
    {
        loadingMenuButton[0].SetActive(false);
        watchMenuButton[0].SetActive(true);
        claimBt[4].interactable = false;
        watch[4].SetActive(false);
        sec[4].gameObject.SetActive(true);
        if (!canClaimRewardFive)
            return;
        lastClaimTimeBonusFive = DateTime.UtcNow;

        corFive = true;
        StartCoroutine(RewardsStateUpdaterFive());
        ChekCoin();
    }

    //-----------------------------------------------------------------------------

    private void StartBonusSix()
    {
        if (canClaimRewardSix)
        {
            watch[5].SetActive(true);

        }
        else
        {
            sec[5].gameObject.SetActive(true);
        }
        StartCoroutine(RewardsStateUpdaterSix());
    }

    private IEnumerator RewardsStateUpdaterSix()
    {
        while (corSix)
        {
            UpdateRewardsStateSix();
            yield return new WaitForSeconds(1);

        }
    }
    private void UpdateRewardsStateSix()
    {

        canClaimRewardSix = true;

        if (lastClaimTimeBonusSix.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTimeBonusSix.Value;

            if (timeSpan.TotalHours < claimCooldown)
            {
                canClaimRewardSix = false;
            }
        }

        UpdateRewardUISix();
    }

    private void UpdateRewardUISix()
    {

        claimBt[5].interactable = canClaimRewardSix;

        if (canClaimRewardSix)
        {
            watch[5].SetActive(true);
            sec[5].gameObject.SetActive(false);
            corSix = false;
            StopCoroutine(RewardsStateUpdaterSix());
        }
        else
        {
            var nextClaimTime = lastClaimTimeBonusSix.Value.AddHours(claimCooldown);
            var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            sec[5].text = $"    {cd}";
        }

    }

    public void ClaimRewardOneSix()
    {
        loadingMenuButton[1].SetActive(false);
        watchMenuButton[1].SetActive(true);
        claimBt[5].interactable = false;
        watch[5].SetActive(false);
        sec[5].gameObject.SetActive(true);
        if (!canClaimRewardSix)
            return;
        lastClaimTimeBonusSix = DateTime.UtcNow;

        corSix = true;
        StartCoroutine(RewardsStateUpdaterSix());
        ChekKey();
    }


    //-----------------------------------------------------------------------------

    public void ChekCoin()
    {
        if (corOne == false)
        {
            menuButtonCoin.SetActive(true);
            statusCoin = false;
        }
        else if (corTwo == false)
        {
            menuButtonCoin.SetActive(true);
            statusCoin = false;
        }
        else if (corFour == false)
        {
            menuButtonCoin.SetActive(true);
            statusCoin = false;
        }
        else if (corFive == false)
        {
            menuButtonCoin.SetActive(true);
            statusCoin = false;
        }
        else
        {
            if (statusCoin == false && statusButtonCoin == "ButtonCoin")
            {
                if (!noCoin.activeSelf)
                {
                    GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().MenuBatton();
                    GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().BonusActiveButton();
                }                
                statusButtonCoin = "Off";
                statusCoin = true;
            }           
            menuButtonCoin.SetActive(false);
        }
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().ExitNoCoinPanel();



    }

    public void ChekCoinAdsPanel()
    {
        if (corOne == false)
        {
            noCoin.SetActive(true);
            adsPanel.SetActive(true);
        }
        else if (corTwo == false)
        {
            noCoin.SetActive(true);
            adsPanel.SetActive(true);
        }
        else if (corFour == false)
        {
            noCoin.SetActive(true);
            adsPanel.SetActive(true);
        }
        else if (corFive == false)
        {
            noCoin.SetActive(true);
            adsPanel.SetActive(true);
        }
        else
        {
            noCoin.SetActive(true);
            noAdsPanel.SetActive(true);
            menuButtonCoin.SetActive(false);
        }

    }

    public void ChekKey()
    {
        if (corThree == false)
        {
            menuButtonKey.SetActive(true);
            statusKey = false;
        }
        else if (corSix == false)
        {
            menuButtonKey.SetActive(true);
            statusKey = false;
        }
        else
        {
            if (statusKey == false && statusButtonKey == "ButtonKey")
            {
                GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().MenuBatton();
                GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().BonusActiveButton();
                statusButtonKey = "Off";
                statusKey = true;
            }
            menuButtonKey.SetActive(false);
        }
            
    }

    public void ButtonKey()
    {
        watchMenuButton[1].SetActive(false);
        loadingMenuButton[1].SetActive(true);
        statusButtonKey = "ButtonKey";
        if (corThree == false)
        {
            GameObject.FindGameObjectWithTag("Ads").GetComponent<RewardVideoDaily>().ButtonThree();

        }
        else if (corSix == false)
        {
            GameObject.FindGameObjectWithTag("Ads").GetComponent<RewardVideoDaily>().ButtonSix();

        }
    }

    public void ButtonCoin()
    {
        watchMenuButton[0].SetActive(false);
        loadingMenuButton[0].SetActive(true);
        statusButtonCoin = "ButtonCoin";
        if (corOne == false)
        {
            GameObject.FindGameObjectWithTag("Ads").GetComponent<RewardVideoDaily>().ButtonOne();
        }
        else if (corTwo == false)
        {
            GameObject.FindGameObjectWithTag("Ads").GetComponent<RewardVideoDaily>().ButtonTwo();
        }
        else if (corFour == false)
        {
            GameObject.FindGameObjectWithTag("Ads").GetComponent<RewardVideoDaily>().ButtonFour();
        }
        else if (corFive == false)
        {
            GameObject.FindGameObjectWithTag("Ads").GetComponent<RewardVideoDaily>().ButtonFive();
        }
    }
    
}
