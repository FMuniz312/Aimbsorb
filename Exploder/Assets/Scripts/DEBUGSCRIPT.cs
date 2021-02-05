using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Factory;

public class DEBUGSCRIPT : MonoBehaviour
{
    [Header("Resource Input")]
    [SerializeField] Transform topRight;
    [SerializeField] Transform topLeft;
    [SerializeField] Transform bottomLeft;
    [SerializeField] Transform bottomRight;
    [SerializeField] float spawnDistance;
    [SerializeField] float spawnTimer;
    float timer;
    private void Start()
    {
        timer = spawnTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0) return;
        timer += spawnTimer;
        int randomPos = Random.Range(0, 4);
        Vector3 finalpos = Vector3.zero;
        int randomEnemy = Random.Range(0, 2);
        switch (randomPos)
        {
            case 0: finalpos = topRight.position.normalized * spawnDistance; break;
            case 1: finalpos = topLeft.position.normalized * spawnDistance; break;
            case 2: finalpos = bottomLeft.position.normalized * spawnDistance; break;
            case 3: finalpos = bottomRight.position.normalized * spawnDistance; break;
        }
        PrefabFactory.instance.CreateItem((PrefabFactory.FactoryProduct)randomEnemy, finalpos).GetComponent<EnemyBehaviourMasterClass>().SetupEnemy(() => Vector3.zero);

    }
}
