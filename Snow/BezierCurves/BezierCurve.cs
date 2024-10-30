using UnityEngine;

[ExecuteInEditMode]
public class BezierCurve : MonoBehaviour
{
    // Puntos de control de la curva de Bézier cúbica
    public Transform point0;
    public Transform point1;
    public Transform point2;
    public Transform point3;

    [Range(0, 1)]
    public float t = 0f;

    private void OnDrawGizmos()
    {
        // Dibujar la curva en el editor
        Vector3 previousPoint = point0.position;
        int segments = 20; // Número de segmentos de la curva

        for (int i = 1; i <= segments; i++)
        {
            float parameter = i / (float)segments;
            Vector3 pointOnCurve = CalculateBezierPoint(parameter, point0.position, point1.position, point2.position, point3.position);
            Gizmos.DrawLine(previousPoint, pointOnCurve);
            previousPoint = pointOnCurve;
        }

        // Dibuja un punto en la curva en función del valor t en el Inspector
        Vector3 positionOnCurve = CalculateBezierPoint(t, point0.position, point1.position, point2.position, point3.position);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(positionOnCurve, 0.1f);
    }

    // Método para calcular un punto en la curva de Bézier cúbica
    public Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
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
