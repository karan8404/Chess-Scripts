using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[,] squares;
    public Piece[,] pieces;
    void Start()
    {
        squares = new GameObject[8, 8];
        pieces = new Piece[8, 8];

        createGame();

    }

    public void createGame(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR")
    {
        //placing squares

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                Vector3 location = new Vector3(column - 3.5f, row - 3.5f, 0);
                Color color = (column + row) % 2 == 0 ? Color.Black : Color.White;
                squares[column, row] = GetComponent<Instantiater>().createSquare(location, color);
            }
        }

        //placing pieces according to fen
        GetComponent<FenUtility>().createBoard(fen,out pieces);
        
        
    }
}
