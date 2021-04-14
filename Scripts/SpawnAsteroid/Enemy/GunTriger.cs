using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTriger : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            enemy.GetComponent<EnemSpawner>().BulletSpawn();
        }
    }
}
