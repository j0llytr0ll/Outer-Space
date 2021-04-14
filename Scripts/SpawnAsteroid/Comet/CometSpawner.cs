using System.Configuration;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public GameObject nullObj;

    public GameObject[] boost;
    int boostSelect;

    public GameObject coin;

    public GameObject[] hit;
    int hitSelector;
    public GameObject[] explosion;
    int explosionSelector;

    public GameObject boostObject;

    public GameObject saved;

    int score;



    void OnEnable()
    {
        nullObj.GetComponent<CometMovment>().MovmentEnemy();

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Plane")
        {
            gameObject.SetActive(false);
            ResetEnemy();
        }
        //-------------------------------------------------------Hit
        if (collision.transform.tag == "Rocket")
        {
            SoundExplosion();
            hitSelector = 2;
            Hit();
            explosionSelector = 0;
            Explosion();
            gameObject.SetActive(false);
            Boost();
        }

        if (collision.transform.tag == "Bullet")
        {
            SoundExplosion();
            hitSelector = 0;
            Hit();
            explosionSelector = 2;
            Explosion();
            gameObject.SetActive(false);
            Boost();
        }

        if (collision.transform.tag == "EnemyBullet")
        {
            hitSelector = 1;
            Hit();
        }
        //-------------------------------------------------------Dust
        if (collision.transform.tag == "Right" || collision.transform.tag == "Left" || collision.transform.tag == "Up" || collision.transform.tag == "Down" || collision.transform.tag == "Player")
        {
            if (saved.activeSelf)
                SoundIce();
            else
                SoundIcePlayer();
            explosionSelector = 1;
            Explosion();
            gameObject.SetActive(false);
            Invoke("ResetEnemy", 0.7f);           
        }
        //-------------------------------------------------------
        if (collision.transform.tag == "Player")
        {
            if (saved.activeSelf)
                SoundIce();
            else
                SoundIcePlayer();
            explosionSelector = 1;
            Explosion();
            gameObject.SetActive(false);
            Invoke("ResetEnemy", 0.7f);          
        }
    }

    private void SoundExplosion()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Explosion").GetComponent<AudioSource>().Play();
        }
    }
    

    private void SoundIce()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Ice").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundIcePlayer()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Ice_Player").GetComponent<AudioSource>().Play();
        }
    }
    void Hit()
    {

        hit[hitSelector].SetActive(true);
    }

    void Explosion()
    {
        score = 10 * (HudScr.scoreObj * HudScr.factor);
        HudScr.plusScoreInt = score;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().PlusScore();
        HudScr.scoreCounter += score;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().ScoreText();
        explosion[explosionSelector].SetActive(true);
    }

    public void RestartScen()
    {
        gameObject.SetActive(false);
        ResetEnemy();
    }

    public void StopParticle()
    {
        explosion[explosionSelector].SetActive(false);
        hit[hitSelector].SetActive(false);
    }

    public void ResetEnemy()
    {
        nullObj.GetComponent<CometMovment>().ResetEnemy();       
    }
    public void Boost()
    {
        boostObject.SetActive(true);
        nullObj.GetComponent<CometMovment>().RotateEnemy();
        if (BoostSpawn.boost == 0)
        {
            coin.SetActive(true);
        }
        else
        {
            boostSelect = Random.Range(0, boost.Length);
            boost[boostSelect].SetActive(true);

        }
    }
}
