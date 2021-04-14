using UnityEngine;

public class MoveGun : MonoBehaviour
{
    private Vector3 dir;
    private Rigidbody rig;

    void Start()
    {
        dir = new Vector3(0, 0, 1);
        rig = GetComponent<Rigidbody>();
        rig.AddForce(dir * (HudScr.speedBrick + 1000));
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Plane")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Object")
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "KillObj")
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

    }


}
