using UnityEngine;
using UnityEngine.UI;

public class FactorMassive : MonoBehaviour
{
    public GameObject[] factor;
    public GameObject factorVis;
    public static int factorSelect;

    public void OnEnable()
    {
        factorSelect = Random.Range(0, factor.Length);
        factor[factorSelect].SetActive(true);
    }

    public void ActiveFactor()
    {
        int f = factorSelect + 2;
        HudScr.factor = f;
        factorVis.SetActive(true);
        factorVis.transform.GetChild(0).GetComponent<Text>().text ="" + f;
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().coinfactor.text = "x" + (HudScr.coinObj * HudScr.factor);
        GameObject.FindGameObjectWithTag("Hud").GetComponent<HudScr>().scorefactor.text = "x" + (HudScr.coinObj * HudScr.factor);
    }
}
