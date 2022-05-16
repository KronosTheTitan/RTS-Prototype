using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 5;
    [SerializeField] private float scrollSpeed = 5;

    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private float panLimitX;
    [SerializeField] private float panLimitY;

    public void Update()
    {
        MoveCamera();
    }
    public void MoveCamera()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            pos -= transform.right * (panSpeed * Time.unscaledDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos += transform.right * (panSpeed * Time.unscaledDeltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            pos += transform.forward * (panSpeed * Time.unscaledDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos -= transform.forward * (panSpeed * Time.unscaledDeltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, -(panSpeed * Time.unscaledDeltaTime));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, panSpeed * Time.unscaledDeltaTime);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.unscaledDeltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimitX, panLimitX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimitY, panLimitY);

        transform.position = pos;
    }
}