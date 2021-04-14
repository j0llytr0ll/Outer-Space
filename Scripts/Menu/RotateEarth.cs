using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public float speed;
    public float speedSky;
    public GameObject sky;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 360, 0) * (Time.deltaTime * speed));
        sky.transform.Rotate(new Vector3(0, 360, 0) * (Time.deltaTime * speedSky));
    }
}
