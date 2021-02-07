using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyBehaviourMasterClass : MonoBehaviour
{


    protected Func<Vector3> moveDestination;
    protected Vector3 moveDir;
    protected float increasevalue;
    protected float enemyZigZagMovement;


    public void SetupEnemy(Func<Vector3> movedes)
    {
        moveDestination = movedes;
        transform.up = (moveDestination() - transform.position).normalized;
    }

    protected void FixedUpdate()
    {
        MoveEnemy();

    }

   protected virtual void MoveEnemy()
    {
        
    }
  
}
