using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionsController : MonoBehaviour
{
    public static int[] missionsCollect;
    public static int[] missionsMax;

    public static int[] gameMax;
    public static int[] gameCollect;

    public static int[] endMax;
    public static int[] endCollect;

    public Text[] displayMissions;
    public Text[] pausMissions;
    public Text[] endMissions;

    public GameObject[] displayMissionsObject;

    public GameObject[] endMissionsObject;



    private void OnEnable()
    {
        missionsCollect = new int[] { Missions.savedCollect,
                                      Missions.magnetCollect,
                                      Missions.hearthCollect,
                                      Missions.rocketCollect,
                                      Missions.factorCollect,
                                      Missions.enemyObjectsCollect};

        gameCollect = new int[] { Missions.savedCollect,
                                  Missions.magnetCollect,
                                  Missions.hearthCollect,
                                  Missions.rocketCollect,
                                  Missions.factorCollect,
                                  Missions.enemyObjectsCollect};

        endCollect = new int[] { Missions.savedCollect,
                                  Missions.magnetCollect,
                                  Missions.hearthCollect,
                                  Missions.rocketCollect,
                                  Missions.factorCollect,
                                  Missions.enemyObjectsCollect};

        missionsMax = new int[] { Missions.savedMax,
                                  Missions.magnetMax,
                                  Missions.hearthMax,
                                  Missions.rocketMax,
                                  Missions.factorMax,
                                  Missions.enemyObjectsMax};

        gameMax = new int[] { Missions.savedMax,
                                  Missions.magnetMax,
                                  Missions.hearthMax,
                                  Missions.rocketMax,
                                  Missions.factorMax,
                                  Missions.enemyObjectsMax};

        endMax = new int[] { Missions.savedMax,
                                  Missions.magnetMax,
                                  Missions.hearthMax,
                                  Missions.rocketMax,
                                  Missions.factorMax,
                                  Missions.enemyObjectsMax};

        for (int i = 0; i < missionsCollect.Length; i++)
        {
            while (gameCollect[i] >= gameMax[i])
            {
                gameCollect[i] = gameCollect[i] - gameMax[i];
                gameMax[i] = (gameMax[i] / 2) + gameMax[i];
            }
        }
        
        for (int i = 0; i < missionsCollect.Length; i++)
        {
            pausMissions[i].text = gameCollect[i] + " / " + gameMax[i];
        }
    }

    public void SavedMission()
    {
        missionsCollect[0]++;
        gameCollect[0]++;
        
        if (gameCollect[0] >= gameMax[0])
        {
            displayMissions[0].text = gameCollect[0] + " / " + gameMax[0];
            gameCollect[0] = gameCollect[0] - gameMax[0];
            gameMax[0] = (gameMax[0] / 2) + gameMax[0];
            displayMissionsObject[0].SetActive(true);
            Invoke("SavedInvok", 1.6f);
            Invoke("SavedDeathInvok", 3f);
        }
        pausMissions[0].text = gameCollect[0] + " / " + gameMax[0];
    }
    private void SavedInvok()
    {
        displayMissions[0].text = gameCollect[0] + " / " + gameMax[0];
    }
    private void SavedDeathInvok()
    {
        displayMissionsObject[0].SetActive(false);
    }

    //-------------------------------------------------------------------------
    public void MagnetMission()
    {
        missionsCollect[1]++;
        gameCollect[1]++;

        if (gameCollect[1] >= gameMax[1])
        {
            displayMissions[1].text = gameCollect[1] + " / " + gameMax[1];
            gameCollect[1] = gameCollect[1] - gameMax[1];
            gameMax[1] = (gameMax[1] / 2) + gameMax[1];
            displayMissionsObject[1].SetActive(true);
            Invoke("MagnetInvok", 1.6f);
            Invoke("MagnetDeathInvok", 3f);
        }
        pausMissions[1].text = gameCollect[1] + " / " + gameMax[1];
    }
    private void MagnetInvok()
    {
        displayMissions[1].text = gameCollect[1] + " / " + gameMax[1];
    }
    private void MagnetDeathInvok()
    {
        displayMissionsObject[1].SetActive(false);
    }

    //-------------------------------------------------------------------------
    public void HearthMission()
    {
        missionsCollect[2]++;
        gameCollect[2]++;

        if (gameCollect[2] >= gameMax[2])
        {
            displayMissions[2].text = gameCollect[2] + " / " + gameMax[2];
            gameCollect[2] = gameCollect[2] - gameMax[2];
            gameMax[2] = (gameMax[2] / 2) + gameMax[2];
            displayMissionsObject[2].SetActive(true);
            Invoke("HearthInvok", 1.6f);
            Invoke("HearthDeathInvok", 3f);
        }
        pausMissions[2].text = gameCollect[2] + " / " + gameMax[2];
    }
    private void HearthInvok()
    {
        displayMissions[2].text = gameCollect[2] + " / " + gameMax[2];
    }
    private void HearthDeathInvok()
    {
        displayMissionsObject[2].SetActive(false);
    }

    //-------------------------------------------------------------------------

    public void RocketMission()
    {
        missionsCollect[3]++;
        gameCollect[3]++;

        if (gameCollect[3] >= gameMax[3])
        {
            displayMissions[3].text = gameCollect[3] + " / " + gameMax[3];
            gameCollect[3] = gameCollect[3] - gameMax[3];
            gameMax[3] = (gameMax[3] / 2) + gameMax[3];
            displayMissionsObject[3].SetActive(true);
            Invoke("RocketInvok", 1.6f);
            Invoke("RocketDeathInvok", 3f);
        }
        pausMissions[3].text = gameCollect[3] + " / " + gameMax[3];
    }
    private void RocketInvok()
    {
        displayMissions[3].text = gameCollect[3] + " / " + gameMax[3];
    }
    private void RocketDeathInvok()
    {
        displayMissionsObject[3].SetActive(false);
    }

    //-------------------------------------------------------------------------

    public void FactorMission()
    {
        missionsCollect[4]++;
        gameCollect[4]++;

        if (gameCollect[4] >= gameMax[4])
        {
            displayMissions[4].text = gameCollect[4] + " / " + gameMax[4];
            gameCollect[4] = gameCollect[4] - gameMax[4];
            gameMax[4] = (gameMax[4] / 2) + gameMax[4];
            displayMissionsObject[4].SetActive(true);
            Invoke("FactorInvok", 1.6f);
            Invoke("FactorDeathInvok", 3f);
        }
        pausMissions[4].text = gameCollect[4] + " / " + gameMax[4];
    }
    private void FactorInvok()
    {
        displayMissions[4].text = gameCollect[4] + " / " + gameMax[4];
    }
    private void FactorDeathInvok()
    {
        displayMissionsObject[4].SetActive(false);
    }

    //-------------------------------------------------------------------------

    public void EnemyObjectsMission()
    {
        missionsCollect[5]++;
        gameCollect[5]++;

        if (gameCollect[5] >= gameMax[5])
        {
            displayMissions[5].text = gameCollect[5] + " / " + gameMax[5];
            gameCollect[5] = gameCollect[5] - gameMax[5];
            gameMax[5] = (gameMax[5] / 2) + gameMax[5];
            displayMissionsObject[5].SetActive(true);
            Invoke("EnemyObjectsInvok", 1.6f);
            Invoke("EnemyObjectsDeathInvok", 3f);
        }
        pausMissions[5].text = gameCollect[5] + " / " + gameMax[5];
    }
    private void EnemyObjectsInvok()
    {
        displayMissions[5].text = gameCollect[5] + " / " + gameMax[5];
    }
    private void EnemyObjectsDeathInvok()
    {
        displayMissionsObject[5].SetActive(false);
    }

    //-------------------------------------------------------------------------

    
}
