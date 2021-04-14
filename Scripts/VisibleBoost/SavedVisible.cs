using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SavedVisible : MonoBehaviour
{
    public Text savedText;
    public static int secs;
    public GameObject saved;
    public GameObject onePos;

    void OnEnable()
    {
        SavedTest();
        VisibleBoost.positionVis = 0;
        transform.parent.gameObject.GetComponent<VisibleBoost>().Position();
    }
    public void SavedTest()
    {
        StartCoroutine(SavedSec());

        secs = ShoBoost.staticValueSaved;
    }

    IEnumerator SavedSec()
    {
        yield return new WaitForSeconds(0);
        while (true)
        {
            for (int i = 0; i < secs; i += 0)
            {
                savedText.text = "" + secs;
                secs--;

                yield return new WaitForSeconds(1);
            }

            GameObject.FindGameObjectWithTag("Saved").GetComponent<Sphere>().DestroySphere();
            yield return new WaitForSeconds(0);

        }


    }
    private void OnDisable()
    {
        SoundBonusOff();
        gameObject.transform.position = onePos.transform.position;
        StopCoroutine(SavedSec());
        VisibleBoost.testVisTest = 0;
    }

    private void SoundBonusOff()
    {
        if (Options.soundStats == "true")
        {
            GameObject.FindGameObjectWithTag("AudioController_BonusOff").GetComponent<AudioSource>().Play();
        }
    }
}
