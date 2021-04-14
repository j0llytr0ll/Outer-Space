using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAQComet : MonoBehaviour
{
    public GameObject nullObj;
    public GameObject coin;
    public GameObject[] hit;
    int hitSelector;
    public GameObject[] explosion;
    int explosionSelector;
    public GameObject boostObject;



    void OnEnable()
    {
        nullObj.GetComponent<FAQCometMovment>().MovmentEnemy();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Plane")
        {
            gameObject.SetActive(false);
            ResetEnemy();
            GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().StartGame();
        }
        //-------------------------------------------------------Hit

        if (collision.transform.tag == "Bullet")
        {
            SoundExplosion();
            hitSelector = 0;
            Hit();
            explosionSelector = 2;
            Explosion();
            gameObject.SetActive(false);
            nullObj.GetComponent<FAQCometMovment>().RotateEnemy();
            coin.SetActive(true);
            GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().StartGame();
        }

        if (collision.transform.tag == "EnemyBullet")
        {
            hitSelector = 1;
            Hit();
        }
        //-------------------------------------------------------Dust
        if (collision.transform.tag == "Right" || collision.transform.tag == "Left" || collision.transform.tag == "Up" || collision.transform.tag == "Down" || collision.transform.tag == "Player")
        {
            SoundIcePlayer();
            explosionSelector = 1;
            Explosion();
            gameObject.SetActive(false);
            Invoke("ResetEnemy", 0.7f);
            //GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().StartGame();
        }
        //-------------------------------------------------------
        if (collision.transform.tag == "Player")
        {
            SoundIcePlayer();
            explosionSelector = 1;
            Explosion();
            gameObject.SetActive(false);
            Invoke("ResetEnemy", 0.7f);
            GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().StartGame();
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
        nullObj.GetComponent<FAQCometMovment>().ResetEnemy();
    }
}
