using UnityEngine;

public class WeponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    public static float speedBr;
    public float speedBrick;
    private void Start()
    {
        speedBr = speedBrick;
        InvokeRepeating("Fire", delay, fireRate);
    }

    
    private void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

    }
}
