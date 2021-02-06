﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyZigZag", menuName = "Enemy/EnemyBoomerang")]
public class BoomerangEnemyScriptableObject : ScriptableObject
{
    public EnemyMoveType moveType;

    [Header("Game Balance")]
    public float speed;
 
    
}
