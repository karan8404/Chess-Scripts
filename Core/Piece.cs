using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public GameObject instance;
    public Color color;
    public Type type;
    public GameObject[] prefabs;//first white then black.
    
    public Piece(Color color,Type type){
        this.color=color;
        this.type=type;
    }

    public void createInstance(Vector3 location){
        instance=Instantiate(prefabs[((int)type)+((int)color)*6],location,Quaternion.identity);
    }

      public enum Type{
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    public enum Color{
        White,
        Black
    }
}
