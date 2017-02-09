using UnityEngine;
using System.Collections;

public class GetSpekterMaskSample : MonoBehaviour
{

    public AudioSource miaudio;
    float[] spectrum = new float[256];
    public Renderer miModelo;
    public Shader CubeGlitch;
    private float miValorR;
    private float miValorG;
    private float miValorB;
    public float PowerR = 5;
    public float PowerG = 2.5f;
    public float PowerB = 0;

    void Update()
    {
        miaudio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        Renderer rend = miModelo;
        rend.material.shader = CubeGlitch;
        rend.material.SetFloat("_RColor", miValorR);
        miValorR = spectrum[1] + spectrum[2] * PowerR;
        rend.material.SetFloat("_GColor", miValorG);
        miValorG = spectrum[1] + spectrum[2] * PowerG;
        rend.material.SetFloat("_BColor", miValorB);
        miValorB = spectrum[1] + spectrum[2] * PowerB;
    }
}
