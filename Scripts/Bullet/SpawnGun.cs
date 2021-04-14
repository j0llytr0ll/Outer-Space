using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnGun : MonoBehaviour, IPointerDownHandler
{
    public GameObject[] bullet;
    int bulletSelect;
    public GameObject[] rocket;
    int rocketSelect;
    public static int bulletTest;
    
    
      
    void Start()
    {
        bulletTest = 0;
    }

    public void Bullet()
    {
        for (int i = 0; i < bullet.Length; i++)
        {
            bulletSelect = Random.Range(0, bullet.Length);
            if (!bullet[bulletSelect].activeSelf)
            {
                bullet[bulletSelect].SetActive(true);
                break;
            }
        }
    }

    public void Rocket()
    {
        for (int i = 0; i < rocket.Length; i++)
        {
            rocketSelect = Random.Range(0, rocket.Length);
            if (!rocket[rocketSelect].activeSelf)
            {
                rocket[rocketSelect].SetActive(true);
                break;
            }
        }
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
    public void OnPointerDown(PointerEventData eventData)
    {
        if (bulletTest == 0)
        {
            SoundGunBullet();
            Bullet();
        }
        else 
        {
            SoundGunRocket();
            Rocket();
            bulletTest--;
            //GameObject.FindGameObjectWithTag("VisibleRocket").GetComponent<RocketVisible>().VisibleRocket();
        }
                
    }
}
