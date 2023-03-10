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
        Instantiater instantiater = GetComponent<Instantiater>();
        Vector2Int normalizedOriginal = posToIndex(originalPosition);
        Vector2Int normalizedFinal = posToIndex(finalPosition);

        //first checks if move is on board.
        if ((MoveGuide.isOnBoard(normalizedFinal))
            && MoveGuide.isLegal(ref pieces, piece, pieces[normalizedFinal.x, normalizedFinal.y], normalizedOriginal, normalizedFinal, instantiater))
        {
            //set original position to not have a piece
            //for final position, destroy instance, set piece position to it and modify it to have a piece. 
            instantiater.destroyPiece(pieces[normalizedFinal.x, normalizedFinal.y]);
            piece.setPosition(normalizedFinal - Vector2.one * 3.5f);
            pieces[normalizedFinal.x, normalizedFinal.y] = piece;
        }
        else
        {
            pieces[normalizedOriginal.x, normalizedOriginal.y] = piece;
            piece.setPosition(originalPosition);
        }
    }

    public void pickPiece2(Piece piece, Vector2 originalPosition)
    {
        Instantiater instantiater = GetComponent<Instantiater>();
        Vector2Int normalizedOriginal = posToIndex(originalPosition);

        MoveGuide2.generateMoves(ref pieces, piece, normalizedOriginal,instantiater);
    }

    public void placePiece2(Piece piece, Vector2 originalPosition, Vector2 finalPosition)
    {
        Instantiater instantiater = GetComponent<Instantiater>();
        Vector2Int normalizedOriginal = posToIndex(originalPosition);
        Vector2Int normalizedFinal = posToIndex(finalPosition);

        if (MoveGuide2.isLegal(normalizedFinal))
        {
            //set original position to not have a piece
            //for final position, destroy instance, set piece position to it and modify it to have a piece. 
            instantiater.destroyPiece(pieces[normalizedFinal.x, normalizedFinal.y]);
            piece.setPosition(normalizedFinal - Vector2.one * 3.5f);
            pieces[normalizedFinal.x, normalizedFinal.y] = piece;
            Debug.Log("Placed");
        }
        else
        {
            pieces[normalizedOriginal.x, normalizedOriginal.y] = piece;
            piece.setPosition(originalPosition);
            Debug.Log("failed");
        }
        instantiater.removeMoves();
    }

    public static Vector2Int posToIndex(Vector2 vector)
    {
        return new Vector2Int(Mathf.RoundToInt(vector.x + 3.5f), Mathf.RoundToInt(vector.y + 3.5f));
    }

    public static Vector2 indexToPos(Vector2Int vector)
    {
        return new Vector2(vector.x + 3.5f, vector.y + 3.5f);
    }
}