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

        for(int row=7;row>=0;row--){
            for(int column=0;column<8;column++){
                Instantiate(squares[((int)board.squares[column,row].color)],new Vector3(column-3.5f,row-3.5f,0),Quaternion.identity,boardObjects.transform);
            }
        }
        foreach (Piece pc in board.pieces)
        {
            Instantiate(pieces[((int)pc.type) + ((int)pc.color) * 6], new Vector3(pc.location[0]-3.5f, pc.location[1]-3.5f, 0), Quaternion.identity, pieceObjects.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
