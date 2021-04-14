using System.Collections;
using UnityEngine;

public class CometMovment : MonoBehaviour
{
    private Rigidbody rig;
    public GameObject nullPos;
    public GameObject player;
    public GameObject coin;
    public GameObject chilld;
    public GameObject particle;
    float tumbl = 150;

    int[] x = new int[] { 4, 0, -4 };
    int xSelector;
    int[] y = new int[] { 3, 0, -3 };
    int ySelector;


    public void MovmentEnemy()
    {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * HudScr.speedBrick);
        rig.angularVelocity = new Vector3(1,1,1) * tumbl;
        rig.angularVelocity = Random.insideUnitSphere * tumbl;
        AsteroidPosition();
    }

    public void RotateEnemy()
    {

        gameObject.transform.rotation = nullPos.transform.rotation;
        rig.angularVelocity = new Vector3(0, 1, 0) * tumbl;
        
    }

    public void ResetEnemy()
    {
        gameObject.transform.position = nullPos.transform.position;
        gameObject.transform.rotation = nullPos.transform.rotation;
        rig.angularVelocity = Vector3.zero;
        rig.velocity = Vector3.zero;
        rig.isKinematic = true;
        rig.isKinematic = false;
        particle.GetComponent<ParticleAst>().NullRotate();
        chilld.GetComponent<CometSpawner>().StopParticle();

    }
    
    void AsteroidPosition()
    {
        xSelector = Random.Range(0, x.Length);
        ySelector = Random.Range(0, y.Length);

        gameObject.transform.position = new Vector3(x[xSelector], y[ySelector], gameObject.transform.position.z);
    }
}
