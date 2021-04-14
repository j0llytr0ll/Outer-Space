using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShoBoost : MonoBehaviour
{
    public GameObject adsPanel;
    public GameObject noAdsPanel;


    [Header("Saved")]
    public GameObject buttonSaved;
    public GameObject[] lightSaved; 

    [Space(height:5f)]
    public Text textButtonSaved;
    public Text[] textLightSaved;

    [Space(height: 5f)]
    public int[] costSaved;
    int valueStringSaved = 2;    
    int boostSaved;
    public int[] valueSaved;
    public static int staticValueSaved;
    


    [Header("Magnet")]
    public GameObject buttonMagnet;
    public GameObject[] lightMagnet;

    [Space(height: 5f)]
    public Text textButtonMagnet;
    public Text[] textLightMagnet;

    [Space(height: 5f)]
    public int[] costMagnet;
    int valueStringMagnet = 2;
    int boostMagnet;
    public int[] valueMagnet;
    public static int staticValueMagnet;


    [Header("Rocket")]
    public GameObject buttonRocket;
    public GameObject[] lightRocket;

    [Space(height: 5f)]
    public Text textButtonRocket;
    public Text[] textLightRocket;

    [Space(height: 5f)]
    public int[] costRocket;
    int valueStringRocket = 2;
    int boostRocket;
    public int[] valueRocket;
    public static int staticValueRocket;


    [Header("Factor")]
    public GameObject buttonFactor;
    public GameObject[] lightFactor;

    [Space(height: 5f)]
    public Text textButtonFactor;
    public Text[] textLightFactor;

    [Space(height: 5f)]
    public int[] costFactor;
    int valueStringFactor = 2;
    int boostFactor;
    public int[] valueFactor;
    public static int staticValueFactor;


    [Header("Hearth")]
    public GameObject buttonHearth;
    public GameObject[] lightHearth;

    [Space(height: 5f)]
    public Text textButtonHearth;
    public Text[] textLightHearth;

    [Space(height: 5f)]
    public int[] costHearth;
    int valueStringHearth = 1;
    int boostHearth;
    public int[] valueHearth;
    public static int staticValueHearth;
    public int value;


    [Header("Slot")]
    public GameObject buttonSlot;
    public GameObject[] lightSlot;

    [Space(height: 5f)]
    public Text textButtonSlot;
    public Text[] textLightSlot;

    [Space(height: 5f)]
    public int[] costSlot;
    int valueStringSlot = 1;
    int boostSlot;
    public int[] valueSlot;
    public static int staticValueSlot;



    void Awake()
    {

        AwakeSaved();
        AwakeMagnet();
        AwakeRocket();
        AwakeFactor();
        AwakeHearth();
        AwakeSlot();
        value = staticValueHearth;
    }

    //-----------------------------------------------------------------------------Saved
    void AwakeSaved()
    {
        boostSaved = PlayerPrefs.GetInt("BoostSaved");
        staticValueSaved = valueSaved[boostSaved];
        StartSaved();
    }

    void StartSaved()
    {

        for (int i = 0; i <= boostSaved; i++)
        {
            lightSaved[i].SetActive(true);
            lightSaved[i].GetComponent<Image>().color = new Color(0, 0.7f, 1, 1);
            if (i < 9)
            {
                lightSaved[i + 1].SetActive(true);
                lightSaved[i + 1].GetComponent<Image>().color = new Color(0, 0.85f , 0, 1);                
                textButtonSaved.text = "" + costSaved[i];
            }            
            else
            {
                textButtonSaved.text = "Full";
            }
            if (i == boostSaved)
            {
                textLightSaved[i].text = "" + valueSaved[i];
                if (i > 0)
                {
                    textLightSaved[i - 1].text = "";
                }
                if (i < 9)
                {
                    textLightSaved[i + 1].text = "+" + valueStringSaved;
                }
                staticValueSaved = valueSaved[boostSaved];
            }           
        }

    }

    public void ButtonSaved()
    {
        if (boostSaved < 9)
        {
            if (HightScore.coinHightCounter >= costSaved[boostSaved])
            {
                HightScore.coinHightCounter = HightScore.coinHightCounter - costSaved[boostSaved];
                PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
                GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
                boostSaved++;
                PlayerPrefs.SetInt("BoostSaved", boostSaved);
                StartSaved();
            }
            else
            {
                CostAds();
            }
        }
        else
        {
            
        }

    }

    //-----------------------------------------------------------------------------Magnet
    void AwakeMagnet()
    {
        boostMagnet = PlayerPrefs.GetInt("BoostMagnet");
        staticValueMagnet = valueMagnet[boostMagnet];
        StartMagnet();
    }

    void StartMagnet()
    {

        for (int i = 0; i <= boostMagnet; i++)
        {
            lightMagnet[i].SetActive(true);
            lightMagnet[i].GetComponent<Image>().color = new Color(0, 0.7f, 1, 1);
            if (i < 9)
            {
                lightMagnet[i + 1].SetActive(true);
                lightMagnet[i + 1].GetComponent<Image>().color = new Color(0, 0.85f, 0, 1);
                textButtonMagnet.text = "" + costMagnet[i];
            }
            else
            {
                textButtonMagnet.text = "Full";
            }
            if (i == boostMagnet)
            {
                textLightMagnet[i].text = "" + valueMagnet[i];
                if (i > 0)
                {
                    textLightMagnet[i - 1].text = "";
                }
                if (i < 9)
                {
                    textLightMagnet[i + 1].text = "+" + valueStringMagnet;
                }
                staticValueMagnet = valueMagnet[boostMagnet];
            }
        }

    }

    public void ButtonMagnet()
    {
        if (boostMagnet < 9)
        {
            if (HightScore.coinHightCounter >= costMagnet[boostMagnet])
            {
                HightScore.coinHightCounter = HightScore.coinHightCounter - costMagnet[boostMagnet];
                PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
                GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
                boostMagnet++;
                PlayerPrefs.SetInt("BoostMagnet", boostMagnet);
                StartMagnet();
            }
            else
            {
                CostAds();
            }
        }
        else
        {

        }

    }

    //-----------------------------------------------------------------------------Rocket

    void AwakeRocket()
    {
        boostRocket = PlayerPrefs.GetInt("BoostRocket");
        staticValueRocket = valueRocket[boostRocket];
        StartRocket();
    }

    void StartRocket()
    {

        for (int i = 0; i <= boostRocket; i++)
        {
            lightRocket[i].SetActive(true);
            lightRocket[i].GetComponent<Image>().color = new Color(0, 0.7f, 1, 1);
            if (i < 9)
            {
                lightRocket[i + 1].SetActive(true);
                lightRocket[i + 1].GetComponent<Image>().color = new Color(0, 0.85f, 0, 1);
                textButtonRocket.text = "" + costRocket[i];
            }
            else
            {
                textButtonRocket.text = "Full";
            }
            if (i == boostRocket)
            {
                textLightRocket[i].text = "" + valueRocket[i];
                if (i > 0)
                {
                    textLightRocket[i - 1].text = "";
                }
                if (i < 9)
                {
                    textLightRocket[i + 1].text = "+" + valueStringRocket;
                }
                staticValueRocket = valueRocket[boostRocket];
            }
        }

    }

    public void ButtonRocket()
    {
        if (boostRocket < 9)
        {
            if (HightScore.coinHightCounter >= costRocket[boostRocket])
            {
                HightScore.coinHightCounter = HightScore.coinHightCounter - costRocket[boostRocket];
                PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
                GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
                boostRocket++;
                PlayerPrefs.SetInt("BoostRocket", boostRocket);
                StartRocket();
            }
            else
            {
                CostAds();
            }
        }
        else
        {

        }

    }

    //-----------------------------------------------------------------------------Factor

    void AwakeFactor()
    {
        boostFactor = PlayerPrefs.GetInt("BoostFactor");
        staticValueFactor = valueFactor[boostFactor];
        StartFactor();
    }

    void StartFactor()
    {

        for (int i = 0; i <= boostFactor; i++)
        {
            lightFactor[i].SetActive(true);
            lightFactor[i].GetComponent<Image>().color = new Color(0, 0.7f, 1, 1);
            if (i < 9)
            {
                lightFactor[i + 1].SetActive(true);
                lightFactor[i + 1].GetComponent<Image>().color = new Color(0, 0.85f, 0, 1);
                textButtonFactor.text = "" + costFactor[i];
            }
            else
            {
                textButtonFactor.text = "Full";
            }
            if (i == boostFactor)
            {
                textLightFactor[i].text = "" + valueFactor[i];
                if (i > 0)
                {
                    textLightFactor[i - 1].text = "";
                }
                if (i < 9)
                {
                    textLightFactor[i + 1].text = "+" + valueStringFactor;
                }
                staticValueFactor = valueFactor[boostFactor];
            }
        }

    }

    public void ButtonFactor()
    {
        if (boostFactor < 9)
        {
            if (HightScore.coinHightCounter >= costFactor[boostFactor])
            {
                HightScore.coinHightCounter = HightScore.coinHightCounter - costFactor[boostFactor];
                PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
                GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
                boostFactor++;
                PlayerPrefs.SetInt("BoostFactor", boostFactor);
                StartFactor();
            }
            else
            {
                CostAds();
            }
        }
        else
        {

        }

    }

    //-----------------------------------------------------------------------------Hearth

    void AwakeHearth()
    {
        if (PlayerPrefs.HasKey("BoostHearth"))
        {
            boostHearth = PlayerPrefs.GetInt("BoostHearth");
        }
        else
        {
            boostHearth = 2;
            PlayerPrefs.SetInt("BoostHearth", boostHearth);
        }
            

        staticValueHearth = valueHearth[boostHearth];
        StartHearth();
    }

    void StartHearth()
    {

        for (int i = 0; i <= boostHearth; i++)
        {
            lightHearth[i].SetActive(true);
            lightHearth[i].GetComponent<Image>().color = new Color(0, 0.7f, 1, 1);
            if (i < 4)
            {
                lightHearth[i + 1].SetActive(true);
                lightHearth[i + 1].GetComponent<Image>().color = new Color(0, 0.85f, 0, 1);
                textButtonHearth.text = "" + costHearth[i];
            }
            else
            {
                textButtonHearth.text = "Full";
            }
            if (i == boostHearth)
            {
                textLightHearth[i].text = "" + valueHearth[i];
                if (i > 0)
                {
                    textLightHearth[i - 1].text = "";
                }
                if (i < 4)
                {
                    textLightHearth[i + 1].text = "+" + valueStringHearth;
                }
                staticValueHearth = valueHearth[boostHearth];
            }
        }

    }

    public void ButtonHearth()
    {
        if (boostHearth < 4)
        {
            if (HightScore.coinHightCounter >= costHearth[boostHearth])
            {
                HightScore.coinHightCounter = HightScore.coinHightCounter - costHearth[boostHearth];
                PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
                GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
                boostHearth++;
                PlayerPrefs.SetInt("BoostHearth", boostHearth);
                StartHearth();
            }
            else
            {
                CostAds();
            }
        }
        else
        {

        }

    }

    //-----------------------------------------------------------------------------Slot

    void AwakeSlot()
    {
        if (PlayerPrefs.HasKey("BoostSlot"))
        {
            boostSlot = PlayerPrefs.GetInt("BoostSlot");
        }
        else
        {
            boostSlot = 1;
            PlayerPrefs.SetInt("BoostSlot", boostSlot);
        }
            

        staticValueSlot = valueSlot[boostSlot];
        StartSlot();
    }

    void StartSlot()
    {

        for (int i = 0; i <= boostSlot; i++)
        {
            lightSlot[i].SetActive(true);
            lightSlot[i].GetComponent<Image>().color = new Color(0, 0.7f, 1, 1);
            if (i < 4)
            {
                lightSlot[i + 1].SetActive(true);
                lightSlot[i + 1].GetComponent<Image>().color = new Color(0, 0.85f, 0, 1);
                textButtonSlot.text = "" + costSlot[i];
            }
            else
            {
                textButtonSlot.text = "Full";
            }
            if (i == boostSlot)
            {
                textLightSlot[i].text = "" + valueSlot[i];
                if (i > 0)
                {
                    textLightSlot[i - 1].text = "";
                }
                if (i < 4)
                {
                    textLightSlot[i + 1].text = "+" + valueStringSlot;
                }
                staticValueSlot = valueSlot[boostSlot];
            }
        }

    }

    public void ButtonSlot()
    {
        if (boostSlot < 4)
        {
            if (HightScore.coinHightCounter >= costSlot[boostSlot])
            {
                HightScore.coinHightCounter = HightScore.coinHightCounter - costSlot[boostSlot];
                PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
                GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
                boostSlot++;
                PlayerPrefs.SetInt("BoostSlot", boostSlot);
                StartSlot();
            }
            else
            {
                CostAds();
            }
        }
        else
        {

        }

    }


    public void CostAds()
    {
        GameObject.FindGameObjectWithTag("Ads").GetComponent<BonusCost>().StartCheck();
        GameObject.FindGameObjectWithTag("Ads").GetComponent<BonusCost>().ChekCoinAdsPanel();
    }

}
    

