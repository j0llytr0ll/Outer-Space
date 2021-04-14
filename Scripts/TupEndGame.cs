using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TupEndGame : MonoBehaviour, IPointerDownHandler
{
    public GameObject overMenu;
    public void OnPointerDown(PointerEventData eventData)
    {
        overMenu.GetComponent<OverMenu>().BackMenu();
    }
}
