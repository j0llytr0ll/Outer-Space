using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndGame : MonoBehaviour, IPointerDownHandler
{
    public GameObject scorePanel;
    public GameObject coinPanel;
    float one;
    public GameObject newRecordsText;
    public Animation newRecords;
    public static float two;
    public static float three;
    public static int coin;
    public Text score;
    public Text coinText;
    public GameObject buttonCoin;
    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().StartCost();
        StartCoroutine(Score());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!coinPanel.activeSelf)
        {
            one = two;
            score.text = "" + Math.Truncate(one);
            SoundScoreOff();
        }
        
    }

    IEnumerator Score()
    {
        yield return new WaitForSeconds(0);
        SoundScoreOn();
        one = 0;
        float speed = two / 3;
        while (one != two)
        {
            one = Mathf.MoveTowards(one, two, Time.deltaTime * speed);
            score.text = "" + Math.Truncate(one);
            yield return new WaitForSeconds(0);
        }
        SoundScoreOff();
        if (two > three)
        {
            newRecordsText.SetActive(true);
            newRecords.Play();
            SoundVictory();
        }
        
        yield return new WaitForSeconds(0.3f);
        scorePanel.SetActive(false);
        coinPanel.SetActive(true);
        coinText.text = "" + coin;
        if (coin != 0)
        {
            buttonCoin.SetActive(true);
            SoundCoinEndGame();
        }
    }

    public void ClosePanel()
    {
        GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().StartMenu();
        one = 0;
        two = 0;
        coin = 0;
        newRecordsText.SetActive(false);
        score.color = new Color(1, 1, 1, 1);
        coinPanel.SetActive(false);
        scorePanel.SetActive(true);
        buttonCoin.SetActive(false);
        gameObject.SetActive(false);
    }

    private void SoundScoreOn()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Score").GetComponent<AudioSource>().Play();
        }
    }
    private void SoundScoreOff()
    {
        GameObject.FindGameObjectWithTag("AudioController_Score").GetComponent<AudioSource>().Stop();
    }

    private void SoundCoinEndGame()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_CoinEndGame").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundVictory()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_Victory").GetComponent<AudioSource>().Play();
        }
    }
}
