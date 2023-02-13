using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragPiece : MonoBehaviour
{
    Vector3 originalPosition;
    RaycastHit pickedPiece;
    Camera m_Camera;
    GameObject dummyObject;
    RaycastHit dummy;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    void Start()
    {
        dummy = getDummy();
        pickedPiece = dummy;
        originalPosition=Vector3.zero;
    }
    void Update()
    {
        Mouse mouse = Mouse.current;
        Vector3 mousePosition = mouse.position.ReadValue();

        if (mouse.leftButton.wasPressedThisFrame)
        {
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 10))
            {
                //if raycast hits initialize the picked piece and cache the original position of the piece
                pickedPiece = hit;
                originalPosition = pickedPiece.transform.position;
            }
        }

        if (mouse.leftButton.isPressed)
        {
            //if held, drag piece to mouse position
            pickedPiece.transform.position = m_Camera.ScreenToWorldPoint(mousePosition) + new Vector3(0, 0, 10);
        }

        if (mouse.leftButton.wasReleasedThisFrame)
        {
            //if released, snap piece to nearest square else return it to start.
            float x = pickedPiece.transform.position.x;
            float y = pickedPiece.transform.position.y;

            if (Mathf.Abs(x) > 4.0f || Mathf.Abs(y) > 4.0f)
            {
                x = originalPosition.x;
                y = originalPosition.y;
            }
            else
            {
                x = Mathf.Round(x + 3.5f) - 3.5f;
                y = Mathf.Round(y + 3.5f) - 3.5f;
            }

            pickedPiece.transform.position=new Vector3(x,y,0);
            pickedPiece = dummy;
        }
    }

    RaycastHit getDummy()
    {
        dummyObject = new GameObject();
        dummyObject.AddComponent<BoxCollider>();
        dummyObject.transform.position = new Vector3(0, 0, -5);
        RaycastHit dummyHit;
        Physics.Raycast(new Vector3(0, 0, -10), Vector3.forward, out dummyHit);
        return dummyHit;
    }
}