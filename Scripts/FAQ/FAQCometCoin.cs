using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAQCometCoin : MonoBehaviour
{
    public GameObject nullObj;
    public GameObject boostSpawn;
    private Rigidbody rig;
    float tumbl = 150;
    public void ResetEnemy()
    {
        nullObj.GetComponent<FAQCometMovment>().ResetEnemy();
        gameObject.transform.parent = nullObj.transform.GetChild(0).transform;
        gameObject.transform.position = nullObj.transform.position;
        gameObject.transform.rotation = Quaternion.identity;
    }

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartMagnet();
    }

    public void StartMagnet()
    {
        if (MagnetVisible.magnetTest == true)
        {
            gameObject.transform.parent = null;
            //rig = GetComponent<Rigidbody>();
            rig.isKinematic = false;
            rig.angularVelocity = new Vector3(0, 1, 0) * tumbl;
            StartCoroutine(MagnetPos());
        }
    }

    IEnumerator MagnetPos()
    {
        yield return new WaitForSeconds(0);
        while (gameObject.activeSelf)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, GameObject.FindGameObjectWithTag("Collector").transform.position, Time.deltaTime * 6);
            yield return new WaitForSeconds(0);
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Plane")
        {
            if (rig.isKinematic == false)
            {
                rig.isKinematic = true;
            }
            /*if (MagnetVisible.magnetTest == true)
            {
                rig.isKinematic = true;
            }*/
            gameObject.SetActive(false);
            ResetEnemy();
            
        }

        if (collision.transform.tag == "Collector")
        {
            if (rig.isKinematic == false)
            {
                rig.isKinematic = true;
            }
            /*if (MagnetVisible.magnetTest == true)
            {
                rig.isKinematic = true;
            }*/
            gameObject.SetActive(false);
            Invoke("ResetEnemy", 0.7f);
            HudScr.coinCounter += (HudScr.coinObj * HudScr.factor);
            GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().CoinText();
        }


    }
}
