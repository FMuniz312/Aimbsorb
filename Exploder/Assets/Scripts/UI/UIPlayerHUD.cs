using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MunizCodeKit.Systems;
using DG.Tweening;

public class UIPlayerHUD : MonoBehaviour
{
    [Header("Resource Input")]
    [SerializeField] Image currentPointsImage;
    [SerializeField] Text levelText;
    [SerializeField] Text healthText;

    [Header("Tweening")]
    [SerializeField] float energyPointsTextShakeDuration;
    [SerializeField] float energyPointsTextShakeStrenght;
    [SerializeField] float levelPointsTextShakeDuration;
    [SerializeField] float levelPointsTextShakeStrenght;
    [SerializeField] float healthPointsTextShakeStrenght;
    [SerializeField] float healthPointsTextShakeDuration;

    Tween shakeEnergyImageTween;
    Tween fillEnergyImageTween;
    Tween shakeLevelTextTween;
    Tween shakeDamageTextTween;
 
    private void Start()
    {
        CharacterBehaviour.instance.levelSystem.experiencePointsSystem.OnPointsChanged += PlayerPoints_OnEnergyPointsChanged;
        CharacterBehaviour.instance.levelSystem.levelPointsSystem.OnPointsChanged += LevelPoints_OnLevelPointsChanged; ;
        CharacterBehaviour.instance.healthSystem.OnPointsChanged += HealthSystem_OnPointsChanged;
        UpdateEnergyPointsText();
        UpdateLevelPointsText();
        UpdateHealthText();

    }

    private void HealthSystem_OnPointsChanged(object sender, PointsSystem.OnPointsDataEventArgs e)
    {
        UpdateHealthText();
        shakeDamageTextTween?.Complete();
        shakeDamageTextTween = healthText.rectTransform.DOShakeScale(healthPointsTextShakeDuration, healthPointsTextShakeStrenght);
    }

    private void LevelPoints_OnLevelPointsChanged(object sender, PointsSystem.OnPointsDataEventArgs e)
    {
        UpdateLevelPointsText();


    }

    private void PlayerPoints_OnEnergyPointsChanged(object sender, PointsSystem.OnPointsDataEventArgs e)
    {
        UpdateEnergyPointsText();
        shakeEnergyImageTween?.Complete();
        shakeLevelTextTween?.Complete();
        shakeEnergyImageTween = currentPointsImage.rectTransform.DOShakeScale(energyPointsTextShakeDuration, energyPointsTextShakeStrenght);
        shakeLevelTextTween = levelText.rectTransform.DOShakeScale(levelPointsTextShakeDuration, levelPointsTextShakeStrenght);
    }

    void UpdateEnergyPointsText()
    {
        PointsSystem pointsSystem = CharacterBehaviour.instance.levelSystem.experiencePointsSystem;
        float endValue = (float)pointsSystem.currentPoints / pointsSystem.maxPoints;
        fillEnergyImageTween?.Complete();
        fillEnergyImageTween =  currentPointsImage.DOFillAmount(endValue, 1f);


        }
    void UpdateLevelPointsText()
    {
        levelText.text = "Level: " + CharacterBehaviour.instance.levelSystem.levelPointsSystem.currentPoints + " / " + CharacterBehaviour.instance.levelSystem.levelPointsSystem.maxPoints;

    }
    void UpdateHealthText()
    {
        healthText.text = "No-No's: " + CharacterBehaviour.instance.healthSystem.currentPoints + " / " + CharacterBehaviour.instance.healthSystem.maxPoints;

    }

}
