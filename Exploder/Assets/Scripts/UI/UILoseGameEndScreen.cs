using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UILoseGameEndScreen : MonoBehaviour
{
    [Header("Resource Income")]
    [SerializeField] RectTransform loseTextGameObject;
    [SerializeField] RectTransform retryButtonGameObject;
    Vector2 loseTextDefaultPos;
    Vector3 retryButtontDefaultScale;

    [Header("Lose Text Tweening")] 
     [SerializeField] float lostTextDistanceAway;
     [SerializeField] float lostTextDuration;

    [Header("Retry Button Tweening")]
    [SerializeField] float resizeDuration;
    [SerializeField] float delay;
     

    private void Awake()
    {
        loseTextDefaultPos = loseTextGameObject.anchoredPosition;
        loseTextGameObject.anchoredPosition = Vector2.up * lostTextDistanceAway;
        retryButtontDefaultScale = retryButtonGameObject.localScale;
        retryButtonGameObject.localScale = Vector3.zero;

    }
    private void Start()
    {
        loseTextGameObject.DOAnchorPos(loseTextDefaultPos, lostTextDuration);
        retryButtonGameObject.DOScale(retryButtontDefaultScale, resizeDuration).SetDelay(delay);
         
    }


}
