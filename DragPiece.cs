using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragPiece : MonoBehaviour
{
    RaycastHit pickedPiece;
    Camera m_Camera;
    GameObject dummyObject;
    RaycastHit dummy;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    void Start(){
        dummy=getDummy();
        pickedPiece=dummy;
    }
    void Update()
    {
        Mouse mouse = Mouse.current;
        Vector3 mousePosition = mouse.position.ReadValue();

        if (mouse.leftButton.wasPressedThisFrame)
        {
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 10)){
                pickedPiece=hit;
            }
        }

        if (mouse.leftButton.isPressed)
        {
            pickedPiece.transform.position = m_Camera.ScreenToWorldPoint(mousePosition)+new Vector3(0,0,10);
        }

        if(mouse.leftButton.wasReleasedThisFrame){
            pickedPiece=dummy;
        }
    }

    RaycastHit getDummy(){
        dummyObject=new GameObject();
        dummyObject.AddComponent<BoxCollider>();
        dummyObject.transform.position=new Vector3(0,0,-5);
        RaycastHit dummyHit;
        Physics.Raycast(new Vector3(0,0,-10),Vector3.forward,out dummyHit);
        return dummyHit;
    }
}