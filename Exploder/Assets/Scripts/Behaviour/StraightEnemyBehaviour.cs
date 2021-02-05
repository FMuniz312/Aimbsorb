using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightEnemyBehaviour : EnemyBehaviourMasterClass
{

    [Header("Resource Input")]
    [SerializeField] DefaultEnemyScriptableObject enemyScriptableObject;

    protected override void MoveEnemy()
    {
        moveDir = (moveDestination() - transform.position).normalized;

        transform.position += moveDir * enemyScriptableObject.speed * Time.deltaTime;


    }
}
