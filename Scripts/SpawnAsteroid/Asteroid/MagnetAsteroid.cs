using UnityEngine;

public class MagnetAsteroid : MonoBehaviour
{
    public GameObject nullObj;
    public GameObject boostSpawn;
    public GameObject boostSlot;

    private void OnEnable()
    {
        BoostSpawn.boost = 0;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Collector")
        {
            SoundBonus();
            gameObject.SetActive(false);
            ResetEnemy();
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
        HierarchyBoost.boostInt = 3;
        boostSlot.GetComponent<Boostslot>().BoostSlotOneActive();
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
