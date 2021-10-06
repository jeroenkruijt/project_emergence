using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{

    public float mouseSensitivity = 1000f;

    public Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
		//locks the cursor and doesnt allow to go higher than the set highed in the xRotation value
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //get the inputs of the mouse x and y axis times the senitivity you want time time.deltatime(to make it not depended on the framerate)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		//setting a limit on how high and how low you can look(-90f, 90f) makes it 90 degrees up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		//Makes the camera and the body of player rotate but not on the y axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

	void look(){
	}
}
