using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    public GameObject[] costActivate;
    public Text costText;
    public Text textMesh;
    public GameObject watch;
    public static int dobleCoin;
    [Header("Saved")]
    public Button savedButtons;
    public Text savedButtonsText;
    public Text savedScoreText;
    public static int savedCollect;
    public static int savedMax = 3;
    public static int savedreward = 100;

    [Header("Magnet")]
    public Button magnetButtons;
    public Text magnetButtonsText;
    public Text magnetScoreText;
    public static int magnetCollect;
    public static int magnetMax = 3;
    public static int magnetReward = 100;

    [Header("EnemyObjects")]
    public Button enemyObjectsButtons;
    public Text enemyObjectsButtonsText;
    public Text enemyObjectsScoreText;
    public static int enemyObjectsCollect;
    public static int enemyObjectsMax = 20;
    public static int enemyObjectsReward = 400;

    [Header("Rocket")]
    public Button rocketButtons;
    public Text rocketButtonsText;
    public Text rocketScoreText;
    public static int rocketCollect;
    public static int rocketMax = 3;
    public static int rocketReward = 100;

    [Header("Factor")]
    public Button factorButtons;
    public Text factorButtonsText;
    public Text factorScoreText;
    public static int factorCollect;
    public static int factorMax = 3;
    public static int factorReward = 200;

    [Header("Hearth")]
    public Button hearthButtons;
    public Text hearthButtonsText;
    public Text hearthScoreText;
    public static int hearthCollect;
    public static int hearthMax = 20;
    public static int hearthReward = 300;



    private void OnEnable()
    {
        SavedMissionAwake();
        MagnetMissionAwake();
        EnemyObjectsMissionAwake();
        RocketMissionAwake();
        FactorMissionAwake();
        HearthMissionAwake();
    }

    public void Start()
    {
        Invoke("StartText", 0.001f);
    }

    public void StartText() 
    {
        savedButtonsText.text = textMesh.text + " " + savedreward;
        magnetButtonsText.text = textMesh.text + " " + magnetReward;
        enemyObjectsButtonsText.text = textMesh.text + " " + enemyObjectsReward;
        rocketButtonsText.text = textMesh.text + " " + rocketReward;
        factorButtonsText.text = textMesh.text + " " + factorReward;
        hearthButtonsText.text = textMesh.text + " " + hearthReward;
    }
    //-----------------------------------------------------Saved
    void SavedMissionAwake()
    {
        if (PlayerPrefs.HasKey("SavedCollect"))
        {
            savedCollect = PlayerPrefs.GetInt("SavedCollect");
        }
        if (PlayerPrefs.HasKey("Savedreward"))
        {
            savedreward = PlayerPrefs.GetInt("Savedreward");
        }
        if (PlayerPrefs.HasKey("SavedMax"))
        {
            savedMax = PlayerPrefs.GetInt("SavedMax");
        }        
        SavedMission();
    }
    void SavedMission()
    {
        savedButtonsText.text = textMesh.text + " " + savedreward;
        if (savedCollect < savedMax)
        {
            savedScoreText.text = savedCollect + " / " + savedMax;
            savedButtons.interactable = false;
            savedButtonsText.GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
        }
        else
        {
            savedScoreText.text = savedMax + " / " + savedMax;
            savedButtons.interactable = true;
            savedButtonsText.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        }
    }

    public void SavedButtonMission()
    {
        if (savedCollect >= savedMax)
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + savedreward;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < costActivate.Length; i++)
            {
                costActivate[i].SetActive(true);
            }
            watch.SetActive(true);
            dobleCoin = savedreward;
            costText.text = "" + savedreward;
            savedCollect = savedCollect - savedMax;
            PlayerPrefs.SetInt("SavedCollect", savedCollect);
            savedreward = (savedreward / 2) + savedreward;
            PlayerPrefs.SetInt("Savedreward", savedreward);
            savedMax = (savedMax / 2) + savedMax;
            PlayerPrefs.SetInt("SavedMax", savedMax);            
            SavedMission();
        }
        
    }

    //-----------------------------------------------------Magnet

    void MagnetMissionAwake()
    {
        if (PlayerPrefs.HasKey("MagnetCollect"))
        {
            magnetCollect = PlayerPrefs.GetInt("MagnetCollect");
        }
        if (PlayerPrefs.HasKey("MagnetReward"))
        {
            magnetReward = PlayerPrefs.GetInt("MagnetReward");
        }
        if (PlayerPrefs.HasKey("MagnetMax"))
        {
            magnetMax = PlayerPrefs.GetInt("MagnetMax");
        }
        MagnetMission();
    }
    void MagnetMission()
    {
        magnetButtonsText.text = textMesh.text + " " + magnetReward;
        if (magnetCollect < magnetMax)
        {
            magnetScoreText.text = magnetCollect + " / " + magnetMax;
            magnetButtons.interactable = false;
            magnetButtonsText.GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
        }
        else
        {
            magnetScoreText.text = magnetMax + " / " + magnetMax;
            magnetButtons.interactable = true;
            magnetButtonsText.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        }
    }

    public void MagnetButtonMission()
    {
        if (magnetCollect >= magnetMax)
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + magnetReward;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < costActivate.Length; i++)
            {
                costActivate[i].SetActive(true);
            }
            watch.SetActive(true);
            dobleCoin = magnetReward;
            costText.text = "" + magnetReward;
            magnetCollect = magnetCollect - magnetMax;
            PlayerPrefs.SetInt("MagnetCollect", magnetCollect);
            magnetReward = (magnetReward / 2) + magnetReward;
            PlayerPrefs.SetInt("MagnetReward", magnetReward);
            magnetMax = (magnetMax / 2) + magnetMax;
            PlayerPrefs.SetInt("MagnetMax", magnetMax);
            MagnetMission();
        }

    }

    //-----------------------------------------------------EnemyObjects

    void EnemyObjectsMissionAwake()
    {
        if (PlayerPrefs.HasKey("EnemyObjectsCollect"))
        {
            enemyObjectsCollect = PlayerPrefs.GetInt("EnemyObjectsCollect");
        }
        if (PlayerPrefs.HasKey("EnemyObjectsReward"))
        {
            enemyObjectsReward = PlayerPrefs.GetInt("EnemyObjectsReward");
        }
        if (PlayerPrefs.HasKey("EnemyObjectsMax"))
        {
            enemyObjectsMax = PlayerPrefs.GetInt("EnemyObjectsMax");
        }
        EnemyObjectsMission();
    }
    void EnemyObjectsMission()
    {
        enemyObjectsButtonsText.text = textMesh.text + " " + enemyObjectsReward;
        if (enemyObjectsCollect < enemyObjectsMax)
        {
            enemyObjectsScoreText.text = enemyObjectsCollect + " / " + enemyObjectsMax;
            enemyObjectsButtons.interactable = false;
            enemyObjectsButtonsText.GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
        }
        else
        {
            enemyObjectsScoreText.text = enemyObjectsMax + " / " + enemyObjectsMax;
            enemyObjectsButtons.interactable = true;
            enemyObjectsButtonsText.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        }
    }

    public void EnemyObjectsButtonMission()
    {
        if (enemyObjectsCollect >= enemyObjectsMax)
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + enemyObjectsReward;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < costActivate.Length; i++)
            {
                costActivate[i].SetActive(true);
            }
            watch.SetActive(true);
            dobleCoin = enemyObjectsReward;
            costText.text = "" + enemyObjectsReward;
            enemyObjectsCollect = enemyObjectsCollect - enemyObjectsMax;
            PlayerPrefs.SetInt("EnemyObjectsCollect", enemyObjectsCollect);
            enemyObjectsReward = (enemyObjectsReward / 2) + enemyObjectsReward;
            PlayerPrefs.SetInt("EnemyObjectsReward", enemyObjectsReward);
            enemyObjectsMax = (enemyObjectsMax / 2) + enemyObjectsMax;
            PlayerPrefs.SetInt("EnemyObjectsMax", enemyObjectsMax);
            EnemyObjectsMission();
        }

    }

    //-----------------------------------------------------Rocket

    void RocketMissionAwake()
    {
        if (PlayerPrefs.HasKey("RocketCollect"))
        {
            rocketCollect = PlayerPrefs.GetInt("RocketCollect");
        }
        if (PlayerPrefs.HasKey("RocketReward"))
        {
            rocketReward = PlayerPrefs.GetInt("RocketReward");
        }
        if (PlayerPrefs.HasKey("RocketMax"))
        {
            rocketMax = PlayerPrefs.GetInt("RocketMax");
        }
        RocketMission();
    }
    void RocketMission()
    {
        rocketButtonsText.text = textMesh.text + " " + rocketReward;
        if (rocketCollect < rocketMax)
        {
            rocketScoreText.text = rocketCollect + " / " + rocketMax;
            rocketButtons.interactable = false;
            rocketButtonsText.GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
        }
        else
        {
            rocketScoreText.text = rocketMax + " / " + rocketMax;
            rocketButtons.interactable = true;
            rocketButtonsText.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        }
    }

    public void RocketButtonMission()
    {
        if (rocketCollect >= rocketMax)
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + rocketReward;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < costActivate.Length; i++)
            {
                costActivate[i].SetActive(true);
            }
            watch.SetActive(true);
            dobleCoin = rocketReward;
            costText.text = "" + rocketReward;
            rocketCollect = rocketCollect - rocketMax;
            PlayerPrefs.SetInt("RocketCollect", rocketCollect);
            rocketReward = (rocketReward / 2) + rocketReward;
            PlayerPrefs.SetInt("RocketReward", rocketReward);
            rocketMax = (rocketMax / 2) + rocketMax;
            PlayerPrefs.SetInt("RocketMax", rocketMax);
            RocketMission();
        }

    }

    //-----------------------------------------------------Factor

    void FactorMissionAwake()
    {
        if (PlayerPrefs.HasKey("FactorCollect"))
        {
            factorCollect = PlayerPrefs.GetInt("FactorCollect");
        }
        if (PlayerPrefs.HasKey("FactorReward"))
        {
            factorReward = PlayerPrefs.GetInt("FactorReward");
        }
        if (PlayerPrefs.HasKey("FactorMax"))
        {
            factorMax = PlayerPrefs.GetInt("FactorMax");
        }
        FactorMission();
    }
    void FactorMission()
    {
        factorButtonsText.text = textMesh.text + " " + factorReward;
        if (factorCollect < factorMax)
        {
            factorScoreText.text = factorCollect + " / " + factorMax;
            factorButtons.interactable = false;
            factorButtonsText.GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
        }
        else
        {
            factorScoreText.text = factorMax + " / " + factorMax;
            factorButtons.interactable = true;
            factorButtonsText.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        }
    }

    public void FactorButtonMission()
    {
        if (factorCollect >= factorMax)
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + factorReward;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < costActivate.Length; i++)
            {
                costActivate[i].SetActive(true);
            }
            watch.SetActive(true);
            dobleCoin = factorReward;
            costText.text = "" + factorReward;
            factorCollect = factorCollect - factorMax;
            PlayerPrefs.SetInt("FactorCollect", factorCollect);
            factorReward = (factorReward / 2) + factorReward;
            PlayerPrefs.SetInt("FactorReward", factorReward);
            factorMax = (factorMax / 2) + factorMax;
            PlayerPrefs.SetInt("FactorMax", factorMax);
            FactorMission();
        }

    }

    //-----------------------------------------------------Hearth

    void HearthMissionAwake()
    {
        if (PlayerPrefs.HasKey("HearthCollect"))
        {
            hearthCollect = PlayerPrefs.GetInt("HearthCollect");
        }
        if (PlayerPrefs.HasKey("HearthReward"))
        {
            hearthReward = PlayerPrefs.GetInt("HearthReward");
        }
        if (PlayerPrefs.HasKey("HearthMax"))
        {
            hearthMax = PlayerPrefs.GetInt("HearthMax");
        }
        HearthMission();
    }
    void HearthMission()
    {
        hearthButtonsText.text = textMesh.text + " " + hearthReward;
        if (hearthCollect < hearthMax)
        {
            hearthScoreText.text = hearthCollect + " / " + hearthMax;
            hearthButtons.interactable = false;
            hearthButtonsText.GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.8f, 1);
        }
        else
        {
            hearthScoreText.text = hearthMax + " / " + hearthMax;
            hearthButtons.interactable = true;
            hearthButtonsText.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        }
    }

    public void HearthButtonMission()
    {
        if (hearthCollect >= hearthMax)
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + hearthReward;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < costActivate.Length; i++)
            {
                costActivate[i].SetActive(true);
            }
            watch.SetActive(true);
            dobleCoin = hearthReward;
            costText.text = "" + hearthReward;
            hearthCollect = hearthCollect - hearthMax;
            PlayerPrefs.SetInt("HearthCollect", hearthCollect);
            hearthReward = (hearthReward / 2) + hearthReward;
            PlayerPrefs.SetInt("HearthReward", hearthReward);
            hearthMax = (hearthMax / 2) + hearthMax;
            PlayerPrefs.SetInt("HearthMax", hearthMax);
            HearthMission();
        }

    }

    //-----------------------------------------------------

    public static void SavedPlayerPrefs()
    {
        savedCollect = MissionsController.missionsCollect[0];
        PlayerPrefs.SetInt("SavedCollect", savedCollect);
        magnetCollect = MissionsController.missionsCollect[1];
        PlayerPrefs.SetInt("MagnetCollect", magnetCollect);
        enemyObjectsCollect = MissionsController.missionsCollect[5];
        PlayerPrefs.SetInt("EnemyObjectsCollect", enemyObjectsCollect);
        rocketCollect = MissionsController.missionsCollect[3];
        PlayerPrefs.SetInt("RocketCollect", rocketCollect);
        factorCollect = MissionsController.missionsCollect[4];
        PlayerPrefs.SetInt("FactorCollect", factorCollect);
        hearthCollect = MissionsController.missionsCollect[2];
        PlayerPrefs.SetInt("HearthCollect", hearthCollect);
    }

}
