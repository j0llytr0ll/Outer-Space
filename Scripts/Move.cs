using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 dir;
    private Rigidbody rig;
    public Transform objs;
    public GameObject coin;
    public GameObject boostDrop;
    void Start()
    {
        dir = new Vector3(0, 0, 1);
        rig = GetComponent<Rigidbody>();
        rig.AddForce(dir * HudScr.speedBrick);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Plane")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "player")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Trig")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Saved")
        {
            Destroy(gameObject);
            
        }

        if (collision.transform.tag == "Bullet" || collision.transform.tag == "Rocket")
        {
            Destroy(gameObject);
            if (BoostSpawn.boost == 0)
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
                Instantiate(coin, objs.transform.position, spawnRotation);
            }
            else
            
            Instantiate(boostDrop, objs.transform.position, objs.transform.rotation);
            BoostSpawn.boost = 0;

        }


    }

    
}
