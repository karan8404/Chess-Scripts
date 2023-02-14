using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public GameObject instance;
    public Color color;
    public Type type;
    public bool hasPiece;

    public Piece(){
        hasPiece=false;
    }

    public Piece(Type type,Color color){
        this.type=type;
        this.color=color;
        hasPiece=true;
    }
}
