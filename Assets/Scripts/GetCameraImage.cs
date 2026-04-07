using UnityEngine;
using UnityEngine.UI;

public class GetCameraImage : MonoBehaviour
{
	private WebCamTexture cam;
	[SerializeField] private RawImage background;

	void Start()
	{
		//revisar cámaras del dispositivo
		WebCamDevice[] realCameras = WebCamTexture.devices;

		for(int i = 0; i < realCameras.Length; i++)
		{
			Debug.Log(realCameras[i].name);
			//buscamos la cámara trasera
			if(!realCameras[i].isFrontFacing)
			{
				cam = new WebCamTexture(realCameras[i].name, Screen.width, Screen.height);
			}
		}

		cam.Play();
		background.texture = cam;
	}
}