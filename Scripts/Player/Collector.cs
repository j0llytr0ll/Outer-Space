using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject referenceBoostSpawn;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Sphere" || collision.transform.tag == "RocketTest" || collision.transform.tag == "Magnet")
        {
            referenceBoostSpawn.GetComponent<BoostSpawn>().MethodToCall();

        }

        if (collision.transform.tag == "Factor" || collision.transform.tag == "Heart" || collision.transform.tag == "Key")
        {
            referenceBoostSpawn.GetComponent<BoostSpawn>().MethodFactor();
        }
        
    }
}
