using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public GameObject[] squares;
    public GameObject[] pieces;//first white then black pieces.
    public GameObject boardObjects;
    public GameObject pieceObjects;
    // Start is called before the first frame update
    void Start()
    {
        Board board = new Board();
        board.startGame();

        foreach (Square sq in board.squares)
        {
            Instantiate(squares[((int)sq.color)], new Vector3(sq.location[0], sq.location[1], 0), Quaternion.identity, boardObjects.transform);
        }

        foreach (Piece pc in board.pieces)
        {
            Instantiate(pieces[((int)pc.type) + ((int)pc.color) * 6], new Vector3(pc.location[0], pc.location[1], 0), Quaternion.identity, pieceObjects.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
