using UnityEngine;

public class BoostSpawn : MonoBehaviour
{
    public static int boost;
    public static int startFactor;

    public void Enable()
    {
        MethodToCall();
        MethodFactor();
        startFactor = 0;
    }

    public void MethodStarter()
    {
        MethodToCall();
        MethodFactor();
        startFactor = 0;
    }
    public void ResetLevel()
    {
        CancelInvoke();
        boost = 0;
        startFactor = 0;
    }

    public void MethodToCall()
    {        
        Invoke("StartBoost", Random.Range(15, 20));
        boost = 0;
    }

    public void MethodFactor()
    {
        Invoke("StartFactor", Random.Range(60, 65));
        startFactor = 0;
    }

    public void StartFactor()
    {
        startFactor = 1;
    }   

    public void StartBoost()
    {      
        boost = 1;
    }
}
