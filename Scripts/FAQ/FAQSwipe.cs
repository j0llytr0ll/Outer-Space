using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FAQSwipe : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform player;
    public Transform empty;
    public GameObject horizontalController;
    public GameObject verticalController;
    private bool startLerpStatus;
    public Transform cameraMov;
    public Transform emptyCameraMov;
    public bool verticalSwipe = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if ((eventData.delta.x > 0) && empty.position.x > -4)
            {
                empty.position += new Vector3(-4f, 0, 0);
                emptyCameraMov.position += new Vector3(-2f, 0, 0);

            }
            if ((eventData.delta.x < 0) && empty.position.x < 4)
            {
                empty.position += new Vector3(4f, 0, 0);
                emptyCameraMov.position += new Vector3(2f, 0, 0);
            }
        }
        else if (verticalController.activeSelf)
        {
            verticalSwipe = true;
            if ((eventData.delta.y < 0) && empty.position.y > -3)
            {
                empty.position += new Vector3(0, -3f, 0);
                emptyCameraMov.position += new Vector3(0, -2f, 0);
            }
            if ((eventData.delta.y > 0) && empty.position.y < 3)
            {
                empty.position += new Vector3(0, 3f, 0);
                emptyCameraMov.position += new Vector3(0, 2f, 0);
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
            player.position = Vector3.Lerp(player.position, empty.position, Time.deltaTime * 15);
            cameraMov.position = Vector3.Lerp(cameraMov.position, emptyCameraMov.position, Time.deltaTime * 15);
            yield return new WaitForSeconds(0);
        }
        startLerpStatus = false;
        if (horizontalController.activeSelf)
        {
            horizontalController.SetActive(false);
            verticalController.SetActive(true);
        }
        else if (verticalSwipe == true)
        {
            horizontalController.SetActive(true);
            verticalController.SetActive(false);
            GameObject.FindGameObjectWithTag("FAQ").GetComponent<FAQ>().ClickDisable();
        }

    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
