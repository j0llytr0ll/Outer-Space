using System.Collections;
using UnityEngine;

public class PanelWathc : MonoBehaviour
{
    public GameObject bonusActiveCoin;
    public GameObject bonusActiveKey;
    public GameObject bonusActiveDeilyGift;
    public void OnEnable()
    {
        StartCoroutine(CheckButton());
    }

    IEnumerator CheckButton()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            if (!bonusActiveCoin.activeSelf)
            {
                GameObject.FindGameObjectWithTag("Ads").GetComponent<BonusCost>().StartCheck();
                GameObject.FindGameObjectWithTag("Ads").GetComponent<BonusCost>().ChekCoin();

            } 
            else if (!bonusActiveKey.activeSelf)
            {
                GameObject.FindGameObjectWithTag("Ads").GetComponent<BonusCost>().StartCheck();
                GameObject.FindGameObjectWithTag("Ads").GetComponent<BonusCost>().ChekKey();
            }

            if (!bonusActiveDeilyGift.activeSelf)
            {
                GameObject.FindGameObjectWithTag("Canvas").GetComponent<DailyGifts>().OnEnable();
            }
            else
            {

            }
            bonusActiveKey.GetComponent<Animation>().Play("ButtonOne");
            yield return new WaitForSeconds(0.3f);
            bonusActiveCoin.GetComponent<Animation>().Play("ButtonTwo");
            yield return new WaitForSeconds(0.3f);
            bonusActiveDeilyGift.GetComponent<Animation>().Play("ButtonThree");
            yield return new WaitForSeconds(3f);
        }
        
    }

    public void OnDisable()
    {
        bonusActiveKey.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        bonusActiveCoin.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        bonusActiveDeilyGift.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
    }
}
