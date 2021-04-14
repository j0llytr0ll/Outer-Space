using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAQCollectorBoost : MonoBehaviour
{
    public GameObject faqBoost;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Sphere" || collision.transform.tag == "Magnet"|| collision.transform.tag == "RocketTest")
        {
            faqBoost.SetActive(true);
            FAQ.boostState = "false";
            PlayerPrefs.SetString("FAQBoost", FAQ.boostState);
            gameObject.SetActive(false);
        }
    }
}
