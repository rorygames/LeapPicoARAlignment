using UnityEngine;
using Unity.XR.PXR;

public class PicoCameraSetup : MonoBehaviour
{

    private Camera _camera;

    private void Start()
    {

        _camera = GetComponent<Camera>();
#if UNITY_EDITOR
        _camera.clearFlags = CameraClearFlags.Skybox;
#elif UNITY_ANDROID
        _camera.clearFlags = CameraClearFlags.SolidColor;
        _camera.backgroundColor = Color.clear;
#endif
        PXR_Boundary.EnableSeeThroughManual(true);
    }

    // Re-enable seethrough after the app resumes
    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            PXR_Boundary.EnableSeeThroughManual(true);
        }
    }
}