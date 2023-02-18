using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuide
{
    bool canWhiteCastleShort;
    bool canWhiteCastleLong;
    bool canBlackCastleShort;
    bool canBlackCastleLong;
    static Piece[,] pieces;

    public static bool isLegal(ref Piece[,] pcs,ref Piece start,ref Piece end, Vector2 original, Vector2 final)
    {
        pieces = pcs;
        if (!isOnBoard(final))
        {
            return false;
        }

        if(capturesSameColorPiece(start,end)){
            return false;
        }

        return true;
    }
    public static bool isStraightMove(Vector2Int move)
    {
        //atleast one of the axes must be zero
        if (move.x == 0 || move.y == 0)
        {
            return true;
        }
        return false;
    }

    public static bool isDiagonalMove(Vector2Int move)
    {
        //if absolute value of movement in both axes is equal.
        if (Mathf.Abs(move.x) == Mathf.Abs(move.y))
        {
            return true;
        }
        return false;
    }

    public static bool isKingMove(Vector2Int move)
    {
        //absolute values of x and y must not be greater than 1
        if (Mathf.Abs(move.x) > 1 || Mathf.Abs(move.y) > 1)
            return false;
        return true;
    }

    public static bool isKnightMove(Vector2Int move)
    {
        int x = Mathf.Abs(move.x);
        int y = Mathf.Abs(move.y);
        //both x and y are less than 3 and greater than 0
        //and if x=1 then y=2, vice versa.i.e. both should not be equal.
        if (x > 2 || x < 1 || y > 2 || y < 1)
            return false;
        if (x == y)
            return false;
        return true;
    }

    public static bool isWhitePawnMove(Vector2Int move)
    {
        return false;
    }

    public static bool isOnBoard(Vector2 final)
    {
        if (Mathf.Abs(final.x) > 4.0f || Mathf.Abs(final.y) > 4.0)
        {
            return false;
        }
        return true;
    }

    public static bool capturesSameColorPiece(Piece original, Piece final)
    {
        if (original.color == final.color)
        {
            return true;
        }
        return false;
    }
}
