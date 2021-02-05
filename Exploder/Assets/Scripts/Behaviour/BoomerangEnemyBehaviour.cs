using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoomerangEnemyBehaviour : EnemyBehaviourMasterClass
{

    [Header("Resource Input")]
    [SerializeField] BoomerangEnemyScriptableObject enemyScriptableObject;

    Vector3 safeMovement;
    float timerSpecialMove;
    float timerSafeMove;
    bool backToSafeMovement;
    private void Start()
    {
        safeMovement = transform.position;
        timerSpecialMove = enemyScriptableObject.timerMaxSpecialMove;
        timerSafeMove = enemyScriptableObject.timerMaxSafeMove;
    }
    protected override void MoveEnemy()
    {
        moveDir = (moveDestination() - transform.position).normalized;
        safeMovement += moveDir * Time.deltaTime * enemyScriptableObject.speed;

        if (backToSafeMovement)
        {
            timerSpecialMove = enemyScriptableObject.timerMaxSpecialMove;
            timerSafeMove -= Time.deltaTime;
        }
        else
        {
            timerSpecialMove -= Time.deltaTime;
        }
        if (timerSpecialMove <= 0)
        {
            timerSpecialMove = enemyScriptableObject.timerMaxSpecialMove;
            transform.DOMove(GetRandomClosePosition(), enemyScriptableObject.speedSpecialMove).OnComplete(() => backToSafeMovement = true);
            return;
        }

        transform.position += safeMovement;




    }

    Vector3 GetRandomClosePosition()
    {
        Vector3 position = safeMovement;
        position += MunizCodeKit.Systems.UtilsClass.GetRandomDir() * enemyScriptableObject.specialMoveDistance;
        return position;
    }
}
