using UnityEngine;

public class RocketMove : MonoBehaviour
{
    private Rigidbody rig;
    public GameObject nullPos;

    void OnEnable()
    {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(-transform.forward * 1500);
        gameObject.transform.parent = null;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "PlaneEnd")
        {
            gameObject.transform.parent = nullPos.transform;
            gameObject.SetActive(false);
        }

        if (collision.transform.tag == "Comet")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().HearthMission();
            gameObject.transform.parent = nullPos.transform;
            gameObject.SetActive(false);           
        }

        if (collision.transform.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().HearthMission();
            gameObject.transform.parent = nullPos.transform;
            gameObject.SetActive(false);            
        }

        if (collision.transform.tag == "Asteroid")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<MissionsController>().EnemyObjectsMission();
            gameObject.transform.parent = nullPos.transform;
            gameObject.SetActive(false);            
        }



    }

    private void OnDisable()
    {
        gameObject.transform.position = nullPos.transform.position;
        rig.velocity = Vector3.zero;
        rig.isKinematic = true;
        rig.isKinematic = false;
    }
}
