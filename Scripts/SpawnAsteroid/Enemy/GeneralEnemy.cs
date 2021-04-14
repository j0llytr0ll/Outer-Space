using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour
{
    public GameObject[] enemy;

    public void Enemy()
    {
        for (int i = 0; i < enemy.Length; i++)
        {           
            if (enemy[i].activeSelf)
            {
                enemy[i].GetComponent<CoinRotation>().StartMagnet();
               
                
            }
        }
    }

    public void CoinDisable()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].activeSelf)
            {
                enemy[i].GetComponent<CoinRotation>().ResetEnemy();
            }
        }
    }
}
