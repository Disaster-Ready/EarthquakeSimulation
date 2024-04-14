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
        if (transform.position.z > 480) {
            transform.position = new Vector3(transform.position.x, transform.position.y,480f); 
        }
        if (transform.position.z < 385) {
            transform.position = new Vector3(transform.position.x, transform.position.y,385f); 
        }
        if (transform.position.x < 255) {
            transform.position = new Vector3(255f, transform.position.y,transform.position.z);  
        }
        if (transform.position.x > 380) {
            transform.position = new Vector3(380f, transform.position.y,transform.position.z);  
        }
    }
    public Transform cameraTransform;
    public void TranslateCamera() {
        Vector3 movement = cameraTransform.forward * speed * Time.deltaTime;
        cameraTransform.Translate(movement);
    }
}
