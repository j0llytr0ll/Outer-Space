using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAQCometMovment : MonoBehaviour
{
    private Rigidbody rig;
    public GameObject nullPos;
    public GameObject player;
    public GameObject coin;
    public GameObject chilld;
    public GameObject particle;
    float tumbl = 150;



    public void MovmentEnemy()
    {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * HudScr.speedBrick);
        rig.angularVelocity = new Vector3(1, 1, 1) * tumbl;
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
        chilld.GetComponent<FAQComet>().StopParticle();

    }

    void AsteroidPosition()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
    }
}
