using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Balance")]
    [SerializeField] float speed;



    Func<Vector3> moveDestination;
    Vector3 moveDir;

    public void SetupEnemy(Func<Vector3> movedes)
    {
        moveDestination = movedes;
    }

    private void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        moveDir = (moveDestination() - transform.position).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
