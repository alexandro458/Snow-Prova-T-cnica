using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BezierCreation : MonoBehaviour
{
    public Transform point0;
    public Transform point1;
    public Transform point2;
    public Transform point3;

    [Range(0, 1)]
    public float t = 0f;

    public int segments = 20;
    public float lineWidth = 0.2f;

    private LineRenderer lineRenderer;

    private void OnEnable()
    {
        // Configura el LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }
    void Update()
    {
        for (int i = 0; i <= segments; i++)
        {
            float parameter = i / (float)segments;
            Vector3 pointOnCurve = CalculateBezierPoint(parameter, point0.position, point1.position, point2.position, point3.position);
            lineRenderer.SetPosition(i, pointOnCurve);
        }
    }

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
