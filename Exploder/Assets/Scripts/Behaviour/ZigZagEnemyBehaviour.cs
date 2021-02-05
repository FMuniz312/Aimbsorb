using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemyBehaviour : EnemyBehaviourMasterClass
{

    [Header("Resource Input")]
    [SerializeField] ZigZagEnemyScriptableObject enemyScriptableObject;

    float movementValueIncreaser;
    float movementPositionResult;

    protected override void MoveEnemy()
    {
        moveDir = (moveDestination() - transform.position).normalized;
        movementValueIncreaser += Time.deltaTime;
        movementPositionResult = Mathf.Cos(movementValueIncreaser * enemyScriptableObject.zigzagSpeedChange);
        movementPositionResult *= enemyScriptableObject.zigzagStrenght;
        transform.position += moveDir * enemyScriptableObject.speed * Time.deltaTime;
        transform.position += transform.right * movementPositionResult * Time.deltaTime;

    }
}
