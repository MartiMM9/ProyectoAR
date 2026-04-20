using UnityEngine;
using UnityEngine.InputSystem;

public class GyroscopeController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private InputAction rotateCameraPC;
    [SerializeField] private float cameraRotationSpeedPC;

    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Quaternion inputGyroscope = Input.gyro.attitude;

            //las coordenadas del giroscopio no son iguales a las de Unity
            cameraTransform.rotation = new Quaternion(inputGyroscope.x, inputGyroscope.y, -inputGyroscope.z, -inputGyroscope.w);

            Quaternion correctionGyro = Quaternion.Euler(90, 0, 0);

            cameraTransform.rotation *= correctionGyro;

            /*float rotationCamera = rotateCameraPC.ReadValue<float>();
            cameraTransform.eulerAngles += new Vector3(0, cameraRotationSpeedPC * rotationCamera, 0);*/
        }
        else
        {
            float rotationCamera = rotateCameraPC.ReadValue<float>();
            cameraTransform.eulerAngles += new Vector3(0, cameraRotationSpeedPC * rotationCamera, 0);
        }
    }
}
