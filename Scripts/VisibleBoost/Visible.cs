using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Visible : MonoBehaviour
{
    public GameObject saved;
    public Text savedText;
    public GameObject rocket;
    public Text rocketText;
    public GameObject magnet;
    public Text magnetText;
    public static int countVisible;
    public static int secs;
    public static int rocketCount;


    private void Start()
    {
        countVisible = 0;
    }
    public void VissTest()
    {
        if (countVisible == 1)
        {
            SavedTest();
        }
        else if (countVisible == 2)
        {
            RocketTest();
        }
        else if (countVisible == 3)
        {

        }
    }
//----------------------------------------------------------------------------------------
    public void SavedTest()
    {
        if (saved.activeSelf)
        {
            secs = 5;           
        }
        else
        {
            StartCoroutine(SavedSec());
            saved.SetActive(true);            
            secs = 5;
        }
    }

    IEnumerator SavedSec()
    {
        yield return new WaitForSeconds(0);
        while (true)
        {
            for (int i = 0; i < secs; i+=0)
            {
                savedText.text = "" + secs;
                secs--;
                
                yield return new WaitForSeconds(1);
            }
            saved.SetActive(false);
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Saved").GetComponent<Sphere>().DestroySphere();
            countVisible = 0;
            
            yield return new WaitForSeconds(0);
            
            
        }


    }
    //----------------------------------------------------------------------------------------
    public void RocketTest()
    {
        if (saved.activeSelf)
        {
            SpawnGun.bulletTest = 3;
        }
        else
        {
            rocket.SetActive(true);
            SpawnGun.bulletTest = 3;
            rocketText.text = "" + SpawnGun.bulletTest;
            RocketText();

        }
    }
    public void RocketText()
    {
        for (int i = 0; i < SpawnGun.bulletTest; i += 0)
        {
            rocketText.text = "" + SpawnGun.bulletTest;
        }
    }
}
