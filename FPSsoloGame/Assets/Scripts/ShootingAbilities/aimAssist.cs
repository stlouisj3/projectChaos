using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimAssist : MonoBehaviour
{
    private float xSens;
    private float ySens;

    [SerializeField]
    private float percentDown = 0f;

    [SerializeField]
    private GameObject cam;

    public PlayerSaveData data;

    private Ray ray;
    private RaycastHit hit;


    private void OnEnable()
    {
        storeSens();
    }

    private void storeSens()
    {
        xSens = data.xSens;
        ySens = data.ySens;
    }
    void Update()
    {
     
        ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                data.xSens = xSens * percentDown;
                data.ySens = ySens * percentDown;
            }
            else
            {
                data.xSens = xSens;
                data.ySens = ySens;
            }
            
        }
    }
}
