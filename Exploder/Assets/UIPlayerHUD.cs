using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MunizCodeKit.Systems;
using DG.Tweening;

public class UIPlayerHUD : MonoBehaviour
{
    [Header("Resource Input")]
    [SerializeField] Text currentPointsText;
    [SerializeField] Text levelText;

    [Header("Tweening")]
    [SerializeField] float energyPointsTextShakeDuration;
    [SerializeField] float energyPointsTextShakeStrenght;
    [SerializeField] float levelPointsTextShakeDuration;
    [SerializeField] float levelPointsTextShakeStrenght;

    Tween shakeEnergyTextTween;

    private void Start()
    {
        CharacterBehaviour.instance.levelSystem.experiencePointsSystem.OnPointsChanged += PlayerPoints_OnEnergyPointsChanged;
        CharacterBehaviour.instance.levelSystem.levelPointsSystem.OnPointsChanged += LevelPoints_OnLevelPointsChanged; ;
        UpdateEnergyPointsText();
        UpdateLevelPointsText();

    }

    private void LevelPoints_OnLevelPointsChanged(object sender, PointsSystem.OnPointsDataEventArgs e)
    {
        UpdateLevelPointsText();
        shakeEnergyTextTween?.Complete();
        shakeEnergyTextTween = transform.DOShakeScale(levelPointsTextShakeDuration, levelPointsTextShakeStrenght);

    }

    private void PlayerPoints_OnEnergyPointsChanged(object sender, PointsSystem.OnPointsDataEventArgs e)
    {
        UpdateEnergyPointsText();
        shakeEnergyTextTween?.Complete();
        shakeEnergyTextTween = transform.DOShakeScale(energyPointsTextShakeDuration, levelPointsTextShakeStrenght);
    }

    void UpdateEnergyPointsText()
    {
        currentPointsText.text = "Energy: " + CharacterBehaviour.instance.levelSystem.experiencePointsSystem.currentPoints + " / " + CharacterBehaviour.instance.levelSystem.experiencePointsSystem.maxPoints;
    }
    void UpdateLevelPointsText()
    {
        levelText.text = "Level: " + CharacterBehaviour.instance.levelSystem.levelPointsSystem.currentPoints + " / " + CharacterBehaviour.instance.levelSystem.levelPointsSystem.maxPoints;
    }
}
