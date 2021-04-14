using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] bullet;
    public GameObject[] rocket;
    public static bool bulletStatus;
    public static bool rocketStatus = false;

    public void OnEnableBullet()
    {
        bulletStatus = true;
        StartCoroutine(Bullet());
    }
    IEnumerator Bullet()
    {
        while (bulletStatus == true)
        {
            SoundGunBullet();
            for (int i = 0; i < bullet.Length; i++)
            {
                if (!bullet[i].activeSelf)
                {
                    bullet[i].SetActive(true);
                    break;
                }
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void OnRocket()
    {        
        StopCoroutine(Bullet());
        bulletStatus = false;
        rocketStatus = true;
        StartCoroutine(Rocket());
    }

    public void DisbleRocket()
    {
        StopCoroutine(Rocket());
        rocketStatus = false;
        bulletStatus = true;
        StartCoroutine(Bullet());
    }

    public void OfGun()
    {
        StopAllCoroutines();
        bulletStatus = false;
        rocketStatus = false;
    }
    IEnumerator Rocket()
    {
        SoundGunRocket();
        while (rocketStatus == true)
        {
            for (int i = 0; i < rocket.Length; i++)
            {
                if (!rocket[i].activeSelf)
                {
                    rocket[i].SetActive(true);
                    break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        SoundGunRocketOff();
    }

    private void SoundGunBullet()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Gun1").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundGunRocket()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Gun2").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundGunRocketOff()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Gun2").GetComponent<AudioSource>().Stop();
        }
    }

}
