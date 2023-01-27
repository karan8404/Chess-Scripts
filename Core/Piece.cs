using System.Collections;
using System.Collections.Generic;

public class Piece
{
    Type type;
    Color color;
    int[2] location;//[x,y][column,row]

    public Piece(Type type,Color color,int[] location){
        this.type=type;
        this.color=color;
        this.location=location;
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

    public Piece whiteKing=new Piece(Type.King,Color.White);
    public Piece whiteQueen=new Piece(Type.Queen,Color.White);
    public Piece whiteRook=new Piece(Type.Rook,Color.White);
    Piece whiteBishop=new Piece(Type.Bishop,Color.White);
    public Piece whiteKnight=new Piece(Type.Knight,Color.White);
    public Piece whitePawn=new Piece(Type.Pawn,Color.White);
    public Piece blackKing=new Piece(Type.King,Color.Black);
    public Piece blackQueen=new Piece(Type.Queen,Color.Black);
    public Piece blackRook=new Piece(Type.Rook,Color.Black);
    public Piece blackBishop=new Piece(Type.Bishop,Color.Black);
    public Piece blackKnight=new Piece(Type.Knight,Color.Black);
    public Piece blackPawn=new Piece(Type.Pawn,Color.Black);
    
}