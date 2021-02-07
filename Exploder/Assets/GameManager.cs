using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Factory;

public class GameManager : MonoBehaviour
{
    [Header("Resource Input")]
    [SerializeField] Transform topRight;
    [SerializeField] Transform topLeft;
    [SerializeField] Transform bottomLeft;
    [SerializeField] Transform bottomRight;
    [SerializeField] float spawnDistance;
    [SerializeField] float spawnTimer;
    float timer;
    int randomPos;
    Vector3 finalpos;
    int randomEnemy;
    private void Start()
    {
        timer = spawnTimer;
        CharacterBehaviour.instance.levelSystem.levelPointsSystem.OnPointsIncreased += LevelPointsSystem_OnPointsIncreased;
    }

    private void LevelPointsSystem_OnPointsIncreased(object sender, MunizCodeKit.Systems.PointsSystem.OnPointsDataEventArgs e)
    {
        spawnTimer *= .8f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0) return;
        timer += spawnTimer;
        randomPos = Random.Range(0, 4);
        finalpos = Vector3.zero;
        randomEnemy = GetEnemyIndex();
        switch (randomPos)
        {
            case 0: finalpos = topRight.position.normalized * spawnDistance; break;
            case 1: finalpos = topLeft.position.normalized * spawnDistance; break;
            case 2: finalpos = bottomLeft.position.normalized * spawnDistance; break;
            case 3: finalpos = bottomRight.position.normalized * spawnDistance; break;
        }
        PrefabFactory.instance.CreateItem((PrefabFactory.FactoryProduct)randomEnemy, finalpos).GetComponent<EnemyBehaviourMasterClass>().SetupEnemy(() => Vector3.zero);

    }

     
    int GetEnemyIndex()
    {
        switch (CharacterBehaviour.instance.levelSystem.levelPointsSystem.currentPoints)
        {
            case 1:
                return 0;
                ; break;
            case 2:
               return Random.Range(0, 2);
                ; break;
            case 3:
                bool normalEnemyChance = Random.Range(0, 100) < 30;
                if (normalEnemyChance) return 0;
                return Random.Range(1, 3);
                ; break;
            default:
                return Random.Range(0, 3);
                ; break;

        }
    }
}
