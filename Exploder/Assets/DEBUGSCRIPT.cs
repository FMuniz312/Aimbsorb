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
            PrefabFactory.instance.CreateItem(PrefabFactory.FactoryProduct.DefaultEnemy, Vector2.up * 4).GetComponent<EnemyBehaviour>().SetupEnemy(()=>Vector2.zero);
            PrefabFactory.instance.CreateItem(PrefabFactory.FactoryProduct.DefaultEnemy, Vector2.up * 6).GetComponent<EnemyBehaviour>().SetupEnemy(()=>Vector2.zero);
            PrefabFactory.instance.CreateItem(PrefabFactory.FactoryProduct.DefaultEnemy, Vector2.up * 8).GetComponent<EnemyBehaviour>().SetupEnemy(()=>Vector2.zero);
        }
    }
}
