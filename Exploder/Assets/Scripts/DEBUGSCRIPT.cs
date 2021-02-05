using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Factory;

public class DEBUGSCRIPT : MonoBehaviour
{
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PrefabFactory.instance.CreateItem(PrefabFactory.FactoryProduct.StraightEnemy, Vector2.up * 8).GetComponent<EnemyBehaviourMasterClass>().SetupEnemy(()=>Vector2.zero);
            PrefabFactory.instance.CreateItem(PrefabFactory.FactoryProduct.ZigZagEnemy, new Vector3(-8,0)).GetComponent<EnemyBehaviourMasterClass>().SetupEnemy(()=>Vector2.zero);
            PrefabFactory.instance.CreateItem(PrefabFactory.FactoryProduct.StraightEnemy, new Vector3(12, 0)).GetComponent<EnemyBehaviourMasterClass>().SetupEnemy(()=>Vector2.zero);
        }
    }
}
