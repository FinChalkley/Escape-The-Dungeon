using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public float xSensitivity, ySensitivity;

    public Transform orientation;

    float xRotaion, yRotaion;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //get mouse input
        float xMouse = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float yMouse = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;
        //setting the camera rotation
        yRotaion += xMouse;
        xRotaion -= yMouse;
        xRotaion = Mathf.Clamp(xRotaion, -90f, 90f);
        //rotate camera and orientaion
        transform.rotation = Quaternion.Euler(xRotaion, yRotaion,0);
        orientation.rotation = Quaternion.Euler(0,yRotaion,0);

    }
}
