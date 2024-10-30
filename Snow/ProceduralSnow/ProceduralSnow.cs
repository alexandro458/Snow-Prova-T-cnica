using UnityEngine;

public class ProceduralSnow : MonoBehaviour
{
    public float _NoiseSize = 0.5f;
    [Range(0f, 1f)] public float _StepStrength = 0.5f;
    [Range(0f, 1f)] public float _GroundSmoothness = 0.5f;
    [Range(0f, 1f)] public float _SnowDensity = 0.5f;

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
            mesh.material.SetFloat("_NoiseSize", _NoiseSize);
            mesh.material.SetFloat("_StepStrength", _StepStrength);
            mesh.material.SetFloat("_GroundSmoothness", _GroundSmoothness);
            mesh.material.SetFloat("_SnowDensity", _SnowDensity);
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
