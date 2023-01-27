using System.Collections;
using System.Collections.Generic;

public class Square
{
    public Color color;
    public bool hasPiece;
    public Piece piece;
    public int[] location;

    public Square(int[] location, Color color = Color.White)
    {
        this.color = color;
        hasPiece = false;
        this.location = location;
    }

    public Square(Piece p, int[] location, Color c = Color.White)
    {
        color = c;
        hasPiece = true;
        piece = p;
        this.location = location;
    }
}