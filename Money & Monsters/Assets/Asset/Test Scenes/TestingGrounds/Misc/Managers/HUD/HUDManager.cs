using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public Animator fadeScreen;
    public float fadeTime;


    [ContextMenu("Fade In")]
    void fadeInPlayerHUD()
    {
        fadeScreen.Play("fadeScreen");
    }

    [ContextMenu("Fade Out")]
    void fadeOutPlayerHUD()
    {
        fadeScreen.Play("InvfadeScreen");
    }
}
