using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
public class JoyStick : MonoBehaviour
{
    public RectTransform imageRectTransform;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
    
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        EnhancedTouchSupport.Disable();

    }
    private void HandleFingerDown(Finger finger)
    {
        imageRectTransform.position = finger.screenPosition;
    }






}
