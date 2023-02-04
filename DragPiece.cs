using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragPiece : MonoBehaviour
{
    Camera m_Camera;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 50))
            {
                Debug.Log(hit.point);
                hit.transform.localScale = hit.transform.localScale * 1.2f;
            }
        }
    }
}