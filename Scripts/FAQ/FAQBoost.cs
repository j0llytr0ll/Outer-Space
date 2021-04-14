using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FAQBoost : MonoBehaviour, IPointerDownHandler
{
    public GameObject boostSlot;
    public void OnPointerDown(PointerEventData eventData)
    {
        boostSlot.GetComponent<HierarchyBoost>().ButtonClick();
        gameObject.SetActive(false);
    }
}
