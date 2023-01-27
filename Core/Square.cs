using System.Collections;
using System.Collections.Generic;

public class Square
{
    Color color;
    bool hasPiece;
    Piece piece;

    Square(Color color){
        this.color=color;
        hasPiece=false;
    }

    Square(Color c=Color.White,Piece p){
        color=c;
        hasPiece=true;
        piece=p;
    }

    Square(){
        hasPiece=false;
    }
}