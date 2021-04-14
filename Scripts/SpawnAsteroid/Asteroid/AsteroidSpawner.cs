using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject nullObj;

    public GameObject[] boost;
    int boostSelect;
    int[] heartKey = new int[2];
    int selectHeartKey;
    public GameObject[] dustPosition;
    int dustSelector;
    public GameObject[] hit;
    int hitSelector;
    public GameObject[] explosion;
    int explosionSelector;
    int hitRegister;
    public GameObject coin;

    public GameObject saved;

    private int[] table = new int[] {70, 15, 15};

    private int total;
    private int randomNumber;

    public GameObject boostObject;

    int score;

    void OnEnable()
    {
        nullObj.GetComponent<AsteroidMovment>().MovmentEnemy();

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Plane")
        {
            gameObject.SetActive(false);
            hitRegister = 0;
            ResetEnemy();
        }
        //-------------------------------------------------------Hit
        if (collision.transform.tag == "Rocket")
        {
            /*SoundExplosion();
            hitSelector = 2;
            Hit();
            explosionSelector = 0;
            Explosion();
            gameObject.SetActive(false);
            Boost();*/

            if (hitRegister < 2)
            {
                SoundPetard();
                hitRegister++;
                hitSelector = 2;
                Hit();
            }
            else
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().EnemyObjectsMission();
                SoundExplosion();
                explosionSelector = 0;
                Explosion();
                gameObject.SetActive(false);
                Boost();
            }
        }

        if (collision.transform.tag == "Bullet")
        {
            /*SoundPetard();
            hitSelector = 0;
            Hit();*/

            if (hitRegister < 2)
            {
                SoundPetard();
                hitRegister++;
                hitSelector = 0;
                Hit();
            }
            else
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().EnemyObjectsMission();
                SoundExplosion();
                explosionSelector = 0;
                Explosion();
                gameObject.SetActive(false);
                Boost();
            }
        }

        if (collision.transform.tag == "EnemyBullet")
        {
            hitSelector = 1;
            Hit();
        }
        //-------------------------------------------------------Dust
        if (collision.transform.tag == "Up")
        {
            SoundHitAsteroid();
            dustSelector = 1;
            Dust();
        }
        if (collision.transform.tag == "Down")
        {
            SoundHitAsteroid();
            dustSelector = 0;
            Dust();
        }
        if (collision.transform.tag == "Left")
        {
            SoundHitAsteroid();
            dustSelector = 3;
            Dust();
        }
        if (collision.transform.tag == "Right")
        {
            SoundHitAsteroid();
            dustSelector = 2;
            Dust();
        }              
        //-------------------------------------------------------
        if (collision.transform.tag == "Player")
        {
            if (saved.activeSelf)
            {
                SoundExplosion();
                explosionSelector = 1;
                Explosion();
                gameObject.SetActive(false);
                Invoke("ResetEnemy", 0.7f);
                saved.SetActive(false);
            }
            else
                GameObject.FindGameObjectWithTag("Player").GetComponent<Registered>().DeathAsteroid();

        }
    }

    private void SoundExplosion()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Explosion").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundPetard()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Petard").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundHitAsteroid()
    {        
        if (Options.soundStats == "true")
        {
            if (saved.activeSelf)
            {
                GameObject.FindGameObjectWithTag("AudioController_Ricochet").GetComponent<AudioSource>().Play();
            }
            else
                GameObject.FindGameObjectWithTag("AudioController_Hit_Asteroid").GetComponent<AudioSource>().Play();

        }
    }
    void Dust()
    {

        dustPosition[dustSelector].SetActive(false);
        dustPosition[dustSelector].SetActive(true);
    }
    void Hit()
    {

        hit[hitSelector].SetActive(false);
        hit[hitSelector].SetActive(true);
    }

    void Explosion()
    {
        score = 50 * (HudScr.scoreObj * HudScr.factor);
        HudScr.plusScoreInt = score;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().PlusScore();
        HudScr.scoreCounter += score;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().ScoreText();
        hitRegister = 0;
        explosion[explosionSelector].SetActive(false);
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
        dustPosition[dustSelector].SetActive(false);
    }

    
    public void ResetEnemy()
    {
        explosion[explosionSelector].SetActive(false);
        hit[hitSelector].SetActive(false);
        dustPosition[dustSelector].SetActive(false);
        nullObj.GetComponent<AsteroidMovment>().ResetEnemy();
    }
    public void Boost()
    {
        boostObject.SetActive(true);
        nullObj.GetComponent<AsteroidMovment>().RotateEnemy();
        if (BoostSpawn.startFactor == 0)
        {
            coin.SetActive(true);
        }
        else
        {
            total = 0;
            randomNumber = 0;

            foreach (var item in table)
            {
                total += item;
            }

            randomNumber = Random.Range(0, total);

            for (int i = 0; i < table.Length; i++)
            {
                if (randomNumber <= table[i])
                {
                    boost[i].SetActive(true);                  
                    return;
                }
                else
                {
                    randomNumber -= table[i];
                }
            }

        }

    }
}
