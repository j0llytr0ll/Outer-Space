using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsPanelPosition : MonoBehaviour
{
    public GameObject[] panels;

    private void OnEnable()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i].activeSelf)
            {
                panels[i].SetActive(false);
            }
        }

    } 
}
