using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Factory;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Header("Resource Input")]
    [SerializeField] Transform topRight;
    [SerializeField] Transform topLeft;
    [SerializeField] Transform bottomLeft;
    [SerializeField] Transform bottomRight;
    [SerializeField] float spawnDistance;
    [SerializeField] float spawnTimer;

    static public event EventHandler onGameWon;
    static public event EventHandler onGameLost;
    AudioSource songAudioSource;
    public static bool gameRunning;
    float timer;
    int randomPos;
    Vector3 finalpos;
    int randomEnemy;
    private void Start()
    {
        songAudioSource = Camera.main.gameObject.GetComponent<AudioSource>();
        songAudioSource.volume = 0;
        DOTween.To(()=>songAudioSource.volume, (p) => songAudioSource.volume = p, 1, 2.5f);
        gameRunning = true;
        timer = spawnTimer;
        CharacterBehaviour.instance.levelSystem.levelPointsSystem.OnPointsIncreased += LevelPointsSystem_OnPointsIncreased;
        CharacterBehaviour.instance.healthSystem.OnPointsMax += HealthSystem_OnPointsMax;
    }

    private void HealthSystem_OnPointsMax(object sender, MunizCodeKit.Systems.PointsSystem.OnPointsDataEventArgs e)
    {
        DOTween.To(() => songAudioSource.volume, (p) => songAudioSource.volume = p, .4f, 2.5f);
        onGameLost?.Invoke(this, EventArgs.Empty);
        gameRunning = false;

    }

    private void LevelPointsSystem_OnPointsIncreased(object sender, MunizCodeKit.Systems.PointsSystem.OnPointsDataEventArgs e)
    {
        spawnTimer *= .8f;
        if (e.CurrentPointsEventArgs == CharacterBehaviour.instance.levelSystem.levelPointsSystem.maxPoints)
        {
            CharacterBehaviour.instance.levelSystem.experiencePointsSystem.OnPointsMax += ExperiencePointsSystem_OnPointsMax;
        }
    }

    private void ExperiencePointsSystem_OnPointsMax(object sender, MunizCodeKit.Systems.PointsSystem.OnPointsDataEventArgs e)
    {
        onGameWon?.Invoke(this, EventArgs.Empty);
        gameRunning = false;
    }

    void Update()
    {
        if (gameRunning)
        {
            timer -= Time.deltaTime;
            if (timer > 0) return;
            timer += spawnTimer;
            randomPos = UnityEngine.Random.Range(0, 4);
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
    }


    int GetEnemyIndex()
    {
        switch (CharacterBehaviour.instance.levelSystem.levelPointsSystem.currentPoints)
        {
            case 1:
                return 0;
                ; break;
            case 2:
                return UnityEngine.Random.Range(0, 2);
                ; break;
            case 3:
                bool normalEnemyChance = UnityEngine.Random.Range(0, 100) < 30;
                if (normalEnemyChance) return 0;
                return UnityEngine.Random.Range(1, 3);
                ; break;
            default:
                return UnityEngine.Random.Range(0, 3);
                ; break;

        }
    }
}
