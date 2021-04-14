using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class ShopKey : MonoBehaviour
{
    public GameObject[] coinPanels;
    public GameObject[] keyPanels;
    public Text textPanel;


    public void OnPurchasingComplete(Product product)
    {
        if (product.definition.id == "coins_10000")
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + 10000;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < coinPanels.Length; i++)
            {
                coinPanels[i].SetActive(true);
            }
            textPanel.text = "" + 10000;
        }
        if (product.definition.id == "coins_200000")
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + 200000;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < coinPanels.Length; i++)
            {
                coinPanels[i].SetActive(true);
            }
            textPanel.text = "" + 200000;
        }
        if (product.definition.id == "coins_500000")
        {
            HightScore.coinHightCounter = HightScore.coinHightCounter + 500000;
            PlayerPrefs.SetInt("SaveCoin", HightScore.coinHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < coinPanels.Length; i++)
            {
                coinPanels[i].SetActive(true);
            }
            textPanel.text = "" + 500000;
        }
        if (product.definition.id == "key_40")
        {
            HightScore.keyHightCounter = HightScore.keyHightCounter + 40;
            PlayerPrefs.SetInt("SaveKey", HightScore.keyHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < keyPanels.Length; i++)
            {
                keyPanels[i].SetActive(true);
            }
            textPanel.text = "" + 40;
        }
        if (product.definition.id == "key_200")
        {
            HightScore.keyHightCounter = HightScore.keyHightCounter + 200;
            PlayerPrefs.SetInt("SaveKey", HightScore.keyHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < keyPanels.Length; i++)
            {
                keyPanels[i].SetActive(true);
            }
            textPanel.text = "" + 200;
        }
        if (product.definition.id == "key_500")
        {
            HightScore.keyHightCounter = HightScore.keyHightCounter + 500;
            PlayerPrefs.SetInt("SaveKey", HightScore.keyHightCounter);
            GameObject.FindGameObjectWithTag("Ads").GetComponent<HightScore>().Counter();
            for (int i = 0; i < keyPanels.Length; i++)
            {
                keyPanels[i].SetActive(true);
            }
            textPanel.text = "" + 500;
        }
    }

    public void OnPurchasingFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of product " + product.definition.id + " failed because " + reason);
    }
}
