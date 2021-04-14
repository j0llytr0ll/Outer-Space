using UnityEngine;

public class HightCoinRotation : MonoBehaviour
{
    public float speed;
    private Vector3 dirs;
    private Rigidbody rigs;
    private GameObject play;
    private bool magnetTs;
    void Start()
    {
        dirs = new Vector3(0, 0, 1);
        rigs = GetComponent<Rigidbody>();
        rigs.AddForce(dirs * HudScr.speedBrick);
        magnetTs = MagnetVisible.magnetTest;
        play = GameObject.FindGameObjectWithTag("player");
        
    }


    public void FixedUpdate()
    {
        Quaternion rotation = Quaternion.AngleAxis(speed * 0.02f, Vector3.right);
        transform.rotation *= rotation;
        if (magnetTs == true || MagnetVisible.magnetTest)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, play.transform.position, Time.deltaTime * 4);
        }
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
            HudScr.coinCounter += 5;

        }

        if (collision.transform.tag == "Trig")
        {
            Destroy(gameObject);
            HudScr.coinCounter += 5;

        }

        if (collision.transform.tag == "Saved")
        {
            Destroy(gameObject);
            HudScr.coinCounter += 5;

        }
    }
}
