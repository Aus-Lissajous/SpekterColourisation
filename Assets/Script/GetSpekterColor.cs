using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetSpekterColor : MonoBehaviour
{

    private AudioSource Audio;
    float[] spectrum = new float[256];
    private Renderer myModel;
    private float RGBValue;

    public Color SpectrumColor;
    public Color SpectrumColor2;
    public Color SpectrumColor3;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        myModel = GetComponent<Renderer>();
    }

    void Update()
    {
        Audio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        Renderer rend = myModel;
        RGBValue = spectrum[1] * 10000;

        if (RGBValue <= 100)
        {
            rend.material.color = SpectrumColor;
        }
        else if (RGBValue >= 101 && RGBValue <= 251)
        {
            rend.material.color = SpectrumColor2;
        }
        else if (RGBValue >= 252)
        {
            rend.material.color = SpectrumColor3;
        }
    }
}
