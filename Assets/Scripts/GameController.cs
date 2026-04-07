using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        #region Input Manager
        
        //Input Manager
        if (Input.touchCount > 0)
        {
            /*
            Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began)//Primer frame en el que un dedo toca la pantalla
            {

            }
            */
            /*
            if (touch.phase == TouchPhase.Moved)//Detecta si el dedo esta en una posicion distinta al frame anterior
            {

            }

            if (touch.phase == TouchPhase.Stationary)//Detecta si el dedo esta en la misma posicion del frame anterior
            {

            }

            if (touch.phase == TouchPhase.Ended)//Primer frame en el que un dedo deja de tocar la pantalla
            {

            }

            if (touch.phase == TouchPhase.Canceled)//Primer frame en el que un dedo deja de tocar la pantalla
            {

            }
            */

            //touch.position = Posicion en pixeles de la pantalla del dedo
        }
        
        #endregion
    }

    //Input System
    public void OnTouch(InputAction.CallbackContext context) 
    {
        if(context.phase == InputActionPhase.Started)
        {
            Vector2 touchPos = playerInput.actions["TouchPosition"].ReadValue<Vector2>();
        }
    }
}
