using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : ScriptableObject
{
    public GameObject squareContainer;
    private Vector3 location;
    public GameObject instance;
    private Color color;
    private bool hasPiece;
    private Piece piece;
    public static GameObject[] prefabs;//white then black


    public Square(Vector3 location, Color color)
    {
        this.location = location;
        this.color = color;
        hasPiece = false;
    }

    public void createInstance()
    {
        instance = Instantiate(prefabs[((int)color)], location, Quaternion.identity,squareContainer.transform);
    }

    public void placePiece(Piece piece)
    {
        hasPiece = true;
        this.piece = piece;
        this.piece.createInstance(location);
    }

    public void removePiece()
    {
        hasPiece = false;
        this.piece = null;
        Destroy(this.piece.instance);
        this.piece.instance = null;
    }

    public enum Color
    {
        White,
        Black
    }
}
