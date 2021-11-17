using System;
using System.Collections;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    private bool isFaded;
    public float duration = 1f;

    public static FadeScreen instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Fade()
    {
        var canvasGroup = GetComponent<CanvasGroup>();

        //Toggle end value depending on faded state
        StartCoroutine(StartFade(canvasGroup, canvasGroup.alpha, isFaded ? 1 : 0));
        
        //Toggle fade
        isFaded = !isFaded;
    }

    private IEnumerator StartFade(CanvasGroup _canvasG, float _start, float _end)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            _canvasG.alpha = Mathf.Lerp(_start, _end, counter / duration);
            yield return null;
        }
    }
}
