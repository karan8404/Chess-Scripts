using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject boardTiles;
    public GameObject pieces;
    public GameObject whiteSquare;
    public GameObject blackSquare;
    public GameObject[] whitePieces;
    public GameObject[] blackPieces;
    // Start is called before the first frame update
    void Start()
    {
        CreateBoard();
        PlacePieces();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                if ((row + column) % 2 == 0)
                    Instantiate(blackSquare, new Vector3(column - 3.5f, row - 3.5f, 0), Quaternion.identity, boardTiles.transform);
                else
                    Instantiate(whiteSquare, new Vector3(column - 3.5f, row - 3.5f, 0), Quaternion.identity, boardTiles.transform);
            }

        }
    }

    void PlacePieces()
    {
        //White pieces
        //white rooks
        Instantiate(whitePieces[2], new Vector3(-3.5f, -3.5f, 0), Quaternion.identity, pieces.transform);
        Instantiate(whitePieces[2], new Vector3(3.5f, -3.5f, 0), Quaternion.identity, pieces.transform);
        //white knights
        Instantiate(whitePieces[4], new Vector3(-2.5f, -3.5f, 0), Quaternion.identity, pieces.transform);
        Instantiate(whitePieces[4], new Vector3(2.5f, -3.5f, 0), Quaternion.identity, pieces.transform);
        //white bishops
        Instantiate(whitePieces[3], new Vector3(-1.5f, -3.5f, 0), Quaternion.identity, pieces.transform);
        Instantiate(whitePieces[3], new Vector3(1.5f, -3.5f, 0), Quaternion.identity, pieces.transform);
        //white king and queen
        Instantiate(whitePieces[1], new Vector3(-0.5f, -3.5f, 0), Quaternion.identity, pieces.transform);
        Instantiate(whitePieces[0], new Vector3(0.5f, -3.5f, 0), Quaternion.identity, pieces.transform);
        //white pawns
        for (int column = 0; column < 8; column++)
        {
            Instantiate(whitePieces[5], new Vector3(column - 3.5f, -2.5f, 0), Quaternion.identity, pieces.transform);
        }
        //Black pieces
        Instantiate(blackPieces[2], new Vector3(-3.5f, 3.5f, 0), Quaternion.identity, pieces.transform);
        Instantiate(blackPieces[2], new Vector3(3.5f, 3.5f, 0), Quaternion.identity, pieces.transform);
        //black knights
        Instantiate(blackPieces[4], new Vector3(-2.5f, 3.5f, 0), Quaternion.identity, pieces.transform);
        Instantiate(blackPieces[4], new Vector3(2.5f, 3.5f, 0), Quaternion.identity, pieces.transform);
        //black bishops
        Instantiate(blackPieces[3], new Vector3(-1.5f, 3.5f, 0), Quaternion.identity, pieces.transform);
        Instantiate(blackPieces[3], new Vector3(1.5f, 3.5f, 0), Quaternion.identity, pieces.transform);
        //black king and queen
        Instantiate(blackPieces[1], new Vector3(-0.5f, 3.5f, 0), Quaternion.identity, pieces.transform);
        Instantiate(blackPieces[0], new Vector3(0.5f, 3.5f, 0), Quaternion.identity, pieces.transform);
        //black pawns
        for (int column = 0; column < 8; column++)
        {
            Instantiate(blackPieces[5], new Vector3(column - 3.5f, 2.5f, 0), Quaternion.identity, pieces.transform);
        }
    }
}
