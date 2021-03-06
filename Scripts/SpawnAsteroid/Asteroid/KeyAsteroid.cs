using UnityEngine;

public class KeyAsteroid : MonoBehaviour
{
    public GameObject nullObj;

    private void OnEnable()
    {
        BoostSpawn.startFactor = 0;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Collector")
        {
            SoundBonus();
            gameObject.SetActive(false);
            Invoke("ResetEnemy", 0.7f);
            Boost();
        }

        if (collision.transform.tag == "Plane")
        {
            gameObject.SetActive(false);
            ResetEnemy();
        }


    }

    public void Boost()
    {
        HightScore.keyHightCounter++;
        PlayerPrefs.SetInt("SaveKey", HightScore.keyHightCounter);
    }
    public void ResetEnemy()
    {
        nullObj.GetComponent<AsteroidMovment>().ResetEnemy();
    }

    private void SoundBonus()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Bonus").GetComponent<AudioSource>().Play();
        }
    }
}
