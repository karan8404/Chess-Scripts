using System.Collections;
using System.Collections.Generic;

class Square
{
    Color color;
    bool hasPiece;
    Piece piece;

    Square(Color color){
        this.color=color;
        hasPiece=false;
    }

    Square(Color c,Piece p){
        color=c;
        piece=p;
    }
}