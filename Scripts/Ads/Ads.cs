using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
#if UNITY_IOS
    private readonly string advertID = "3999518";
#elif UNITY_ANDROID
    private readonly string advertID = "3999519";
#endif

    private void Awake()
    {
        Advertisement.Initialize(advertID, true);
    }
}
