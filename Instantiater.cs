using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour
{
    public GameObject squareContainer;
    public GameObject pieceContainer;
    public GameObject[] squarePrefabs;
    public GameObject[] piecePrefabs;
    public GameObject circlePrefab;
    public GameObject circleParent;
    public GameObject createSquare(Vector3 location, Color color)
    {
        return Instantiate(squarePrefabs[((int)color)], location, Quaternion.identity, squareContainer.transform);
    }

    public GameObject createPiece(Piece piece, Vector3 location)
    {
        Type type = piece.type;
        Color color = piece.color;
        return piece.instance = Instantiate(piecePrefabs[((int)type) + ((int)color) * 6], location, Quaternion.identity, pieceContainer.transform);
    }

    public void destroyPiece(Piece piece)
    {
        Destroy(piece.instance);
        piece.hasPiece = false;
    }
    List<GameObject> circleIndicators = new List<GameObject>();
    public void showMoves(List<Vector2Int> moves)
    {
        foreach (Vector2Int move in moves)
        {
            circleIndicators.Add(Instantiate(circlePrefab, move - Vector2.one * 3.5f, Quaternion.identity));
        }
    }
    public void showMove(Vector2Int move){
        circleIndicators.Add(Instantiate(circlePrefab, move - Vector2.one * 3.5f, Quaternion.identity));
    }
    public void removeMoves()
    {
        foreach (GameObject indicator in circleIndicators)
        {
            Destroy(indicator);
        }
        circleIndicators.Clear();
    }
}
