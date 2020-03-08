using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HUDManager : MonoBehaviour
{
    public Graphic fadeScreen;
    public float fadeTime;


    [ContextMenu("Fade In")]
    public void fadeInPlayerHUD()
    {
        fadeScreen.DOFade(1,2);
    }

    [ContextMenu("Fade Out")]
    public void fadeOutPlayerHUD()
    {
        fadeScreen.DOFade(0,2).OnComplete(DisableFade);
    }

    private void DisableFade()
    {
        fadeScreen.enabled = false;
    }
}
