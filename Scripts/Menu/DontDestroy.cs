using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameObject[] scene;
    void Awake()
    {

        DontDestroyOnLoad(this);
        scene = GameObject.FindGameObjectsWithTag("Scene");
        if (scene.Length > 1)
        {
            scene[0].transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);

        }
        
    }

    
}
