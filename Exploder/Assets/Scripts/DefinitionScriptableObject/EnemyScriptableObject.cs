using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyMoveType moveType;
}
public enum EnemyMoveType
{
    Straight,
    ZigZag,
    Boomerang
}