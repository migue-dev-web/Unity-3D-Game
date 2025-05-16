using UnityEngine;

public class SettingsOptimizer : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
        OptimizeForMobile();
#endif
    }

    void OptimizeForMobile()
    {
        Debug.Log("Optimizando configuración para móviles...");

        // Limita la tasa de frames a 60
        Application.targetFrameRate = 60;

        // Reduce la calidad gráfica (puedes ajustar esto según necesites)
        QualitySettings.vSyncCount = 0; // Desactiva VSync
        QualitySettings.antiAliasing = 0; // Desactiva Anti-Aliasing
        QualitySettings.shadows = ShadowQuality.Disable;
        QualitySettings.shadowResolution = ShadowResolution.Low;
        QualitySettings.globalTextureMipmapLimit = 1; // Reduce calidad de texturas (0 = full, 1 = mitad)
        QualitySettings.pixelLightCount = 0; // Luces por píxel = 0

        // Opcional: baja resolución de render (especialmente útil si usas UI Canvas pesados)
        if (UnityEngine.Rendering.Universal.UniversalRenderPipeline.asset != null)
        {
            UnityEngine.Rendering.Universal.UniversalRenderPipeline.asset.renderScale = 0.75f;
        }

        // Desactiva Motion Blur si existe
        var motionBlur = FindAnyObjectByType<UnityEngine.Rendering.Volume>();
        if (motionBlur != null)
        {
            motionBlur.enabled = false;
        }

        // Desactiva postprocesado en cámaras si es necesario
        foreach (var cam in Camera.allCameras)
        {
            var postFX = cam.GetComponent<UnityEngine.Rendering.Universal.UniversalAdditionalCameraData>();
            if (postFX != null)
            {
                postFX.renderPostProcessing = false;
            }
        }

        Debug.Log("Optimización de móviles completada.");
    }
}
