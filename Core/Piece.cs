using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public GameObject instance;
    public Color color;
    public Type type;
    public bool hasPiece;

    public Piece()
    {
        hasPiece = false;
        color = Color.Empty;
        type = Type.Empty;
    }

    public Vector3 getPosition()
    {
        return instance.transform.position;
    }

    public void setPosition(Vector3 position)
    {
        instance.transform.position = position;
    }

    public Piece(Type type, Color color)
    {
        this.type = type;
        this.color = color;
        hasPiece = true;
    }
}
