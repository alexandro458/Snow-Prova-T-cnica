using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Camera))]
public class SnowTracksCameraURP : MonoBehaviour
{
    public RenderTexture huellasRenderTexture;  // Render Texture principal para acumular las huellas
    public Material drawMaterial;               // Material que dibuja las huellas

    private Camera huellaCamera;
    private CommandBuffer commandBuffer;
    private Mesh quadMesh;

    void Start()
    {
        // Configura la cámara para que use la Render Texture
        huellaCamera = GetComponent<Camera>();
        huellaCamera.targetTexture = huellasRenderTexture;

        // Crear y configurar el Command Buffer
        commandBuffer = new CommandBuffer();
        commandBuffer.name = "Acumular Huellas";

        // Añade el command buffer en el evento de renderizado de la cámara
        huellaCamera.AddCommandBuffer(CameraEvent.AfterEverything, commandBuffer);

        // Genera el Mesh de tipo Quad
        quadMesh = GenerateQuad();

        // Asegúrate de que la Render Texture esté asignada y el material para dibujar huellas esté configurado
        if (huellasRenderTexture == null || drawMaterial == null)
        {
            Debug.LogError("Render Texture o material de dibujo de huellas no asignados. Revisa el Inspector.");
        }
    }

    void LateUpdate()
    {
        // Limpia el Command Buffer para este frame
        commandBuffer.Clear();

        // Configura el material y dibuja en la Render Texture sin limpiar
        commandBuffer.SetRenderTarget(huellasRenderTexture);
        commandBuffer.DrawMesh(quadMesh, Matrix4x4.identity, drawMaterial);
    }

    // Método para limpiar la Render Texture manualmente
    public void ClearTracks()
    {
        // Limpia la textura principal
        Graphics.SetRenderTarget(huellasRenderTexture);
        GL.Clear(true, true, Color.clear);
        Graphics.SetRenderTarget(null);
    }

    void OnDestroy()
    {
        // Elimina el Command Buffer al destruir el componente
        if (commandBuffer != null)
        {
            huellaCamera.RemoveCommandBuffer(CameraEvent.AfterEverything, commandBuffer);
            commandBuffer.Release();
        }
    }

    // Método para generar un Mesh de tipo Quad
    private Mesh GenerateQuad()
    {
        Mesh mesh = new Mesh();

        // Define los vértices del Quad
        mesh.vertices = new Vector3[]
        {
            new Vector3(-1, -1, 0),
            new Vector3(1, -1, 0),
            new Vector3(-1, 1, 0),
            new Vector3(1, 1, 0)
        };

        // Define los triángulos del Quad
        mesh.triangles = new int[]
        {
            0, 2, 1,
            2, 3, 1
        };

        // Define las coordenadas UV del Quad
        mesh.uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        mesh.RecalculateNormals();
        return mesh;
    }
}
