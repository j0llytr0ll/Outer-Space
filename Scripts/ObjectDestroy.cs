using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    private Vector3 dir;
    private Rigidbody rig;
    public GameObject coin;
    public GameObject objs;
    public float tumbl;

    void Start()
    {
        dir = new Vector3(0, 0, 1);
        rig = GetComponent<Rigidbody>();
        rig.AddForce(dir * HudScr.speedBrick);

        rig.angularVelocity = new Vector3(1, 1, 1) * tumbl;

        rig.angularVelocity = Random.insideUnitSphere * tumbl;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Plane")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Rocket")
        {
            Destroy(gameObject);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
            Instantiate(coin, objs.transform.position, spawnRotation);
        }

        if (collision.transform.tag == "Saved")
        {
            Destroy(gameObject);
            
        }
    }
}
