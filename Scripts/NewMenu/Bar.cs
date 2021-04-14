using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public GameObject menu;
    public GameObject bar;
    public GameObject tapToGame;
    public GameObject[] images;
    public GameObject[] startMenuActive;

    public GameObject[] shopBuyActive;

    public GameObject[] missionActiveAndOneActive;

    public GameObject[] optionsActive;

    public GameObject[] dailyGiftsActive;

    public GameObject[] bonusActive;

    public GameObject[] costPanel;

    public GameObject[] noCoinPanel;
    public void MenuBatton()
    {
        if (!menu.activeSelf)
        {

            menu.SetActive(true);
            tapToGame.SetActive(false);            
            for (int i = 0; i < startMenuActive.Length; i++)
            {
                startMenuActive[i].SetActive(true);
            }
            bar.SetActive(false);
        }
        else
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].SetActive(false);
            }           
            tapToGame.SetActive(true);
            bar.SetActive(true);
            menu.SetActive(false);
        }
    }
    
    public void ShopActiveAndBoostShop()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
        for (int i = 0; i < startMenuActive.Length; i++)
        {
            startMenuActive[i].SetActive(true);
        }
    }

    public void ShopBuyActiveButton()
    {
        if (!menu.activeSelf)
        {
            menu.SetActive(true);
            tapToGame.SetActive(false);
            bar.SetActive(false);
        }
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
        for (int i = 0; i < shopBuyActive.Length; i++)
        {
            shopBuyActive[i].SetActive(true);
        }
    }

    public void MissionActiveAndOneActiveButton()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
        for (int i = 0; i < missionActiveAndOneActive.Length; i++)
        {
            missionActiveAndOneActive[i].SetActive(true);
        }
        //GameObject.FindGameObjectWithTag("Canvas").GetComponent<Missions>().Start();
        //gameObject.GetComponent<Missions>().Start();
    }

    public void OptionsActiveButton()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
        for (int i = 0; i < optionsActive.Length; i++)
        {
            optionsActive[i].SetActive(true);
        }
    }

    public void DailyGiftsActiveButton()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
        for (int i = 0; i < dailyGiftsActive.Length; i++)
        {
            dailyGiftsActive[i].SetActive(true);
        }
    }

    public void BonusActiveButton()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
        for (int i = 0; i < bonusActive.Length; i++)
        {
            bonusActive[i].SetActive(true);
        }
    }

    public void OffCostPanel()
    {
        for (int i = 0; i < costPanel.Length; i++)
        {
            costPanel[i].SetActive(false);
        }
    }

    public void ExitNoCoinPanel()
    {
        for (int i = 0; i < noCoinPanel.Length; i++)
        {
            noCoinPanel[i].SetActive(false);
        }
    }

    
    public void SoundClick()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Click").GetComponent<AudioSource>().Play();
        }
    }
}
