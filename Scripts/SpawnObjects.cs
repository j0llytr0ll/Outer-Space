using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    public GameObject controller;
    public float distance;

    public GameObject[] bricks;
    int brickSelector;
    int [] x = new int[] {4, 0, -4 };
    int xSelector;
    int[] y = new int[] { 3, 0, -3 };
    int ySelector;
   

    private void Start()
    {
        StartCoroutine(SpawnWaves());
        
    }
    


    IEnumerator SpawnWaves()

    {
        yield return new WaitForSeconds(0);
        while (true)
        {
            xSelector = Random.Range(0, x.Length);
            ySelector = Random.Range(0, y.Length);
            Vector3 spawnPosition = new Vector3(x[xSelector], y[ySelector], distance);
            Quaternion spawnRotation = Quaternion.identity;

            brickSelector = Random.Range(0, bricks.Length);

            Instantiate(bricks[brickSelector], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(HudScr.spawnWaitL, HudScr.spawnWaitR));

        }

    }

   


}
