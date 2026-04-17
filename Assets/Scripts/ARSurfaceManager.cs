using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class ARSurfaceManager : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject prefab;
    private PlayerInput playerInput;
    [SerializeField] private GameObject canvasText;
    private bool planeView = true;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.GetComponent<ARPlaneMeshVisualizer>().enabled = planeView;
        }
    }

    public void TouchScreen(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Vector2 touchPos = playerInput.actions["TouchPosition"].ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
    }

    public void TogglePlanesButton()
    {
        canvasText.SetActive(false);
        planeView = !planeView;
    }
}
