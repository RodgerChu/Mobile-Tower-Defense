using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    public Transform cameraHandlePoint;
    public float cameraMoveSpeed = 0.2f;

    private Vector3 lastTouchPosition;

    private void Start()
    {
        lastTouchPosition = Vector2.zero;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //var touch = Input.GetTouch(0);
            if (lastTouchPosition != Vector3.zero)
            {
                var touchDelta = Input.mousePosition - lastTouchPosition;

                if (touchDelta != Vector3.zero)
                {
                    touchDelta *= cameraMoveSpeed;
                    cameraHandlePoint.Translate(new Vector3(-touchDelta.x, 0, -touchDelta.y));
                }
            }

            lastTouchPosition = Input.mousePosition;
        }
        else if (lastTouchPosition != Vector3.zero)
        {
            lastTouchPosition = Vector3.zero;
        }
    }
}
