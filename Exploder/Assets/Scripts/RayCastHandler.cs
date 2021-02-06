using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RayCastHandler : MonoBehaviour
{
    [Header("Resource Input")]
    [SerializeField] float raycastRadius;
    [SerializeField] DataHolder[] dataHolders;

    CharacterBehaviour playerScript;



    RaycastHit2D[] info;

    private void Start()
    {
        playerScript = transform.GetComponent<CharacterBehaviour>();


        //DEBUG CODE
        playerScript.pointsSystem.OnPointsChanged += PointsSystem_OnPointsChanged;
        //
    }

    private void PointsSystem_OnPointsChanged(object sender, MunizCodeKit.Systems.PointsSystem.OnPointsDataEventArgs e)
    {
        Debug.Log("Total points: " + e.CurrentPointsEventArgs);

    }

    private void Update()
    {
        for (int i = 0; i < dataHolders.Length; i++)
        {
            CheckPlayerInput(i);
        }
    }

    void CheckPlayerInput(int i)
    {

        if (Input.GetKeyDown(dataHolders[i].killKey))
        {
            info = CheckIfHitSomething(dataHolders[i]);
            if (info.Length > 0)
            {
                EnemyHitted(info);
            }
        }
    }
    RaycastHit2D[] CheckIfHitSomething(DataHolder data)
    {
        RaycastHit2D[] info;
        info = Physics2D.CircleCastAll(data.raycastTransf.position, raycastRadius, Vector2.zero);
        return info;
    }

    void EnemyHitted(RaycastHit2D[] raycastHit2Ds)
    {
        Vector2 centroidpos = raycastHit2Ds.First().centroid;
        float points = 0;
        float distance;
        float temppoints;
        foreach (RaycastHit2D raycast in raycastHit2Ds)
        {
            //Por enquanto a relação entre pontos e distância é de 1 para 1 (não é o ideal) 
            distance = Vector2.Distance(raycast.collider.transform.position, centroidpos);
            temppoints = 1 / distance;
            if (temppoints > 5) temppoints = 5;
            points += temppoints;
            Destroy(raycast.collider.gameObject);
            Debug.Log("Enemy destroyed! Your precision was " + distance.ToString("F2") + " units away from the center!");
        }
        MunizCodeKit.MonoBehaviours.CameraController.ShakeCamera(.07f, .8f);
        points *= 100;
        playerScript.pointsSystem.AddValue((int)points);
    }

    DataHolder GetCorrectData(KeyCode killkey)
    {
        return dataHolders.Where((data) => data.killKey == killkey).FirstOrDefault();
    }

    [System.Serializable]
    public struct DataHolder
    {
        public Transform raycastTransf;
        public KeyCode killKey;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(dataHolders[0].raycastTransf.position, raycastRadius);
        Gizmos.DrawWireSphere(dataHolders[1].raycastTransf.position, raycastRadius);
        Gizmos.DrawWireSphere(dataHolders[2].raycastTransf.position, raycastRadius);
        Gizmos.DrawWireSphere(dataHolders[3].raycastTransf.position, raycastRadius);
    }

}
