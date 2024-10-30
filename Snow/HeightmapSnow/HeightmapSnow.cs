using UnityEngine;

public class HeightmapSnow : MonoBehaviour
{
    public float _NoiseSize = 100f;                   
    [Range(0f, 4f)] public float _SnowHeight = 0f;    
    [Range(0f, 1f)] public float _StepStrength = 0.5f;
    [Range(0f, 1f)] public float _NoiseColor = 0.5f; 
    public float _TexScale = 30f;                    

    public Shader snowShader; 
    private Material material; 
    private MeshRenderer mesh; 

    void OnEnable()
    {
        material = new Material(snowShader);
        mesh = GetComponent<MeshRenderer>();
        mesh.material = material;
    }

    void Update()
    {
        if (material != null)
        {
            material.SetFloat("_NoiseSize", _NoiseSize);
            material.SetFloat("_SnowHeight", _SnowHeight);
            material.SetFloat("_StepStrength", _StepStrength);
            material.SetFloat("_NoiseColor", _NoiseColor);
            material.SetFloat("_TexScale", _TexScale);
        }
    }

    void OnDisable()
    {
        Material loadedMaterial = Resources.Load<Material>("BasicMaterial");

        if (loadedMaterial != null)
        {
            GetComponent<MeshRenderer>().material = loadedMaterial;
        }
    }
}
