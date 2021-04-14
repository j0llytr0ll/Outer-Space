using UnityEngine;
using UnityEngine.EventSystems;

public class Registered : MonoBehaviour
{

    private int hit = 0;
    public Transform slotPosition;
    public GameObject[] player;
    public GameObject[] hitObj;
    public GameObject[] hitParent;
    int hitSelector;
    public GameObject[] explosionObj;
    public GameObject explosionParent;
    public static int explosionSelector;
    public GameObject[] pos;
    public GameObject gameOverPanel;
    public GameObject saved;

    public GameObject hudScr;
    public GameObject spawnObject;

    public void OnEnable()
    {
        hit = 0;
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(true);
        }
        for (int i = 0; i < ShoBoost.staticValueHearth; i++)
        {
            slotPosition.GetChild(i).gameObject.SetActive(true);
            slotPosition.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
        }

        slotPosition.position = pos[ShoBoost.staticValueHearth - 2].transform.position;

    }

    

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.transform.tag == "Comet")
        {
            if (!saved.activeSelf)
            {
                explosionSelector = 1;
                Slot();
                if (Options.vibrationStats == "true")
                {
                    Handheld.Vibrate();
                }
            }
        }

        if (collision.transform.tag == "Enemy")
        {
            if (!saved.activeSelf)
            {
                explosionSelector = 1;
                for (int i = 0; i < 2; i++)
                {
                    Slot();
                }
            }
        }

        if (collision.transform.tag == "EnemyBullet")
        {
            if (!saved.activeSelf)
            {
                SoundHit();
                explosionSelector = 0;
                hitSelector = 0;
                Slot();
                if (Options.vibrationStats == "true")
                {
                    Handheld.Vibrate();
                }
            }
            else
            {
                SoundRicochet();
                hitSelector = 1;                
            }
            StartHit();
        }

        if (collision.transform.tag == "Sphere")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().SavedMission();
        }

        if (collision.transform.tag == "Magnet")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().MagnetMission();
        }

        if (collision.transform.tag == "RocketTest")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().RocketMission();
        }

        if (collision.transform.tag == "Factor")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().FactorMission();
        }

    }

    private void SoundExplosion()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Explosion").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundHit()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Hit_Player").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundRicochet()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Ricochet").GetComponent<AudioSource>().Play();
        }
    }      

    private void SoundEngineShip()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_EngineShip").GetComponent<AudioSource>().Stop();
        }
    }

    public void DeathAsteroid()
    {
        SoundExplosion();
        explosionSelector = 1;
        StartExplosion();
        Death();
    }
    void StartExplosion()
    {
        StopExplosion();
        Invoke("StopExplosion", 0.7f);
        explosionObj[explosionSelector].transform.parent = null;
        explosionObj[explosionSelector].SetActive(true);
    }

    void StopExplosion()
    {
        explosionObj[explosionSelector].transform.parent = explosionParent.transform;
        explosionObj[explosionSelector].transform.position = explosionParent.transform.position;
        explosionObj[explosionSelector].SetActive(false);

    }
    void StartHit()
    {
        StopHit();
        Invoke("StopHit", 0.7f);
        hitObj[hitSelector].transform.parent = null;
        hitObj[hitSelector].SetActive(true);

    }

    void StopHit()
    {
        hitObj[hitSelector].transform.parent = hitParent[hitSelector].transform;
        hitObj[hitSelector].transform.position = hitParent[hitSelector].transform.position;
        hitObj[hitSelector].SetActive(false);
    }



    public void Hill()
    {
        if (hit > 0)
        {
            slotPosition.GetChild(hit - 1).transform.GetChild(0).gameObject.SetActive(true);
            hit--;
        }
    }
    public void Slot()
    {          
        if (hit < ShoBoost.staticValueHearth - 1)
        {
            slotPosition.GetChild(hit).transform.GetChild(0).gameObject.SetActive(false);
            hit++;
        }
        else
        {
            slotPosition.GetChild(hit).transform.GetChild(0).gameObject.SetActive(false);
            SoundExplosion();
            StartExplosion();
            Death();
        }
    }

    
    void Death()
    {
        SoundEngineShip();
        if (Options.vibrationStats == "true")
        {
            Handheld.Vibrate();
        }
        for (int i = 0; i < ShoBoost.staticValueHearth; i++)
        {
            slotPosition.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }

        SpawnGun.bulletTest = 0;
        MagnetVisible.magnetTest = false;
        gameObject.SetActive(false);


        GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().OverGame();
        Invoke("DeathZero", 0.5f);
    }

    /*void OnEnable()
    {
        hit = 0;
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(true);
        }
        for (int i = 0; i < ShoBoost.staticValueHearth; i++)
        {
            slotPosition.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
        }
    }*/
    void OnDisable()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(false);
        }
        SoundGunRocketOff();
        hudScr.GetComponent<HudScr>().ResetLevel();
        spawnObject.GetComponent<BoostSpawn>().ResetLevel();
    }

    void DeathZero()
    {
        HudScr.factor = 1;
        gameOverPanel.SetActive(true);
        //gameOverPanel.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void SoundGunRocketOff()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Gun2").GetComponent<AudioSource>().Stop();
        }
    }
}