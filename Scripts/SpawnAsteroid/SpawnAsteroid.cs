using System.Collections;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public GameObject[] asteroid;
    int asteroidSelector = 0;

    public GameObject[] comet;
    int cometSelector = 0;

    public GameObject[] enemy;
    int enemySelector = 0;

    bool corou;

    int select;

    public void StartLevel()
    {
        corou = true;
        StartCoroutine(SpawnWaves());       
    }
    public void ResetLevel()
    {
        corou = false;
        StopCoroutine(SpawnWaves());
        for(int i = 0; i < asteroid.Length; i++)
        {
            if (asteroid[i].activeSelf)
            {
                asteroid[i].GetComponent<AsteroidSpawner>().RestartScen();
            }
        }

        for (int i = 0; i < comet.Length; i++)
        {
            if (comet[i].activeSelf)
            {
                comet[i].GetComponent<CometSpawner>().RestartScen();
            }
        }

        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].activeSelf)
            {
                enemy[i].GetComponent<EnemSpawner>().RestartScen();
            }
        }
    }
    IEnumerator SpawnWaves()

    {
        yield return new WaitForSeconds(0);
        while (corou == true) 
        {           
            select = Random.Range(0, 3);
            if (select == 0)
            {
                Asteroid();
                
            }
            else if (select == 1)
            {
                Comet();
                
            }
            else if (select == 2)
            {
                Enemy();
                
            }
            
            yield return new WaitForSeconds(Random.Range(HudScr.spawnWaitL, HudScr.spawnWaitR));
        }
        yield break;
        


    }

    public void Asteroid()
    {        
        if (asteroidSelector < asteroid.Length - 1)
        {
            asteroid[asteroidSelector].SetActive(true);
            asteroidSelector++;
        }
        else
        {
            asteroid[asteroidSelector].SetActive(true);
            asteroidSelector = 0;
        }
                    
    }

    public void Comet()
    {
        if (cometSelector < comet.Length - 1)
        {
            comet[cometSelector].SetActive(true);
            cometSelector++;
        }
        else
        {
            comet[cometSelector].SetActive(true);
            cometSelector = 0;
        }
    }

    public void Enemy()
    {
        if (enemySelector < enemy.Length - 1)
        {
            enemy[enemySelector].SetActive(true);
            enemySelector++;
        }
        else
        {
            enemy[enemySelector].SetActive(true);
            enemySelector = 0;
        }
    }

    public void OnDisable()
    {
        for (int i = 0; i < asteroid.Length; i++)
        {
            asteroid[i].GetComponent<AsteroidSpawner>().StopParticle();
        }

        for (int i = 0; i < comet.Length; i++)
        {
            comet[i].GetComponent<CometSpawner>().StopParticle();
        }

        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<EnemSpawner>().StopParticle();
        }
    }
}
