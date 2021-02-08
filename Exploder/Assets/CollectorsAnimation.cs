using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorsAnimation : MonoBehaviour
{
    float speed = 10;
    void Update()
    {
        speed += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, speed*Time.deltaTime));
    }
}
