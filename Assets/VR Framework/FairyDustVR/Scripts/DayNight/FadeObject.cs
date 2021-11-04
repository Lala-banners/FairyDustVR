using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    private bool fadeOut, fadeIn;
    public float fadeSpeed;

    private void Awake()
    {
        StartCoroutine(FadeOutObject());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(FadeOutObject());

        if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(FadeInObject());
    }

    private IEnumerator FadeOutObject()
    {
        while (GetComponent<Renderer>().material.color.a > 0)
        {
            Color objectColour = GetComponent<Renderer>().material.color;
            float fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime);

            objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
            GetComponent<Renderer>().material.color = objectColour;
            yield return null;
        }
    }

    private IEnumerator FadeInObject()
    {
        while (GetComponent<Renderer>().material.color.a < 1)
        {
            Color objectColour = GetComponent<Renderer>().material.color;
            float fadeAmount = objectColour.a + (fadeSpeed * Time.deltaTime);

            objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
            GetComponent<Renderer>().material.color = objectColour;
            yield return null;
        }
    }
}
