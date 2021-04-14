using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAst : MonoBehaviour
{
    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.constraints = RigidbodyConstraints.FreezePosition;
    }

    public void NullRotate()
    {
        gameObject.transform.rotation = Quaternion.identity;
        
    }

    public void Explosion()
    {
        gameObject.transform.parent = null;
        rig.constraints = RigidbodyConstraints.None;
        rig.isKinematic = true;
        rig.AddForce(transform.forward * HudScr.speedBrick);
    }

   
}
