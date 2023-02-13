using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Square[,] squares;
    public Vector3 location;
    public string fen;

    public Board(Vector3 location, string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR")
    {
        this.location = location;
        this.fen = fen;

        for (int row = 0; row < 8; row++)
        {
            //creates the squares.
            for (int column = 0; column < 8; column++)
            {
                Square.Color color = (column + row) % 2 == 0 ? Square.Color.Black : Square.Color.White;
                Vector3 position = new Vector3(location.x + column - 3.5f, location.y + row - 3.5f, location.z);

                squares[column, row] = new Square(position, color);
                squares[column, row].createInstance();
            }
        }
    }
}
