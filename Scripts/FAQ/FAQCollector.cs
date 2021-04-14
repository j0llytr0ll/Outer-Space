using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAQCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Comet")
        {
            if (FAQ.helpSelect[1] != "off")
            {
                FAQ.helpSelect[1] = "true";
                GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().HelpButton();
            }
        }

        if (collision.transform.tag == "Asteroid")
        {
            if (FAQ.helpSelect[2] != "off")
            {
                FAQ.helpSelect[2] = "true";
                GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().HelpButton();
            }
        }

        if (collision.transform.tag == "Enemy")
        {
            if (FAQ.helpSelect[3] != "off")
            {
                FAQ.helpSelect[3] = "true";
                GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().HelpButton();
            }
        }

        if (collision.transform.tag == "Sphere")
        {
            if (FAQ.helpSelect[4] != "off")
            {
                FAQ.helpSelect[4] = "true";
                GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().HelpButton();
            }
        }

        if (collision.transform.tag == "Magnet")
        {
            if (FAQ.helpSelect[5] != "off")
            {
                FAQ.helpSelect[5] = "true";
                GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().HelpButton();
            }
        }

        if (collision.transform.tag == "RocketTest")
        {
            if (FAQ.helpSelect[6] != "off")
            {
                FAQ.helpSelect[6] = "true";
                GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().HelpButton();
            }
        }

        if (collision.transform.tag == "Factor")
        {
            if (FAQ.helpSelect[7] != "off")
            {
                FAQ.helpSelect[7] = "true";
                GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().HelpButton();
            }
        }

    }
}
