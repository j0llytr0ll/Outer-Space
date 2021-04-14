using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAQMenu : MonoBehaviour
{
    public GameObject shop;
    public GameObject missions;
    public GameObject score;
    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().MenuBatton();
    }

    public void OnMissions()
    {
        shop.SetActive(false);
        missions.SetActive(true);
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<Bar>().MissionActiveAndOneActiveButton();
    }

    public void OffFAQ()
    {
        missions.SetActive(false);
        gameObject.SetActive(false);
        score.SetActive(true);
    }

    public void OffScore()
    {
        score.SetActive(false);
    }

    
}
