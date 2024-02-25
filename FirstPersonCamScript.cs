using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamScript : MonoBehaviour
{
    public float sensitivity = 35f;
    public float clampAngle = 80f;

    private float rotX = 0f;
    private float rotY = 0f;
    public float speed = 10f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotX -= mouseY;
        rotY += mouseX;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0f);
        transform.rotation = localRotation;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveX + transform.forward * moveZ;
        movement.y = 0f;

        transform.position += movement * speed * Time.deltaTime;
    }
    public Transform cameraTransform;
    public void TranslateCamera() {
        Vector3 movement = cameraTransform.forward * speed * Time.deltaTime;
        cameraTransform.Translate(movement);
    }
}