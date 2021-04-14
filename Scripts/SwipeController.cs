using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class SwipeController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform empty;
    public Transform cameraMov;
    public Transform emptyCameraMov;
    public Transform player;
    public float speed;
    public GameObject right;
    public GameObject left;
    public GameObject down;
    public GameObject up;
    private bool startLerpStatus;
    void OnEnable()
    {
        startLerpStatus = false;               
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            SoundManeuverShip();
            if ((eventData.delta.x > 0) && empty.position.x > -4)
            {
                empty.position += new Vector3(-4f, 0, 0);
                emptyCameraMov.position += new Vector3(-2f, 0, 0);
                left.SetActive(false);
                Invoke("Left", 0.2f);
                
            }
            if ((eventData.delta.x < 0) && empty.position.x < 4)
            {
                empty.position += new Vector3(4f, 0, 0);
                emptyCameraMov.position += new Vector3(2f, 0, 0);
                right.SetActive(false);
                Invoke("Right", 0.2f);
            }
            
            
        }
        else
        {
            SoundManeuverShip();
            if ((eventData.delta.y < 0) && empty.position.y > -3)
            {
                empty.position += new Vector3(0, -3f, 0);
                emptyCameraMov.position += new Vector3(0, -2f, 0);
                up.SetActive(false);
                Invoke("Up", 0.2f);
            }
            if ((eventData.delta.y > 0) && empty.position.y < 3)
            {
                empty.position += new Vector3(0, 3f, 0);
                emptyCameraMov.position += new Vector3(0, 2f, 0);
                down.SetActive(false);
                Invoke("Down", 0.2f);
            }
            
        }
        
        if (startLerpStatus == false)
        {
            StartCoroutine(StartLerp());
        }
    }

    IEnumerator StartLerp()
    {
        startLerpStatus = true;
        while (player.position != empty.position)
        {
            player.position = Vector3.Lerp(player.position, empty.position, Time.deltaTime * speed);
            cameraMov.position = Vector3.Lerp(cameraMov.position, emptyCameraMov.position, Time.deltaTime * speed);
            yield return new WaitForSeconds(0);
        }
        startLerpStatus = false;
    }

    private void Left()
    {
        left.SetActive(true);
    }

    private void Right()
    {
        right.SetActive(true);
    }

    private void Up()
    {
        up.SetActive(true);
    }

    private void Down()
    {
        down.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void ResetPosition()
    {
        emptyCameraMov.position = new Vector3(0, 4.5f, 12.5f);
        cameraMov.position = new Vector3(0, 4.5f, 12.5f);
        empty.position = new Vector3(0, 0, 0);
        player.position = new Vector3(0, 0, 0);
    }

    private void SoundManeuverShip()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_ManeuverShip").GetComponent<AudioSource>().Play();
        }
    }



}
