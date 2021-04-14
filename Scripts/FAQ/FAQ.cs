using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAQ : MonoBehaviour
{
    public GameObject panel;
    public GameObject swipe;
    public GameObject click;
    public GameObject comet;
    public GameObject helpButton;
    public GameObject[] help;
    public GameObject helpPanel;
    public GameObject faqColletctor;
    public GameObject faqMenu;
    public static string[] helpSelect = new string[8];
    public static string faq;
    public static string boostState;
    public GameObject faqCollectorBoost;
    string faqHelp;
    int helpOff;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Faq"))
        {
            faq = PlayerPrefs.GetString("Faq");
            StartFAQ();
        }
        else
        {
            faq = "true";
            StartFAQ();
        }

        if (PlayerPrefs.HasKey("FaqHelp"))
        {           
            faqHelp = PlayerPrefs.GetString("FaqHelp");

        }
        else
        {           
            faqHelp = "true";
            PlayerPrefs.SetString("FaqHelp", faqHelp);
        }

        if (PlayerPrefs.HasKey("FAQBoost"))
        {
            boostState = PlayerPrefs.GetString("FAQBoost");
            FAQBoost();
        }
        else
        {
            boostState = "true";
            PlayerPrefs.SetString("FAQBoost", boostState);
            FAQBoost();
        }

    }

    public void StartFAQ()
    {
        if (faq == "true")
        {
            GameObject.FindGameObjectWithTag("Empty").GetComponent<Gun>().OfGun();
            faqMenu.SetActive(true);
            Invoke("PanelStart", 1);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().StartLevel();
            GameObject.FindGameObjectWithTag("SpawnObject").GetComponent<SpawnAsteroid>().StartLevel();
            GameObject.FindGameObjectWithTag("SpawnObject").GetComponent<BoostSpawn>().Enable();
            GameObject.FindGameObjectWithTag("GameCanvas").GetComponent<Paus>().StartLevel();
            GameObject.FindGameObjectWithTag("Empty").GetComponent<Gun>().OnEnableBullet();
            FAQHelp();
        }
    }

    void FAQBoost()
    {
        if (boostState == "true")
        {
            faqCollectorBoost.SetActive(true);
        }
    }

    public void FAQHelp()
    {
        faqHelp = PlayerPrefs.GetString("FaqHelp");
        if (faqHelp == "true")
        {
            if (PlayerPrefs.HasKey("FaqHelp_Score"))
            {
                helpSelect[0] = PlayerPrefs.GetString("FaqHelp_Score");
            }
            else
                helpSelect[0] = "true";

            if (PlayerPrefs.HasKey("FaqHelp_Comet"))
            {
                helpSelect[1] = PlayerPrefs.GetString("FaqHelp_Comet");
            }
            else
                helpSelect[1] = "false";

            if (PlayerPrefs.HasKey("FaqHelp_Asteroid"))
            {
                helpSelect[2] = PlayerPrefs.GetString("FaqHelp_Asteroid");
            }
            else
                helpSelect[2] = "false";

            if (PlayerPrefs.HasKey("FaqHelp_Enemy"))
            {
                helpSelect[3] = PlayerPrefs.GetString("FaqHelp_Enemy");
            }
            else
                helpSelect[3] = "false";

            if (PlayerPrefs.HasKey("FaqHelp_Saved"))
            {
                helpSelect[4] = PlayerPrefs.GetString("FaqHelp_Saved");
            }
            else
                helpSelect[4] = "false";

            if (PlayerPrefs.HasKey("FaqHelp_Magnet"))
            {
                helpSelect[5] = PlayerPrefs.GetString("FaqHelp_Magnet");
            }
            else
                helpSelect[5] = "false";

            if (PlayerPrefs.HasKey("FaqHelp_Rocket"))
            {
                helpSelect[6] = PlayerPrefs.GetString("FaqHelp_Rocket");
            }
            else
                helpSelect[6] = "false";

            if (PlayerPrefs.HasKey("FaqHelp_Factor"))
            {
                helpSelect[7] = PlayerPrefs.GetString("FaqHelp_Factor");
            }
            else
                helpSelect[7] = "false";

            faqColletctor.SetActive(true);
            HelpButton();
        }
    }

    public void FAQHelpSave()
    {
        PlayerPrefs.SetString("FaqHelp_Score", helpSelect[0]);
        PlayerPrefs.SetString("FaqHelp_Comet", helpSelect[1]);
        PlayerPrefs.SetString("FaqHelp_Asteroid", helpSelect[2]);
        PlayerPrefs.SetString("FaqHelp_Enemy", helpSelect[3]);
        PlayerPrefs.SetString("FaqHelp_Saved", helpSelect[4]);
        PlayerPrefs.SetString("FaqHelp_Magnet", helpSelect[5]);
        PlayerPrefs.SetString("FaqHelp_Rocket", helpSelect[6]);
        PlayerPrefs.SetString("FaqHelp_Factor", helpSelect[7]);
    }

    void PanelStart()
    {        
        panel.SetActive(true);
    }

    public void SwipeStart()
    {
        panel.SetActive(false);
        swipe.SetActive(true);
    }

    public void ClickStart()
    {
        swipe.SetActive(false);
        comet.SetActive(true);
        click.SetActive(true);
    }

    public void ClickDisable()
    {
        swipe.SetActive(false);
        //click.SetActive(false);
        faq = "false";
        PlayerPrefs.SetString("Faq", faq);
        PlayerPrefs.SetString("FaqHelp", faqHelp);       
        StartGame();
        FAQHelp();
    }
    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().StartLevel();
        GameObject.FindGameObjectWithTag("SpawnObject").GetComponent<SpawnAsteroid>().StartLevel();
        GameObject.FindGameObjectWithTag("SpawnObject").GetComponent<BoostSpawn>().Enable();
        GameObject.FindGameObjectWithTag("GameCanvas").GetComponent<Paus>().StartLevel();
        GameObject.FindGameObjectWithTag("Empty").GetComponent<Gun>().OnEnableBullet();
    }

    public void HelpButton()
    {
        for (int i = 0; i < helpSelect.Length; i++)
        {
            if (helpSelect[i] == "true")
            {
                GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().ResetLevel();
                helpOff++;
                helpPanel.SetActive(true);
                helpButton.SetActive(false);
                help[i].SetActive(true);
                helpSelect[i] = "off";
                FAQHelpSave();
                Time.timeScale = 0;
                break;              
            }
        }        
    }

    public void OKButton()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().StartLevel();
        helpPanel.SetActive(false);
        //HelpCheck();
        for (int i = 0; i < helpSelect.Length; i++)
        {
            if (helpSelect[i] == "off")
            {
                help[i].SetActive(false);
            }
        }

        if (helpOff == 8)
        {
            faqColletctor.SetActive(false);
            faqHelp = "false";
            PlayerPrefs.SetString("FaqHelp", faqHelp);
            helpSelect[0] = "true";
            for (int r = 1; r < helpSelect.Length; r++)
            {
                helpSelect[r] = "false";
            }
        }
    }

    public void OffButton()
    {
        faqColletctor.SetActive(false);
        faqHelp = "false";
        PlayerPrefs.SetString("FaqHelp", faqHelp);
        helpSelect[0] = "true";
        for (int i = 1; i < helpSelect.Length; i++)
        {
            helpSelect[i] = "false";
        }
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().StartLevel();
        helpPanel.SetActive(false);
    }

    public void HelpCheck()
    {
        for (int i = 0; i < helpSelect.Length; i++)
        {
            
            if (helpSelect[i] == "true")
            {
                helpButton.SetActive(true);
                break;
            }
        }
        if (helpOff == 8)
        {
            faqColletctor.SetActive(false);
            faqHelp = "false";
            PlayerPrefs.SetString("FaqHelp", faqHelp);
            helpSelect[0] = "true";
            for (int r = 1; r < helpSelect.Length; r++)
            {
                helpSelect[r] = "false";
            }
        }
    }

    private void OnDisable()
    {
        faqColletctor.SetActive(false);
    }

    public void SoundClick()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Click").GetComponent<AudioSource>().Play();
        }
    }
}
