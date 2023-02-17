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
            if(!(pickedPiece.hasPiece)){
                pickedPiece=dummy;
            }
            Board.GetComponent<Game>().pieces[Mathf.RoundToInt(mousePosition.x + 3.5f), Mathf.RoundToInt(mousePosition.y + 3.5f)]=new Piece();
            originalPosition = pickedPiece.instance.transform.position;
        }

        if (mouse.leftButton.isPressed)
        {
            //if held, move piece to current mouse location.
            pickedPiece.instance.transform.position = mousePosition + new Vector3(0, 0, 10);
        }

        if (mouse.leftButton.wasReleasedThisFrame)
        {
            //if released, snap to place or to start and alter pieces array.
            float x = pickedPiece.instance.transform.position.x;
            float y = pickedPiece.instance.transform.position.y;
            
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
            Vector2Int original=new Vector2Int(Mathf.RoundToInt(originalPosition.x),Mathf.RoundToInt(originalPosition.y));
            Vector2Int finalPosition=new Vector2Int(Mathf.RoundToInt(x),Mathf.RoundToInt(y));

            Board.GetComponent<Game>().placePiece(pickedPiece,original,finalPosition);
            pickedPiece=dummy;
        }
    }

    Piece getDummy()
    {
        Piece dummy = new Piece();
        dummy.instance = new GameObject();
        dummy.instance.transform.position = new Vector3(5, 0, 0);

        return dummy;
    }
}
