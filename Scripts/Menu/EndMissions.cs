using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMissions : MonoBehaviour
{
    public GameObject[] panels;
    public Transform[] positions;

    private int intPos;

    private void OnEnable()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i].activeSelf)
            {
                intPos++;
            }
        }
        gameObject.transform.position = positions[intPos].position;
    }



    private void OnDisable()
    {
        intPos = 0;
        gameObject.transform.position = positions[0].position;
    }
}
