using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RayCastHandler : MonoBehaviour
{
    [Header("Resource Input")]
    [SerializeField] Vector3 raycastPos;
    [SerializeField] float raycastRadius;
    [SerializeField] KeyCode killKey;

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
        Debug.Log(e.CurrentPointsEventArgs);
    }

    private void Update()
    {
        if (Input.GetKeyDown(killKey))
        {
            info = CheckIfHitSomething();
            if (info.Length > 0)
            {
                EnemyHitted(info);
            }
        }
    }

    RaycastHit2D[] CheckIfHitSomething()
    {
        RaycastHit2D[] info;
        info = Physics2D.CircleCastAll(raycastPos, raycastRadius, Vector2.zero);
        return info;
    }

    void EnemyHitted(RaycastHit2D[] raycastHit2Ds)
    {
        Vector2 centroidpos = raycastHit2Ds.First().centroid;
        float points = 0;
        foreach (RaycastHit2D raycast in raycastHit2Ds)
        {
            //Por enquanto a relação entre pontos e distância é de 1 para 1 (não é o ideal) 
            points +=  1 / Vector2.Distance(raycast.collider.transform.position, centroidpos);
            Destroy(raycast.collider.gameObject);
        }
        points *= 100;
        playerScript.pointsSystem.AddValue((int)points);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(raycastPos, raycastRadius);
    }

}
