using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FAQClick : MonoBehaviour, IPointerDownHandler
{
    public GameObject bullet;
    private void SoundGunBullet()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Gun1").GetComponent<AudioSource>().Play();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundGunBullet();
        bullet.SetActive(true);
        GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().ClickDisable();
    }
}
