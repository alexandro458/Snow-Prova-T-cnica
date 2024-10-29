using UnityEngine;
using UnityEngine.VFX;

public class SnowStepController : MonoBehaviour
{
    public VisualEffect vfx; // Asigna el VFX que quieres reiniciar desde el Inspector

    void Update()
    {
        // Detecta si se ha presionado la tecla Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetVFX();
        }
    }

    // M�todo que reinicia el VFX
    public void ResetVFX()
    {
        if (vfx != null)
        {
            vfx.Reinit(); // Reinicia el VFX, eliminando todas las part�culas activas
            Debug.Log("Visual Effect reiniciado.");
        }
        else
        {
            Debug.LogWarning("No se ha asignado ning�n Visual Effect.");
        }
    }
}
