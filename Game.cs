using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject[,] squares;
    public Piece[,] pieces;
    void Start()
    {
        squares = new GameObject[8, 8];
        pieces = new Piece[8, 8];

        createGame();

    }

    public void createGame(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR")
    {
        //placing squares

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                Vector3 location = new Vector3(column - 3.5f, row - 3.5f, 0);
                Color color = (column + row) % 2 == 0 ? Color.Black : Color.White;
                squares[column, row] = GetComponent<Instantiater>().createSquare(location, color);
            }
        }

        //placing pieces according to fen
        GetComponent<FenUtility>().createBoard(fen, out pieces);

    }

    public void placePiece(Piece piece, Vector2 originalPosition, Vector2 finalPosition)
    {
        Vector2Int normalizedOriginal = new Vector2Int(Mathf.RoundToInt(originalPosition.x + 3.5f), Mathf.RoundToInt(originalPosition.y + 3.5f));
        if (Mathf.Abs(finalPosition.x) > 4.0f || Mathf.Abs(finalPosition.y) > 4.0f)
        {
            piece.setPosition((Vector3)(originalPosition));
            pieces[normalizedOriginal.x,normalizedOriginal.y]=piece;
            return;
        }

        Vector2Int normalizedFinal = new Vector2Int(Mathf.RoundToInt(finalPosition.x + 3.5f), Mathf.RoundToInt(finalPosition.y + 3.5f));
        finalPosition.x = normalizedFinal.x - 3.5f;
        finalPosition.y = normalizedFinal.y - 3.5f;

        ref Piece locationPiece = ref pieces[normalizedFinal.x, normalizedFinal.y];

        if (!locationPiece.hasPiece || locationPiece.color != piece.color)
        {
            Destroy(locationPiece.instance);
            pieces[normalizedOriginal.x, normalizedOriginal.y].hasPiece = false;
            pieces[normalizedFinal.x, normalizedFinal.y] = piece;
            piece.setPosition(finalPosition);
            return;
        }

        if (locationPiece.color == piece.color)
        {
            piece.setPosition((Vector3)(originalPosition));
            pieces[normalizedOriginal.x,normalizedOriginal.y]=piece;
            return;
        }

        Debug.Log("something is wrong");
    }

}