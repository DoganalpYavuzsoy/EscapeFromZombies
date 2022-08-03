using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;


    float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotation -= mouseY * Time.deltaTime;
        //Debug.Log(xRotation);
        if (xRotation < 80 && xRotation > -50)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
        else
        {
            xRotation += mouseY * Time.deltaTime;
        }
        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);        
    }
}
