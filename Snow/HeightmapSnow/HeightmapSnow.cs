using UnityEngine;

public class HeightmapSnow : MonoBehaviour
{
    public float _NoiseSize = 100f;                   // Aprox 100
    [Range(0f, 4f)] public float _SnowHeight = 0f;    // Rango 0 a 4
    [Range(0f, 1f)] public float _StepStrength = 0.5f;// Rango 0 a 1
    [Range(0f, 1f)] public float _NoiseColor = 0.5f;  // Rango 0 a 1
    public float _TexScale = 30f;                     // Aprox 30

    public Shader snowShader; // Asigna el shader desde el Inspector
    private Material material; // Material creado a partir del shader
    private MeshRenderer mesh; // MeshRenderer para aplicar el material

    void OnEnable()
    {
        // Crea un nuevo material basado en el shader y lo asigna al MeshRenderer
        material = new Material(snowShader);
        mesh = GetComponent<MeshRenderer>();
        mesh.material = material;
    }

    void Update()
    {
        if (material != null)
        {
            // Asigna las variables del shader en cada frame
            material.SetFloat("_NoiseSize", _NoiseSize);
            material.SetFloat("_SnowHeight", _SnowHeight);
            material.SetFloat("_StepStrength", _StepStrength);
            material.SetFloat("_NoiseColor", _NoiseColor);
            material.SetFloat("_TexScale", _TexScale);
        }
    }

    void OnDisable()
    {
        // Carga un material predeterminado cuando se desactiva el objeto
        Material loadedMaterial = Resources.Load<Material>("BasicMaterial");

        if (loadedMaterial != null)
        {
            GetComponent<MeshRenderer>().material = loadedMaterial;
        }
    }
}
