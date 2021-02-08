﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MunizCodeKit.Systems;

public class CharacterBehaviour : MonoBehaviour
{
    [Header("Tweening")]
    [SerializeField] float HitCameraShakeStrenght;
    [SerializeField] float HitCameraShakeDuration;
    [SerializeField] float HitCameraZoomIn;
    [SerializeField] float HitCameraZoomSpeed;

    float zoomDefault;
    Tween cameraZoomIn;

    public LevelSystem levelSystem { get; private set; }
    public PointsSystem healthSystem { get; private set; }

 
    #region singleton
    static public CharacterBehaviour instance { get; private set; }
    #endregion

    void Awake()
    {
        if (instance == null) instance = this;
        levelSystem = new LevelSystem(100,4,1.2f);
        healthSystem = new PointsSystem(20);
         zoomDefault = Camera.main.orthographicSize;
    }
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            VisualEffectOnHit(collision.gameObject);
            SoundSystem.instance.PlaySound(SoundSystem.Sound.PlayerHit);
            healthSystem.AddValue(1);
            Destroy(collision.gameObject);
        }
    }
    void VisualEffectOnHit(GameObject gameobject)
    {
        cameraZoomIn?.Complete();
        Camera.main.orthographicSize = zoomDefault; //safe reset
        TweenCallback actionAfterZoomInEffect = () => Camera.main.orthographicSize = zoomDefault;
        cameraZoomIn = Camera.main.DOOrthoSize(HitCameraZoomIn, 1 / HitCameraZoomSpeed).OnComplete(actionAfterZoomInEffect);
        MunizCodeKit.MonoBehaviours.CameraController.ShakeCamera(HitCameraShakeDuration, HitCameraShakeStrenght);
        MunizCodeKit.Factory.PrefabFactory.instance.CreateItem(MunizCodeKit.Factory.PrefabFactory.FactoryProduct.PlayerHitParticle, gameobject.transform.position);

    }
}