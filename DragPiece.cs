using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//use input system package

public class DragPiece : MonoBehaviour
{
    Camera mainCam;
    void Awake()
    {
        mainCam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mPos = Input.mousePosition;
            Ray ray=mainCam.ScreenPointToRay(mPos);
            if(Physics.Raycast(ray,out RaycastHit hit)){
                
            }
        }
    }
}
