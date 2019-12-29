using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject BG;
    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -30.0f);
        BG.transform.position = new Vector3(transform.position.x, transform.position.y, 3.0f);
    }
}
