using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyZigZag", menuName = "Enemy/EnemyZigZag")]
public class ZigZagEnemyScriptableObject : ScriptableObject
{
    public EnemyMoveType moveType;

    [Header("Game Balance")]
    public float speed;

    [Header("ZigZagMove Only")]
    [Header("Tweening")]
    public float zigzagStrenght;
    public float zigzagSpeedChange;
}
