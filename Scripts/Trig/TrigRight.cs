//using AndroidAudioBypass;
using UnityEngine;

public class TrigRight : MonoBehaviour
{
    public Transform empty;
    public Transform emptyCamera;
    public GameObject top;
    public GameObject saved;
    public GameObject[] hitObj;
    public GameObject[] hitParent;
    int hitSelector;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Asteroid" || collision.transform.tag == "Comet" || collision.transform.tag == "Enemy")
        {
            empty.position += new Vector3(4f, 0, 0);
            emptyCamera.position += new Vector3(2f, 0, 0);
            if (!saved.activeSelf)
            {
                //Registered.explosionSelector = 1;
                //top.GetComponent<Registered>().Slot();
            }
        }

        if (collision.transform.tag == "EnemyBullet")
        {
            if (!saved.activeSelf)
            {
                hitSelector = 0;
            }
            else
            {
                hitSelector = 1;
            }
            StartHit();
        }
    }

    void StartHit()
    {
        //GameObject.FindGameObjectWithTag("AudioController_Ricochet").GetComponent<BypassAudioSource>().Play();
        if (hitObj[hitSelector].activeSelf)
        {
            StopHit();
        }
        hitObj[hitSelector].transform.parent = null;
        hitObj[hitSelector].SetActive(true);
        Invoke("StopHit", 0.7f);

    }

    void StopHit()
    {
        hitObj[hitSelector].transform.parent = hitParent[hitSelector].transform;
        hitObj[hitSelector].transform.position = hitParent[hitSelector].transform.position;
        hitObj[hitSelector].SetActive(false);
    }
}
