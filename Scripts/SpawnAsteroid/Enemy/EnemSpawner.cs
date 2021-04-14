using System.Collections;
using UnityEngine;

public class EnemSpawner : MonoBehaviour
{
    public GameObject nullObj;

    public GameObject[] bullet;
    int bulletSelect;

    public GameObject[] boost;
    int boostSelect;

    public GameObject coin;

    public GameObject[] hit;
    int hitSelector;
    public GameObject[] explosion;
    int explosionSelector;

    int hitRegister;

    public GameObject boostObject;

    int score;

    void OnEnable()
    {
        nullObj.GetComponent<EnemyMovment>().MovmentEnemy();
        //Invoke("BulletSpawn", 0.2f);
        //BulletSpawn();
        //StartCoroutine(BulletSpawn());
    }

    public void BulletSpawn()
    {
        SoundEnemyGun();
        for (int i = 0; i < bullet.Length; i++)
        {
            //bulletSelect = Random.Range(0, bullet.Length);
            if (!bullet[i].activeSelf)
            {
                bullet[i].SetActive(true);
                break;
            }
        }
    }
    /*IEnumerator BulletSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        while (gameObject.activeSelf)
        {
            for (int i = 0; i < bullet.Length; i++)
            {
                //bulletSelect = Random.Range(0, bullet.Length);
                if (!bullet[i].activeSelf)
                {
                    bullet[i].SetActive(true);                   
                    break;
                }
            }
            yield return new WaitForSeconds(4);
        }
    }*/

    void OnDisable()
    {
        //StopCoroutine(BulletSpawn());
        CancelInvoke();
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

            if (hitRegister < 1)
            {
                SoundPetard();
                hitRegister++;
                hitSelector = 2;
                Hit();
            }
            else
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().HearthMission();
                SoundExplosion();
                explosionSelector = 0;
                Explosion();
                gameObject.SetActive(false);
                Boost();
            }
        }

        if (collision.transform.tag == "Bullet")
        {
            if (hitRegister < 1)
            {
                SoundPetard();
                hitRegister++;
                hitSelector = 0;
                Hit();
            }
            else
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().HearthMission();
                SoundExplosion();
                explosionSelector = 2;
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
        if (collision.transform.tag == "Right" || collision.transform.tag == "Left" || collision.transform.tag == "Up" || collision.transform.tag == "Down" || collision.transform.tag == "Player")
        {
            SoundExplosion();
            explosionSelector = 1;
            Explosion();
            gameObject.SetActive(false);
            Invoke("ResetEnemy", 0.7f);
        }
        //-------------------------------------------------------
        if (collision.transform.tag == "Player")
        {
            SoundExplosion();
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

    private void SoundPetard()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Petard").GetComponent<AudioSource>().Play();
        }
    }
    private void SoundEnemyGun()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_EnemyGun").GetComponent<AudioSource>().Play();
        }
    }
    void Hit()
    {      
        
        hit[hitSelector].SetActive(true);
    }

    void Explosion()
    {
        score = 25 * (HudScr.scoreObj * HudScr.factor);
        HudScr.plusScoreInt = score;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().PlusScore();
        HudScr.scoreCounter += score;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().ScoreText();
        hitRegister = 0;
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
        hitRegister = 0;
        nullObj.GetComponent<EnemyMovment>().ResetEnemy();
    }
    public void Boost()
    {
        boostObject.SetActive(true);
        nullObj.GetComponent<EnemyMovment>().RotateEnemy();
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
