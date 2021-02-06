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

    [Header("Tweening")]
    [SerializeField] float pointsTextShakeDuration;
    [SerializeField] float pointsTextShakeStrenght;

    Tween shakeTween;

    private void Start()
    {
        CharacterBehaviour.instance.pointsSystem.OnPointsChanged += PlayerPoints_OnPointsChanged;
        UpdatePointText();

    }
   
    private void PlayerPoints_OnPointsChanged(object sender, PointsSystem.OnPointsDataEventArgs e)
    {
        UpdatePointText();
        shakeTween?.Complete();
        shakeTween = transform.DOShakeScale(pointsTextShakeDuration, pointsTextShakeStrenght);
    }

    void UpdatePointText()
    {
        currentPointsText.text = "Energy: " + CharacterBehaviour.instance.pointsSystem.currentPoints;
    }
}
