using UnityEngine;

public class HierarchyBoost : MonoBehaviour
{
    public GameObject saved;
    public GameObject rocket;
    public GameObject magnet;
    public static int boostInt = 2;
    public GameObject referenceBoostSlot;
    public GameObject referenceVisibleBoost;
    public GameObject sphere;

    
    public void Hierarchy()
    {
        
        if (!saved.activeSelf)
        {
            
            if (!rocket.activeSelf)
            {
                if (!magnet.activeSelf)
                {
                    Boostslot.activSalf = 0;
                    if (boostInt == 1)
                    {
                        saved.SetActive(true);
                        boostInt = 0;
                    }
                    else if (boostInt == 2)
                    {
                        rocket.SetActive(true);
                        boostInt = 0;
                    }
                    else if (boostInt == 3)
                    {
                        magnet.SetActive(true);
                        boostInt = 0;
                    }
                }
                else
                {
                    Boostslot.activSalf++;
                    referenceBoostSlot.GetComponent<Boostslot>().BoostSlotOneActive();
                    boostInt = 0;
                }
            }
            else
            {
                Boostslot.activSalf++;
                referenceBoostSlot.GetComponent<Boostslot>().BoostSlotOneActive();
                boostInt = 0;
            }
        }
        else
        {
            Boostslot.activSalf++;
            referenceBoostSlot.GetComponent<Boostslot>().BoostSlotOneActive();
            boostInt = 0;
        }
    }

    

    public void ButtonClick()
    {
        
        if (saved.activeSelf)
        {
            sphere.SetActive(true);
            saved.SetActive(false);
            Invoke("TimerVisible", 0.0000000001f);
            SoundUseBonus();
            VisibleBoost.testVisTest = 1;
            
        }
        else if (rocket.activeSelf)
        {
            
            rocket.SetActive(false);
            Invoke("TimerVisible", 0.0000000001f);
            SoundUseBonus();
            VisibleBoost.testVisTest = 2;
            
        }
        else if (magnet.activeSelf)
        {
            magnet.SetActive(false);
            Invoke("TimerVisible", 0.0000000001f);
            SoundUseBonus();
            VisibleBoost.testVisTest = 3;
            
        }
    }

    private void SoundUseBonus()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_UseBonus").GetComponent<AudioSource>().Play();
        }
    }
    public void TimerVisible()
    {
        referenceVisibleBoost.GetComponent<VisibleBoost>().VisibleTest();
    }

    public void OverDisable()
    {
        saved.SetActive(false);
        rocket.SetActive(false);
        magnet.SetActive(false);
        boostInt = 0;
    }

}
