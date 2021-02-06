using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Systems;

public class CharacterBehaviour : MonoBehaviour
{
    public PointsSystem pointsSystem { get; private set; }

    #region singleton
    static public CharacterBehaviour instance { get; private set; }
    #endregion

    void Awake()
    {
        if (instance == null) instance = this;
        pointsSystem = new PointsSystem();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
