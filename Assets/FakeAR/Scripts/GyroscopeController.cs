using UnityEngine;
using UnityEngine.InputSystem;

public class GyroscopeController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private InputAction moveCameraPC;
    [SerializeField] private float camRotationSpeedPC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        moveCameraPC.Enable();
    }

    private void OnDisable()
    {
        moveCameraPC.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Quaternion inputGyroscope = Input.gyro.attitude;

            //las coordenadas del giroscopio no son iguales a las de Unity
            cameraTransform.rotation = new Quaternion(inputGyroscope.x, inputGyroscope.y, -inputGyroscope.z, -inputGyroscope.w);

            Quaternion correctionGyro = Quaternion.Euler(90, 0, 0);

            cameraTransform.rotation *= correctionGyro;
        }
        else
        {
            float camRotationPC = moveCameraPC.ReadValue<float>();
            cameraTransform.eulerAngles += new Vector3(0, camRotationPC * camRotationSpeedPC, 0);
        }
    }
}
