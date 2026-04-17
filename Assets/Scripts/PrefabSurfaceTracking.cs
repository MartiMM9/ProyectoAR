using UnityEngine;

public class PrefabSurfaceTracking : MonoBehaviour
{
    private void Start()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
