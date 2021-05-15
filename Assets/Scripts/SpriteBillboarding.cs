using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteBillboarding : MonoBehaviour
{
    private Camera cam;

    private void Start() 
    {
        cam = Camera.main;    
    }

    private void LateUpdate() 
    {
        AlignCam();
    }

    private void AlignCam()
    {
        if (cam == null)
            cam = Camera.main;    
        transform.LookAt(cam.transform);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    private void OnValidate() 
    {
        AlignCam();
    }
}
