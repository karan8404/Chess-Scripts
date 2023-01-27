using System.Collections;
using System.Collections.Generic;

public class Square
{
    Color color;
    bool hasPiece;
    Piece piece;

    public Square(Color color)
    {
        this.color = color;
        hasPiece = false;
    }

    public Square(Piece p, Color c = Color.White)
    {
        color = c;
        hasPiece = true;
        piece = p;
    }

    public Square()
    {
        hasPiece = false;
    }
}