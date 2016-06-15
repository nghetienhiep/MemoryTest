using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoTweenControllerScript : MonoBehaviour
{
    public static DoTweenControllerScript main;
    public SpriteRenderer shadow;
    public delegate void myCallback();
    void Awake()
    {
        main = this;
    }
    public void SetScaleMaskButton(GameObject g)
    {
        g.transform.DOScale(0, 0.5f);
    }
    public void SetScaleTimer(GameObject g)
    {
        g.transform.DOScale(0, 1f).SetEase(Ease.InBack);
    }
    public void SetAlphaShadow(myCallback mycallback)
    {
        shadow.DOFade(1, 0.5f).OnComplete(() =>
        {
            mycallback();
            shadow.DOFade(0, 0.5f);
        });
    }
}