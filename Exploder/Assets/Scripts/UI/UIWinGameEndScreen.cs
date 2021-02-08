using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class UIWinGameEndScreen : MonoBehaviour
{
    [Header("Resource Income")]
    [SerializeField] Text textTimerRect;
    [SerializeField] RectTransform textWinRect;
    [SerializeField] Text textCommentRect;
    [SerializeField] RectTransform buttonRetry;
    Vector2 textWinDefaultPos;
    Vector3 retryButtontDefaultScale;

    [Header("Win Text Tweening")]
    [SerializeField] float winTextDistanceAway;
    [SerializeField] float wintTextDuration;

    [Header("Timer and comment Tweening")]
    [SerializeField] float timerEffectDuration;
    [SerializeField] float commentEffectDuration;
    [SerializeField] float timerEffectsDelay;

    [Header("Retry Button Tweening")]
    [SerializeField] float resizeDuration;


    private void Awake()
    {
        textWinDefaultPos = textWinRect.anchoredPosition;
        textWinRect.anchoredPosition = Vector2.up * winTextDistanceAway;
        retryButtontDefaultScale = buttonRetry.localScale;
        buttonRetry.localScale = Vector3.zero;
        textTimerRect.text = "";
        textCommentRect.text = "";

    }
    private void Start()
    {
        textWinRect.DOAnchorPos(textWinDefaultPos, wintTextDuration);
        buttonRetry.DOScale(retryButtontDefaultScale, resizeDuration).SetDelay(timerEffectsDelay + wintTextDuration + timerEffectDuration);
        textTimerRect.DOText(GameTimerController.instance.GetSceneDurationUntilNow().ToString("mm\\:ss"), timerEffectDuration, true, ScrambleMode.Numerals).SetDelay(timerEffectsDelay);
        textCommentRect.DOText(GetCorrectComment(), timerEffectDuration, true, ScrambleMode.Numerals).SetDelay(timerEffectsDelay+timerEffectDuration);

    }

    string GetCorrectComment()
    {
        int duration = GameTimerController.instance.GetSceneDurationUntilNow().Seconds;
        const float MIN_EXPECTED = 190;
        const float EXPECTED = 315;
        if (duration < MIN_EXPECTED)
        {
            return "Wow, that's really fast! One of the best!";
        }
        else if (duration >= MIN_EXPECTED && duration < EXPECTED)
        {
            return "Nice! But you can finish it faster!";
        }
        return "oh... that's not really good, wanna try again?";
    }
}
