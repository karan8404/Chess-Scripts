using System.Collections;
using System.Collections.Generic;

public class Piece
{
    public Type type;
    public Color color;
    public int[] location = new int[2];//[x,y][column,row]

    public Piece(Type type, Color color, int[] location)
    {
        this.type = type;
        this.color = color;
        this.location = location;
    }

    public Piece(Type type, Color color)
    {
        this.type = type;
        this.color = color;
    }

    public Piece(){}

    public enum Type
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }
}