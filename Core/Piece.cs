using System.Collections;
using System.Collections.Generic;

class Piece
{
    Type type;
    Color color;

    public Piece(String type, String color)
    {
        if (string.Equals(type, "king", System.StringComparison.OrdinalIgnoreCase))
            this.type = Type.King;
        else if (string.Equals(type, "queen", System.StringComparison.OrdinalIgnoreCase))
            this.type = Type.Queen;
        else if (string.Equals(type, "rook", System.StringComparison.OrdinalIgnoreCase))
            this.type = Type.Rook;
        else if (string.Equals(type, "bishop", System.StringComparison.OrdinalIgnoreCase))
            this.type = Type.Bishop;
        else if (string.Equals(type, "knight", System.StringComparison.OrdinalIgnoreCase))
            this.type = Type.Knight;
        else if (string.Equals(type, "pawn", System.StringComparison.OrdinalIgnoreCase))
            this.type = Type.Pawn;

        if (string.Equals(color, "white", System.StringComparison.OrdinalIgnoreCase))
            this.color = Color.White;
        else if (string.Equals(color, "black", System.StringComparison.OrdinalIgnoreCase))
            this.color = Color.Black;
    }

    public Piece(Type type,Color color){
        this.type=type;
        this.color=color;
    }

    enum Type{
    King,
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn
    }

    enum Color{
    White,
    Black
    }
}