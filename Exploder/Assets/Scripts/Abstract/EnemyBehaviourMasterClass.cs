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
    ParticleEnemyMovementBehaviour particleEnemyMovementBehaviour;


    public void SetupEnemy(Func<Vector3> movedes)
    {
        moveDestination = movedes;
        transform.up = (moveDestination() - transform.position).normalized;
        GameManager.onGameWon += GameManager_onGameWon;
        GameManager.onGameLost += GameManager_onGameLost;
        GameObject particleFollow = MunizCodeKit.Factory.PrefabFactory.instance.CreateItem(MunizCodeKit.Factory.PrefabFactory.FactoryProduct.FollowEnemyParticle, transform.position);
        particleEnemyMovementBehaviour = particleFollow.GetComponent<ParticleEnemyMovementBehaviour>();
        particleEnemyMovementBehaviour.Setup(transform);
    }

   

    private void GameManager_onGameWon(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

    private void GameManager_onGameLost(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

    protected void FixedUpdate()
    {
        MoveEnemy();

    }

   protected virtual void MoveEnemy()
    {
        
    }
    private void OnDestroy()
    {
        GameManager.onGameWon -= GameManager_onGameWon;
        GameManager.onGameLost -= GameManager_onGameLost;
        particleEnemyMovementBehaviour.DestroyParticle();
    }

}
