using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellManager : MonoBehaviour
{
    public Mesh shellMesh;
    public Shader shellShader;

    public bool updateStatics = true;

    [Range(1, 256)]
    public int shellCount = 16;

    [Range(0.0f, 1.0f)]
    public float shellDisplacement = 0.15f;

    [Range(0.00f, 0.5f)]
    public float shellAlphaOffset = 1.0f;

    public Color snowColor;
    public Color darkSnowColor;

    public float alpha;

    [Range(0.0f, 1.0f)]
    public float alphaClipping;

    [Range(-1.0f, 1.0f)]
    public float gradientOffset;

    [Range(0.0f, 1.0f)]
    public float noiseColor;

    [Range(0.0f, 10.0f)]
    public float stepStrength;

    public float snowDensity;

    public float noiseSize;
    public bool useDoubleNoise = false;

    private Material shellMaterial;
    private GameObject[] shells;

    void OnEnable()
    {
        if(shellShader == null)
        {
            shellShader = Shader.Find("CloudLayer");
            Debug.Log("Accediendo a recursos.");
        }
        shellMaterial = new Material(shellShader);

        shells = new GameObject[shellCount + 1];

        for (int i = 0; i < shellCount; ++i)
        {
            shells[i] = new GameObject("Shell " + i.ToString());
            shells[i].AddComponent<MeshFilter>();
            shells[i].AddComponent<MeshRenderer>();

            shells[i].GetComponent<MeshFilter>().mesh = shellMesh;
            shells[i].GetComponent<MeshRenderer>().material = shellMaterial;
            shells[i].transform.SetParent(this.transform, false);

            shells[i].GetComponent<MeshRenderer>().material.SetInt("_ShellCount", shellCount);
            shells[i].GetComponent<MeshRenderer>().material.SetInt("_ShellIndex", i);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_ShellDisplacement", shellDisplacement);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_ShellAlphaOffset", shellAlphaOffset);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_Alpha", alpha);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_AlphaClipping", alphaClipping);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_SnowDensity", snowDensity);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_NoiseSize", noiseSize);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_GradientOffset", gradientOffset);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_NoiseColor", noiseColor);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_UseDoubleNoise", useDoubleNoise? 1 : 0);
            shells[i].GetComponent<MeshRenderer>().material.SetVector("_SnowColor", snowColor);
            shells[i].GetComponent<MeshRenderer>().material.SetVector("_DarkSnowColor", darkSnowColor);
            shells[i].GetComponent<MeshRenderer>().material.SetFloat("_StepStrength", stepStrength);
        }
    }

    private void Update()
    {
        if (updateStatics)
        {
            for (int i = 0; i < shellCount; ++i)
            {
                shells[i].GetComponent<MeshRenderer>().material.SetInt("_ShellCount", shellCount);
                shells[i].GetComponent<MeshRenderer>().material.SetInt("_ShellIndex", i);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_ShellDisplacement", shellDisplacement);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_ShellAlphaOffset", shellAlphaOffset);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_Alpha", alpha);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_AlphaClipping", alphaClipping);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_SnowDensity", snowDensity);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_NoiseSize", noiseSize);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_GradientOffset", gradientOffset);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_NoiseColor", noiseColor);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_UseDoubleNoise", useDoubleNoise ? 1 : 0);
                shells[i].GetComponent<MeshRenderer>().material.SetVector("_SnowColor", snowColor);
                shells[i].GetComponent<MeshRenderer>().material.SetVector("_DarkSnowColor", darkSnowColor);
                shells[i].GetComponent<MeshRenderer>().material.SetFloat("_StepStrength", stepStrength);
            }
        }
    }


    void OnDisable()
    {
        for (int i = 0; i < shells.Length; ++i)
        {
            Destroy(shells[i]);
        }

        shells = null;
    }
}
