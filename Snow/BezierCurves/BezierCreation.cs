using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BezierCreation : MonoBehaviour
{
    public Transform point0; // Punto inicial de la curva
    public Transform point1; // Primer punto de control
    public Transform point2; // Segundo punto de control
    public Transform point3; // Punto final de la curva

    [Range(0, 1)]
    public float t = 0f; // Valor para probar posiciones en la curva

    public int segments = 20; // Número de segmentos para dividir la curva
    public float lineWidth = 0.2f; // Grosor de la línea

    private LineRenderer lineRenderer;

    private void OnEnable()
    {
        // Configura el LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1; // Número de puntos en la línea
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }
    void Update()
    {
        // Actualiza los puntos en el LineRenderer para dibujar la curva
        for (int i = 0; i <= segments; i++)
        {
            float parameter = i / (float)segments;
            Vector3 pointOnCurve = CalculateBezierPoint(parameter, point0.position, point1.position, point2.position, point3.position);
            lineRenderer.SetPosition(i, pointOnCurve);
        }
    }

    // Método para calcular un punto en la curva de Bézier cúbica
    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point = uuu * p0;      // (1 - t)^3 * P0
        point += 3 * uu * t * p1;      // 3 * (1 - t)^2 * t * P1
        point += 3 * u * tt * p2;      // 3 * (1 - t) * t^2 * P2
        point += ttt * p3;             // t^3 * P3

        return point;
    }
}
