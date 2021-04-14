using UnityEngine;

public class FrontDetect : MonoBehaviour
{
    public GameObject slotOne;
    public GameObject slotTwo;
    public GameObject slotThree;
    public GameObject slotFour;
    public GameObject slotFive;
    public GameObject slotGameOver;
    public GameObject player;
    public GameObject gameOver;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "KillObj")
        {
            slotOne.SetActive(false);
            slotTwo.SetActive(false);
            slotThree.SetActive(false);
            slotFour.SetActive(false);
            slotFive.SetActive(false);

            Cost();
        }

        if (collision.transform.tag == "BuletOne")
        {
            Bull();
            
        }

    }

    public void Bull()
    {
        if (slotOne.activeSelf)
        {
            slotOne.SetActive(false);
        }

        else if (slotTwo.activeSelf)
        {
            slotTwo.SetActive(false);
        }

        else if (slotThree.activeSelf)
        {
            slotThree.SetActive(false);
        }

        else if (slotFour.activeSelf)
        {
            slotFour.SetActive(false);
        }

        else if (slotFive.activeSelf)
        {
            slotFive.SetActive(false);

        }

        else Cost();
    }

    public void Cost()
    {
        gameOver.SetActive(true);
        player.SetActive(false);
        Invoke("Invok", 0.5f);

        HightScore.HightCoin();
        HightScore.HightScoreCounter();
    }

    public void Invok()
    {
        slotGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    
}
