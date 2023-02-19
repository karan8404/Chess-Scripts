using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragPiece : MonoBehaviour
{
    public GameObject Board;
    Vector3 originalPosition;
    Piece pickedPiece;
    Camera mainCam;
    Piece dummy;

    void Awake()
    {
        mainCam = Camera.main;
    }

    void Start()
    {
        dummy = getDummy();
        pickedPiece = dummy;
        originalPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;
        Vector3 mousePosition = mouse.position.ReadValue();
        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);

        if (mouse.leftButton.wasPressedThisFrame && Mathf.Abs(mousePosition.x) < 4.0f && Mathf.Abs(mousePosition.y) < 4.0f)
        {
            pickedPiece = Board.GetComponent<Game>().pieces[Mathf.RoundToInt(mousePosition.x + 3.5f), Mathf.RoundToInt(mousePosition.y + 3.5f)];
            if (!(pickedPiece.hasPiece))
            {
                pickedPiece = dummy;
            }
            Board.GetComponent<Game>().pieces[Mathf.RoundToInt(mousePosition.x + 3.5f), Mathf.RoundToInt(mousePosition.y + 3.5f)] = new Piece();
            originalPosition = pickedPiece.getPosition();
        }

        if (mouse.leftButton.isPressed)
        {
            //if held, move piece to current mouse location.
            pickedPiece.setPosition(mousePosition + new Vector3(0, 0, 10));
        }

        if (mouse.leftButton.wasReleasedThisFrame)
        {
            if (pickedPiece == dummy)
            {
                pickedPiece.setPosition(Vector3.right * 5);
                return;
            }
            //if released, snap to place or to start and alter pieces array.
            float x = pickedPiece.getPosition().x;
            float y = pickedPiece.getPosition().y;

            Vector2 finalPosition = new Vector2(x, y);

            Board.GetComponent<Game>().placePiece(pickedPiece, originalPosition, finalPosition);
            pickedPiece = dummy;
        }
    }

    Piece getDummy()
    {
        Piece dummy = new Piece();
        dummy.instance = new GameObject();
        dummy.setPosition(Vector3.right * 5);

        return dummy;
    }
}
