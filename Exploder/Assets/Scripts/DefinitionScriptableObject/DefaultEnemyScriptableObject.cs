using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "EnemyStraight", menuName = "Enemy/EnemyStraight")]
public class DefaultEnemyScriptableObject : ScriptableObject
{
    public EnemyMoveType moveType;

    [Header("Game Balance")]
    public float speed;


}
 
 
public enum EnemyMoveType
{
    Straight,
    ZigZag,
    Boomerang
}