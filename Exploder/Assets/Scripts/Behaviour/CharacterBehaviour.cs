using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MunizCodeKit.Systems;

public class CharacterBehaviour : MonoBehaviour
{
    [Header("Tweening")]
    [SerializeField] float HitCameraShakeStrenght;
    [SerializeField] float HitCameraShakeDuration;
    

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
        levelSystem = new LevelSystem(30,4,2f);
        healthSystem = new PointsSystem(20);
  
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
        MunizCodeKit.MonoBehaviours.CameraController.ShakeCamera(HitCameraShakeDuration, HitCameraShakeStrenght);
        MunizCodeKit.Factory.PrefabFactory.instance.CreateItem(MunizCodeKit.Factory.PrefabFactory.FactoryProduct.PlayerHitParticle, gameobject.transform.position);

    }
}
