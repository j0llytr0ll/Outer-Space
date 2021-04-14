using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCostMissions : MonoBehaviour
{
    public GameObject[] endMissionsObject;
    public Text[] endMissions;
    public void OnEndDisplay()
    {


        StartCoroutine(EndDisplayMissions());
    }
   
    IEnumerator EndDisplayMissions()
    {
        yield return new WaitForSeconds(0);
        for (int i = 0; i < MissionsController.endCollect.Length; i++)
        {
            while (MissionsController.endCollect[i] > MissionsController.endMax[i])
            {
                MissionsController.endCollect[i] = MissionsController.endCollect[i] - MissionsController.endMax[i];
                MissionsController.endMax[i] = (MissionsController.endMax[i] / 2) + MissionsController.endMax[i];
            }
            
            endMissions[i].text = MissionsController.endCollect[i] + " / " + MissionsController.endMax[i];
        }
        yield return new WaitForSeconds(0);
        for (int i = 0; i < MissionsController.missionsCollect.Length; i++)
        {
            if (MissionsController.gameMax[i] > MissionsController.endMax[i])
            {
                while (MissionsController.missionsCollect[i] >= MissionsController.missionsMax[i])
                {
                    endMissionsObject[i].SetActive(true);
                    yield return new WaitForSeconds(0.25f);
                    endMissions[i].text = MissionsController.missionsMax[i] + " / " + MissionsController.missionsMax[i];
                    MissionsController.missionsCollect[i] = MissionsController.missionsCollect[i] - MissionsController.missionsMax[i];
                    MissionsController.missionsMax[i] = (MissionsController.missionsMax[i] / 2) + MissionsController.missionsMax[i];
                    yield return new WaitForSeconds(0.25f);
                    if (MissionsController.missionsCollect[i] > MissionsController.missionsMax[i])
                        endMissionsObject[i].SetActive(false);
                }
                yield return new WaitForSeconds(0);
            }           
        }
    }

}
