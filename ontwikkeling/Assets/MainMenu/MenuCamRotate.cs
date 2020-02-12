using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamRotate : MonoBehaviour
{
    public GameObject center;
    public float rotateSpeed = 3;
    public float distance = 20;
    float rotateAxis;
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        rotateAxis += rotateSpeed;
        Vector3 dir = new Vector3(0, 5, -distance);
        Quaternion rot = Quaternion.Euler(0, rotateAxis, 0);
        cam.transform.position = center.transform.position + rot * dir;
        cam.transform.LookAt(center.transform);
    }
}
