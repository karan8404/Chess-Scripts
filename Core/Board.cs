using System.Collections;
using System.Collections.Generic;

class Board{
    public Square squares=new Square[8][8];
    public Piece pieces=new Piece[32];

    public Square squareAt(int[] location){
        return squares[location[0]][location[1]];
    }

    public Piece pieceAt(int[] location){
        for(int i=0;i<pieces.Length;i++){
            if(pieces[i].location[0]==location[0] && pieces[i].location[1]==location[1]);
        }
    }
}