using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RocketVisible : MonoBehaviour
{
    public Text rocketText;
    public GameObject onePos;
    public static int seconds;
    public void OnEnable()
    {
        //SpawnGun.bulletTest = ShoBoost.staticValueRocket;
        
        VisibleBoost.positionVis = 1;
        transform.parent.gameObject.GetComponent<VisibleBoost>().Position();
        //VisibleRocket();

        GameObject.FindGameObjectWithTag("Empty").GetComponent<Gun>().OnRocket();
        seconds = ShoBoost.staticValueRocket;
        rocketText.text = "" + ShoBoost.staticValueRocket;
        StartCoroutine(RocketSec());

    }
    /*public void VisibleRocket()
    {
        if (SpawnGun.bulletTest > 0)
        {
            rocketText.text = "" + SpawnGun.bulletTest;
        }
        else
        {
            VisibleBoost.nullPositionVis = 1;
            transform.parent.gameObject.GetComponent<VisibleBoost>().NullPosition();
            VisibleBoost.testVisTest = 0;
        }
    }*/

    IEnumerator RocketSec()
    {
        yield return new WaitForSeconds(0);
        while (true)
        {
            for (int i = 0; i < seconds; i += 0)
            {
                rocketText.text = "" + seconds;
                seconds--;

                yield return new WaitForSeconds(1);
            }
            VisibleBoost.nullPositionVis = 1;
            transform.parent.gameObject.GetComponent<VisibleBoost>().NullPosition();
            VisibleBoost.testVisTest = 0;
            GameObject.FindGameObjectWithTag("Empty").GetComponent<Gun>().DisbleRocket();
            yield return new WaitForSeconds(0);


        }

    }

        public void OnDisable()
    {
        SoundBonusOff();
        gameObject.transform.position = onePos.transform.position;
    }

    private void SoundBonusOff()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_BonusOff").GetComponent<AudioSource>().Play();
        }
    }
}
