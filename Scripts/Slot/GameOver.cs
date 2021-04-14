using UnityEngine;
public class GameOver : MonoBehaviour
{
    
    public GameObject slotOne;  
    public GameObject slotTwo;   
    public GameObject slotThree;  
    public GameObject slotFour;   
    public GameObject slotFive;

    public GameObject player;
    public GameObject gameOver;
    public GameObject slotGameOver;

    public Transform slotPosition;

    public GameObject slotOnes;
    public GameObject slotTwos;
    public GameObject slotThrees;
    public GameObject slotFours;
    public GameObject slotFives;

    //public GameObject saved;

    //public GameObject referenceBoostSlot;
    //public GameObject referenceBoostSpawn;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Asteroid")
        {
            Slot();
        }

        if (collision.transform.tag == "Comet")
        {
            Slot();
        }

        if (collision.transform.tag == "Enemy")
        {
            Slot();
        }
        
        /*if (collision.transform.tag == "Sphere")
        {
            Invoke("Timer", 0.0000000001f);
            HierarchyBoost.boostInt = 1;
            var startCor = referenceBoostSpawn.GetComponent<BoostSpawn>();
            startCor.MethodToCall();

        }

        if (collision.transform.tag == "RocketTest")
        {
            Invoke("Timer", 0.0000000001f);
            HierarchyBoost.boostInt = 2;
            var startCor = referenceBoostSpawn.GetComponent<BoostSpawn>();
            startCor.MethodToCall();
        }
        
        if (collision.transform.tag == "Magnet")
        {
            Invoke("Timer", 0.0000000001f );
            HierarchyBoost.boostInt = 3;
            var startCor = referenceBoostSpawn.GetComponent<BoostSpawn>();
            startCor.MethodToCall();
        }*/

    }

    /*void Timer()
    {
        var salfTest = referenceBoostSlot.GetComponent<Boostslot>();
        salfTest.BoostSlotOneActive();
    }*/

            //SpawnGun.bulletTest = 1;
            //SpawnGun.StartText();

    public void Start()
    {
        /*if (Shop.saveHeart == 2)
        {
            slotTwo.SetActive(true);
            slotTwos.SetActive(true);
            slotPosition.position += new Vector3(-25f, 0, 0);
        }*/

        if (ShoBoost.staticValueHearth == 3)
        {
            slotTwo.SetActive(true);
            slotTwos.SetActive(true);
            slotThree.SetActive(true);
            slotThrees.SetActive(true);
            slotPosition.position += new Vector3(-50f, 0, 0);
        }

        else if (ShoBoost.staticValueHearth == 4)
        {
            slotTwo.SetActive(true);
            slotTwos.SetActive(true);
            slotThree.SetActive(true);
            slotThrees.SetActive(true);
            slotFour.SetActive(true);
            slotFours.SetActive(true);
            slotPosition.position += new Vector3(-75f, 0, 0);
        }

        else if (ShoBoost.staticValueHearth == 5)
        {
            slotTwo.SetActive(true);
            slotTwos.SetActive(true);
            slotThree.SetActive(true);
            slotThrees.SetActive(true);
            slotFour.SetActive(true);
            slotFours.SetActive(true);
            slotFive.SetActive(true);
            slotFives.SetActive(true);
            slotPosition.position += new Vector3(-100f, 0, 0);
        }
    }

    public void Slot()
    {
        if (slotOnes.activeSelf)
        {
            slotOnes.SetActive(false);
        }

        else if (slotTwos.activeSelf)
        {
            slotTwos.SetActive(false);
        }

        else if (slotThrees.activeSelf)
        {
            slotThrees.SetActive(false);
        }

        else if (slotFours.activeSelf)
        {
            slotFours.SetActive(false);
        }

        else if (slotFives.activeSelf)
        {
            slotFives.SetActive(false);

        }

        else Event();
    }

    public void Event()
    {
        HightScore.HightCoin();
        HightScore.HightScoreCounter();

        GameObject.FindGameObjectWithTag("VisibleMagnet").GetComponent<MagnetVisible>().StopMagn();

        MagnetVisible.magnetTest = false;
        player.SetActive(false);
        gameOver.SetActive(true);
        Invoke("Invok", 0.5f);
    }

    public void Invok()
    {
        Time.timeScale = 0f;
        slotGameOver.SetActive(true);
    }

    
}