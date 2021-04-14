using System.Collections;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
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

    int total;
    int randomNumber;

    int[] table = new int[] {60, 40 };



    public void MovmentEnemy()
    {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * HudScr.speedBrick);
        AsteroidPosition();
    }

    public void RotateEnemy()
    {
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
        chilld.GetComponent<EnemSpawner>().StopParticle();
    }

    public void StartMagnet()
    {
        StartCoroutine(MagnetPos());
        rig.isKinematic = true;
        rig.isKinematic = false;
        rig.angularVelocity = new Vector3(0, 1, 0) * tumbl;
    }
    IEnumerator MagnetPos()
    {
        yield return new WaitForSeconds(0);
        while (coin.activeSelf)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, Time.deltaTime * 6);
            yield return new WaitForSeconds(0);
        }
        
    }

    

    void AsteroidPosition()
    {
        //xSelector = Random.Range(0, x.Length);
        //ySelector = Random.Range(0, y.Length);

        //gameObject.transform.position = new Vector3(x[xSelector], y[ySelector], gameObject.transform.position.z);

        //gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("Empty").transform.position.x, GameObject.FindGameObjectWithTag("Empty").transform.position.y, gameObject.transform.position.z);

        total = 0;
        randomNumber = 0;

        foreach (var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                if (i == 0)
                {
                    xSelector = Random.Range(0, x.Length);
                    ySelector = Random.Range(0, y.Length);

                    gameObject.transform.position = new Vector3(x[xSelector], y[ySelector], gameObject.transform.position.z);
                }
                else
                    gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("Empty").transform.position.x, GameObject.FindGameObjectWithTag("Empty").transform.position.y, gameObject.transform.position.z);

                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }
}
