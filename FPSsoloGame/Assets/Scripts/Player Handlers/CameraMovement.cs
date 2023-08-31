using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPos;
    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = cameraPos.position;
    }
}
