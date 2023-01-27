using System.Collections;
using System.Collections.Generic;

public class Piece
{
    Type type;
    Color color;
    public int[] location=new int[2];//[x,y][column,row]

    public Piece(Type type,Color color,int[] location){
        this.type=type;
        this.color=color;
        this.location=location;
    }

    public Piece(Type type,Color color){
        this.type=type;
        this.color=color;
    }

    public enum Type{
    King,
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn
    }

    public static Piece whiteKing=new Piece(Type.King,Color.White);
    public static Piece whiteQueen=new Piece(Type.Queen,Color.White);
    public static Piece whiteRook=new Piece(Type.Rook,Color.White);
    public static Piece whiteBishop=new Piece(Type.Bishop,Color.White);
    public static Piece whiteKnight=new Piece(Type.Knight,Color.White);
    public static Piece whitePawn=new Piece(Type.Pawn,Color.White);
    public static Piece blackKing=new Piece(Type.King,Color.Black);
    public static Piece blackQueen=new Piece(Type.Queen,Color.Black);
    public static Piece blackRook=new Piece(Type.Rook,Color.Black);
    public static Piece blackBishop=new Piece(Type.Bishop,Color.Black);
    public static Piece blackKnight=new Piece(Type.Knight,Color.Black);
    public static Piece blackPawn=new Piece(Type.Pawn,Color.Black);
    
}