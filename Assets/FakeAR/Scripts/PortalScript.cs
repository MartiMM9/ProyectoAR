using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private void Start()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles += new Vector3(-90, 0, 0);
    }

    public void DestroyPortal()
    {
        Destroy(gameObject);
    }
}
