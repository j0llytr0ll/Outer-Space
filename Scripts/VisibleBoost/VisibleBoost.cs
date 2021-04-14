using UnityEngine;


public class VisibleBoost : MonoBehaviour
{
    public GameObject[] boost;
    public GameObject[] positionAll;
    public GameObject[] visBoostPos;
    public int visPos;
    public static int testVisTest;
    public static int positionVis;
    public static int nullPositionVis;


    private void OnDisable()
    {
        for (int i = 0; i < boost.Length; i++)
        {
            boost[i].SetActive(false);
        }
        gameObject.transform.position = visBoostPos[0].transform.position;
    }

    private void OnEnable()
    {
        visPos = 0;
        positionVis = 0;
        nullPositionVis = 0;
    }

    private void Start()
    {
        testVisTest = 0;
        visPos = 0;
        positionVis = 0;
        nullPositionVis = 0;
    }
    public void VisibleTest()
    {
        if (testVisTest == 1 && !boost[0].activeSelf)
        {
            boost[0].SetActive(true);
            positionVis = 0;


        }
        else if (testVisTest == 1 && boost[0].activeSelf)
        {
            SavedVisible.secs = ShoBoost.staticValueSaved;
        }

        else if (testVisTest == 2 && !boost[1].activeSelf)
        {
            boost[1].SetActive(true);
            positionVis = 1;


        }
        else if (testVisTest == 2 && boost[1].activeSelf)
        {
            RocketVisible.seconds = ShoBoost.staticValueRocket;
            //boost[1].GetComponent<RocketVisible>().VisibleRocket();
        }

        else if (testVisTest == 3 && !boost[2].activeSelf)
        {
            boost[2].SetActive(true);
            positionVis = 2;

        }
        else if (testVisTest == 3 && boost[2].activeSelf)
        {
            MagnetVisible.seconds = ShoBoost.staticValueMagnet;
        }
    }

    public void Position()
    {
        for (int i = 0; i < boost.Length; i++)
        {
            if (boost[i].activeSelf && i != positionVis)
            {
                for (int p = 0; p < positionAll.Length; p++)
                {
                    if (boost[i].transform.position.x == positionAll[p].transform.position.x)
                    {
                        boost[i].transform.position = positionAll[p + 1].transform.position;
                        p = positionAll.Length;

                    }
                }
            }
        }
        visPos++;
        gameObject.transform.position = visBoostPos[visPos - 1].transform.position;
    }

    

    public void NullPosition()
    {        
        for (int i = 0; i < positionAll.Length; i++)
        {
            if (boost[nullPositionVis].transform.position.x == positionAll[i].transform.position.x)
            {
                for (int p = i + 1; p < positionAll.Length; p++)
                {

                    for (int b = 0; b < boost.Length; b++)
                    {
                        if (boost[b].transform.position.x == positionAll[p].transform.position.x)
                        {
                            boost[b].transform.position = positionAll[p - 1].transform.position;
                        }
                    }
                }
            }
        }
        visPos--;
        if (visPos > 0)
        {
            gameObject.transform.position = visBoostPos[visPos - 1].transform.position;
        }
        boost[nullPositionVis].SetActive(false);
    }

    




}
