using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed = 10f;
    public float rotationSpeed = 10f;
    public float zoom = 0f;

    public Camera camera;

    private void Start()
    {
        camera = this.camera;
    }

    void Update()
    {
        float translateV = Input.GetAxis("Vertical") * speed;
        float translateH = Input.GetAxis("Horizontal") * rotationSpeed;
        zoom = Input.GetAxis("Mouse ScrollWheel");

        translateV *= Time.deltaTime;
        translateH *= Time.deltaTime;
        

        transform.Translate(0, 0, translateV, Space.Self);
        transform.Translate(translateH, 0, 0, Space.Self);

        if (zoom > 0f)
        {
            camera.orthographicSize -= zoom;
            transform.Translate(0, 0, zoom);
        }
        else if (zoom < 0f)
        {
            camera.orthographicSize -= zoom;
            transform.Translate(0, 0, zoom);
        }
    }
}
