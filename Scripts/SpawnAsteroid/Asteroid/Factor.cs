using UnityEngine;

public class Factor : MonoBehaviour
{
    public GameObject nullObj;
    public GameObject factorVis;
    private void OnEnable()
    {
        BoostSpawn.startFactor = 0;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Collector")
        {
            SoundBonusFactor();
            gameObject.SetActive(false);
            Invoke("ResetEnemy", 0.7f);
            Boost();
        }

        if (collision.transform.tag == "Plane")
        {
            gameObject.SetActive(false);
            ResetEnemy();
        }


    }

    public void Boost()
    {

        HudScr.factor = 2;
        factorVis.SetActive(true);
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().coinfactor.text = "x" + (HudScr.coinObj * HudScr.factor);
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().scorefactor.text = "x" + (HudScr.coinObj * HudScr.factor);
    }
    public void ResetEnemy()
    {
        nullObj.GetComponent<AsteroidMovment>().ResetEnemy();
        transform.parent.gameObject.SetActive(false);
    }

    private void SoundBonusFactor()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_BonusFactor").GetComponent<AudioSource>().Play();
        }
    }
}
