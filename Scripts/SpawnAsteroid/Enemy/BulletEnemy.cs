using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody rig;
    public GameObject nullObj;

    void OnEnable()
    {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * (HudScr.speedBrick + 700));
        gameObject.transform.parent = null;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Plane"
            || collision.transform.tag == "Player"
            || collision.transform.tag == "Asteroid"
            || collision.transform.tag == "Enemy"
            || collision.transform.tag == "Comet"
            || collision.transform.tag == "Right" 
            || collision.transform.tag == "Left" 
            || collision.transform.tag == "Up" 
            || collision.transform.tag == "Down")
        {
            gameObject.transform.parent = nullObj.transform;
            gameObject.SetActive(false);
        }


    }

    public void OnDisable()
    {
        gameObject.transform.rotation = nullObj.transform.rotation;
        gameObject.transform.position = nullObj.transform.position;
        rig.angularVelocity = Vector3.zero;
        rig.velocity = Vector3.zero;
        rig.isKinematic = true;
        rig.isKinematic = false;
    }
    
    
}
