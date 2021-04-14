using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class Menu : MonoBehaviour, IPointerDownHandler
{
    public Animator cameraMove;
    public GameObject cameraStart;
    public GameObject game;
    public GameObject menu;
    public GameObject refPlayer;
    public GameObject earth;
    public GameObject flame;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().StartGame();
        //GameObject.FindGameObjectWithTag("Reference").SetActive(false);
        //SceneManager.LoadScene(1); 
        menu.SetActive(false);
        flame.SetActive(true);
        SoundStartShip();
        cameraMove.SetBool("Start", true);       
        Invoke("StartScene", 1);
    }

    private void StartScene()
    {
        game.SetActive(true);
        refPlayer.SetActive(false);
        flame.SetActive(false);
        cameraMove.gameObject.SetActive(false);
        cameraStart.SetActive(true);
        earth.SetActive(false);
        SoundEngineShip();
        
    }

    private void SoundStartShip()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_StartShip").GetComponent<AudioSource>().Play();
        }
    }

    private void SoundEngineShip()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_EngineShip").GetComponent<AudioSource>().Play();
        }
    }

    

}
