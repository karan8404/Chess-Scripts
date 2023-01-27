using System.Collections;
using System.Collections.Generic;

class Square
{
    Color color;
    bool hasPiece;
    Piece piece;
    int[] location;//[x,y][column,row]

    void Square(Color color,int[] location){
        this.color=color;
        this.location=location;
        hasPiece=false;
    }

    void Square(Color color,int[] location,Piece piece){
        this.color=color;
        this.location=location;
        hasPiece=true;
        this.piece=piece;
    }
}