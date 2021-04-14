using UnityEngine;


public class MoveBoost : MonoBehaviour
{
    private Vector3 dirs;
    private Rigidbody rigs;
    public GameObject[] boost;
    private int numberBoost;
    
    
    
    
    void Start()
    {
        numberBoost = Random.Range(0, boost.Length);
        boost[numberBoost].SetActive(true);
        dirs = new Vector3(0, 0, 1);
        rigs = GetComponent<Rigidbody>();
        rigs.AddForce(dirs * HudScr.speedBrick);
    }

    

    

    
}
