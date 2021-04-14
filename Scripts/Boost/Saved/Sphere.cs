using UnityEngine;


public class Sphere : MonoBehaviour
{
    public GameObject visibleSaved;
    public GameObject visibleBoost;
    void OnDisable()
    {
        VisibleBoost.nullPositionVis = 0;
        visibleBoost.GetComponent<VisibleBoost>().NullPosition();
    }

    public void DestroySphere()
    {
        gameObject.SetActive(false);          
    }
    

   
}
