using UnityEngine;

public class GeneralComet : MonoBehaviour
{
    public GameObject[] comet;

    public void Comet()
    {
        for (int i = 0; i < comet.Length; i++)
        {
            if (comet[i].activeSelf)
            {
                comet[i].GetComponent<CoinComet>().StartMagnet();
            }
        }
    }

    public void CoinDisable()
    {
        for (int i = 0; i < comet.Length; i++)
        {
            if (comet[i].activeSelf)
            {
                comet[i].GetComponent<CoinComet>().ResetEnemy();
            }
        }
    }

}
