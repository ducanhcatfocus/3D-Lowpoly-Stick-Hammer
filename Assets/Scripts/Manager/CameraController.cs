using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public Transform cameraStartTargetPosition;
    public Transform cameraSkinTargetPosition;
    public Camera mainCam;
    Vector3 defauntPosition;
  

    float moveSpeed = 2f;

    private void Start()
    {
        mainCam = Camera.main;
        defauntPosition = mainCam.transform.position;
    }

    public void MoveCameraStart()
    {
        StartCoroutine(MoveCamera(cameraStartTargetPosition.position, 40f));
    }

    public void MoveCameraSkin()
    {
        StartCoroutine(MoveCamera(cameraSkinTargetPosition.position, 20f));
    }

    public void MoveCameraSkinBack()
    {
        StartCoroutine(MoveCamera(defauntPosition, 20f));
    }

    IEnumerator MoveCamera(Vector3 destination, float rotationX)
    {

        Vector3 startPosition = mainCam.transform.position;
        Quaternion startRotation = mainCam.transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {

            mainCam.transform.position = Vector3.Lerp(startPosition, destination, elapsedTime);
            mainCam.transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(rotationX, 0, 0), elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;

            yield return null;
        }


        mainCam.transform.position = destination;
    }
}
