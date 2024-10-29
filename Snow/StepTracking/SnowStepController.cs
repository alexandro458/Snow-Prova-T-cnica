using UnityEngine;
using UnityEngine.VFX;

public class SnowStepController : MonoBehaviour
{
    public VisualEffect vfx; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetVFX();
        }
    }

    public void ResetVFX()
    {
        if (vfx != null)
        {
            vfx.Reinit();
            Debug.Log("Visual Effect reiniciado.");
        }
        else
        {
            Debug.LogWarning("No se ha asignado ningún Visual Effect.");
        }
    }
}
