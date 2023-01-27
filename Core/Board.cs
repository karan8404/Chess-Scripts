using System.Collections;
using System.Collections.Generic;

public class Board{
    public Square squares=new Square[8][8];
    public ArrayList<Piece> pieces; 

    public Square squareAt(int[] location){
        return squares[location[0]][location[1]];
    }

    public Piece pieceAt(int[] location){
        for(int i=0;i<pieces.Count;i++){
            if(pieces[i].location[0]==location[0] && pieces[i].location[1]==location[1]);
        }
    }

    public void startGame(){
        this=FenUtility.createBoard(FenUtility.startingPosition);
    }
}