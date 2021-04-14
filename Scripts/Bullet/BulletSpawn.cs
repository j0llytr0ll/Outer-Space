using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawn;
    public float spawnWait;
    public static float bulletPoint;
    public float bulletSpeed;

    void Start()
    {
       
        bulletPoint = bulletSpeed;
        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(0);
        while (true)
        {
            Quaternion spawnRotation = Quaternion.identity;
            Vector3 spawnPosition = spawn.transform.position;
            Instantiate(bullet, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);

        }
    }
    

}
