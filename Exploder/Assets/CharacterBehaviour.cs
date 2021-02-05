using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Systems;

public class CharacterBehaviour : MonoBehaviour
{
    public PointsSystem pointsSystem { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        pointsSystem = new PointsSystem();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
