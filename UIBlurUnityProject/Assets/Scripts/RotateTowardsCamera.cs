using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    private Camera cam;
    
    void Update()
    {
        if (cam == null)
            cam = Camera.main;

        transform.LookAt(cam.transform.position, Vector3.up);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 180, 0);
    }
}
