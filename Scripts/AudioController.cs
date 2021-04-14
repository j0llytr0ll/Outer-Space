using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject menu;
    string musicStats;
    public void Awake()
    {
        Invoke("AwakeMusic", 0.000000001f);       
    }

    void AwakeMusic()
    {
        if (Options.musicStats == "true")
            gameObject.GetComponent<AudioSource>().Play();
    }
    public void StartGame()
    {
        if (Options.musicStats == "true")
            StartCoroutine(StartGameCor());


    }
    IEnumerator StartGameCor()
    {        
        musicStats = "startGame";
        GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().Play();
        while (GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume != 0.45f && musicStats == "startGame")
        {
            gameObject.GetComponent<AudioSource>().volume = Mathf.MoveTowards(gameObject.GetComponent<AudioSource>().volume, 0, Time.deltaTime * 1);
            GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume = Mathf.MoveTowards(GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume, 0.45f, Time.deltaTime * 0.05f);
            yield return new WaitForSeconds(0);
        }
        gameObject.GetComponent<AudioSource>().Stop();
    }

    public void OverGame()
    {
        if (Options.musicStats == "true")
            StartCoroutine(OverGameCor());
    }
    IEnumerator OverGameCor()
    {
        musicStats = "overGame";
        while (GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume != 0.05f && musicStats == "overGame")
        {
            GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume = Mathf.MoveTowards(GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume, 0.05f, Time.deltaTime * 0.5f);
            yield return new WaitForSeconds(0);
        }
    }

    public void RestartGame()
    {
        if (Options.musicStats == "true")
            StartCoroutine(RestartGameCor());
    }
    IEnumerator RestartGameCor()
    {
        musicStats = "restartGame";
        while (GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume != 0.45f && musicStats == "restartGame")
        {
            GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume = Mathf.MoveTowards(GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume, 0.45f, Time.deltaTime * 1f);
            yield return new WaitForSeconds(0);
        }
    }

    public void StartCost()
    {
        if (Options.musicStats == "true")
            StartCoroutine(StartCostCor());
    }
    IEnumerator StartCostCor()
    {
        musicStats = "startCost";
        GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume = 0;
        GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().Play();
        while (gameObject.GetComponent<AudioSource>().volume != 0.1f && musicStats == "startCost")
        {
            gameObject.GetComponent<AudioSource>().volume = Mathf.MoveTowards(gameObject.GetComponent<AudioSource>().volume, 0.1f, Time.deltaTime * 0.5f);
            yield return new WaitForSeconds(0);
        }
    }

    public void StartMenu()
    {
        if (Options.musicStats == "true")
            StartCoroutine(StartMenuCor());
    }
    IEnumerator StartMenuCor()
    {
        musicStats = "startMenu";
        while (gameObject.GetComponent<AudioSource>().volume != 0.6f && musicStats == "startMenu")
        {
            gameObject.GetComponent<AudioSource>().volume = Mathf.MoveTowards(gameObject.GetComponent<AudioSource>().volume, 0.6f, Time.deltaTime * 0.5f);
            yield return new WaitForSeconds(0);
        }
    }

    public void ExitGame()
    {
        musicStats = "exitGame";
        StopAllCoroutines();      
        GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume = 0f;
        GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().volume = 0.6f;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void OnOption()
    {
        musicStats = "onOption";
        if (menu.activeSelf)
        {
            gameObject.GetComponent<AudioSource>().volume = 0.6f;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume = 0.45f;
            GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().Play();
        }
    }

    public void OffOption()
    {
        musicStats = "offOption";
        gameObject.GetComponent<AudioSource>().volume = 0;
        GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().volume = 0;
        gameObject.GetComponent<AudioSource>().Play();
        GameObject.FindGameObjectWithTag("AudioController_Game").GetComponent<AudioSource>().Play();
    }
}
