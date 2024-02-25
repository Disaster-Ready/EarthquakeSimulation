using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class MobileMovementScript : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Transform cameraTransform;

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.F)){
            Vector3 movement = cameraTransform.right * 0 + cameraTransform.forward * 2;
            movement.y = 0f;

            cameraTransform.position += movement * moveSpeed * Time.deltaTime;
        }
        */
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 4)
            {
                Vector3 movement = cameraTransform.right * 0 + cameraTransform.forward * 2;
                movement.y = 0f;

                cameraTransform.position += movement * moveSpeed * Time.deltaTime;
            }
        }
    }
}
