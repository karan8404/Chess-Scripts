using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour
{
    public GameObject squareContainer;
    public GameObject pieceContainer;
    public GameObject[] squarePrefabs;
    public GameObject[] piecePrefabs;
    public GameObject createSquare(Vector3 location,Color color){
        return Instantiate(squarePrefabs[((int)color)],location,Quaternion.identity,squareContainer.transform);
    }

    public GameObject createPiece(Vector3 location, Color color, Type type){
        return Instantiate(piecePrefabs[((int)type)+((int)color)*6],location,Quaternion.identity,pieceContainer.transform);
    }
}
