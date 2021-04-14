using UnityEngine;

public class GeneralAsteroid : MonoBehaviour
{
    public GameObject[] asteroid;

    public void Asteroid()
    {
        for (int i = 0; i < asteroid.Length; i++)
        {
            if (asteroid[i].activeSelf)
            {
                asteroid[i].GetComponent<CoinAsteroid>().StartMagnet();
            }
        }
    }

    public void CoinDisable()
    {
        for (int i = 0; i < asteroid.Length; i++)
        {
            if (asteroid[i].activeSelf)
            {
                asteroid[i].GetComponent<CoinAsteroid>().ResetEnemy();
            }
        }
    }
}
