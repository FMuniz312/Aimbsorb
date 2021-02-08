using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnemyMovementBehaviour : MonoBehaviour
{
    Transform parentPos;
    bool animate;
     public void Setup(Transform parent)
    {
        animate = true;
        parentPos = parent;
        transform.up = parent.up;
        transform.position = parent.position;
        
    }

    private void Update()
    {
        if (animate ) transform.position = parentPos.position;

    }

    public void DestroyParticle()
    {
        GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
        animate = false;

        Destroy(gameObject, 3);
    }
}
