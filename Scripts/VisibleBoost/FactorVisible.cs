using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FactorVisible : MonoBehaviour
{
    public Text secText;
    public GameObject onePos;
    private void OnEnable()
    {
        VisibleBoost.positionVis = 3;
        transform.parent.gameObject.GetComponent<VisibleBoost>().Position();
        StartCoroutine(Sec());
    }

    IEnumerator Sec()
    {
        yield return new WaitForSeconds(0);
        for (int i = ShoBoost.staticValueFactor; i > 0; i--)
        {
            secText.text = "" + i;
            yield return new WaitForSeconds(1);
        }
        HudScr.factor = 1;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().FactorStart();   
        VisibleBoost.nullPositionVis = 3;
        transform.parent.gameObject.GetComponent<VisibleBoost>().NullPosition();
    }

    private void OnDisable()
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
