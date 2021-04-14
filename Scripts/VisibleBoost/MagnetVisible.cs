using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MagnetVisible : MonoBehaviour
{
    public static bool magnetTest;
    public static int seconds;
    public Text magnetText;
    public GameObject onePos;
    public void OnEnable()
    {
        VisibleBoost.positionVis = 2;
        transform.parent.gameObject.GetComponent<VisibleBoost>().Position();
        magnetTest = true;

        GameObject.FindGameObjectWithTag("GeneralEnemy").GetComponent<GeneralEnemy>().Enemy();
        GameObject.FindGameObjectWithTag("GeneralComet").GetComponent<GeneralComet>().Comet();
        GameObject.FindGameObjectWithTag("GeneralAsteroid").GetComponent<GeneralAsteroid>().Asteroid();

        seconds = ShoBoost.staticValueMagnet;
        StartCoroutine(SavedSec());
    }
    public void OnDisable()
    {
        //SoundBonusOff();
        gameObject.transform.position = onePos.transform.position;

        magnetTest = false;       
    }
      
    IEnumerator SavedSec()
    {
        yield return new WaitForSeconds(0);
        while (true)
        {
            for (int i = 0; i < seconds; i += 0)
            {
                magnetText.text = "" + seconds;
                seconds--;

                yield return new WaitForSeconds(1);
            }
            VisibleBoost.nullPositionVis = 2;
            transform.parent.gameObject.GetComponent<VisibleBoost>().NullPosition();
            StopMagn();
            yield return new WaitForSeconds(0);


        }


    }

    public void StopMagn()
    {
        gameObject.SetActive(false);
        magnetTest = false;
        VisibleBoost.testVisTest = 0;
        StopCoroutine(SavedSec());
    }

    private void SoundBonusOff()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_BonusOff").GetComponent<AudioSource>().Play();
        }
    }
}
