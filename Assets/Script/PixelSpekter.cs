using UnityEngine;
using System.Collections;

public class PixelSpekter : MonoBehaviour
{

    public AudioSource miaudio;
    float[] spectrum = new float[256];
    public Renderer miModelo;
    public Shader CubePixel;
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
        miValorR = spectrum[1] + spectrum[2] * PowerR;
        miValorG = spectrum[1] + spectrum[2] * PowerG;
        miValorB = spectrum[1] + spectrum[2] * PowerB;
        rend.material.shader = CubePixel;
        rend.material.SetVector("_CellSize", new Vector4(miValorR, miValorG, miValorB, miValorG));
    }
}
