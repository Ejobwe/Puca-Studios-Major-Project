using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    private CameraEffect camEff;

    public float fadeSpeed;
    public float fadeAmount;
    private float originalOpacity;

    public bool doFade = false;


   // Renderer rend;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        camEff = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraEffect>();
        mat = GetComponent<Renderer>().material;
        originalOpacity = mat.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(doFade)
        {
            FadeNow();
        }
        else
        {
            ResetFade();
        }
    }

    void FadeNow()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        mat.color = smoothColor;
    }

    void ResetFade()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime));
        mat.color = smoothColor;
    }
}
