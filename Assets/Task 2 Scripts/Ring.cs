using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Ring : MonoBehaviour, IDetectable
{
    [SerializeField] private float duration = 0.5f;

    SpriteRenderer spriteRenderer;
    Coroutine fadeCoroutine;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnDetect()
    {
        if (fadeCoroutine == null)
            fadeCoroutine = StartCoroutine(FadeColorCoroutine());
    }

    private IEnumerator FadeColorCoroutine()
    {
        Color color = spriteRenderer.color;
        float elapsedTime = 0f;
        float percent = 0f;
        while (percent < 1)
        {
            elapsedTime += Time.deltaTime;
            percent = elapsedTime / duration;
            spriteRenderer.color = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, 0f, percent));

            yield return null;
        }
        Destroy(gameObject);
    }
}
