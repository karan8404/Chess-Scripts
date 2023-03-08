using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveGuide2
{

    public static List<Vector2Int> moves;
    public static Piece[,] pieces;
    public static Piece moved;
    public static Vector2Int start;
    public static Vector2Int end;

    public static void isLegal(ref Piece[,] pcs, Piece mvd, Vector2Int st, Vector2Int ed)
    {
        moves.Clear();
        pieces = pcs;
        moved = mvd;
        start = st;
        end = ed;


    }

    public static void generateMoves(Type type)
    {
        switch (type)
        {
            case Type.King:
                genKingMoves();
                break;
            case Type.Queen:
                genQueenMoves();
                break;
            case Type.Rook:
                genRookMoves();
                break;
            case Type.Bishop:
                genBishopMoves();
                break;
            case Type.Knight:
                genKnightMoves();
                break;
            case Type.Pawn:
                genPawnMoves();
                break;
        }
    }


    //move generation functions
    public static void genSlidingMoves(Vector2Int[] offsets)
    {
        Vector2Int curr;
        foreach (Vector2Int dir in offsets)
        {
            for (int i = 1; ; i++)
            {
                curr = start + dir * i;

                if (!isOnBoard(curr) || pieceAt(curr).color == moved.color)
                    break;

                moves.Add(curr);

                if (pieceAt(curr).hasPiece && pieceAt(curr).color != moved.color)
                    break;
            }
        }
    }

    public static void genPosMoves(Vector2Int[] offsets)
    {
        Vector2Int curr;

        foreach (Vector2Int dir in offsets)
        {
            curr = start + dir;

            if (!isOnBoard(curr) || pieceAt(curr).color == moved.color)
                continue;

            moves.Add(curr);
        }
    }
    public static void genRookMoves()
    {
        Vector2Int[] rookOffsets = { v2Int(0, 1), v2Int(-1, 0), v2Int(0, -1), v2Int(1, 0) };

        genSlidingMoves(rookOffsets);
    }

    public static void genBishopMoves()
    {
        Vector2Int[] bishopOffsets = { v2Int(1, 1), v2Int(1, -1), v2Int(-1, 1), v2Int(-1, -1) };

        genSlidingMoves(bishopOffsets);
    }

    public static void genQueenMoves()
    {
        Vector2Int[] queenOffsets = { v2Int(0, 1), v2Int(-1, 0), v2Int(0, -1), v2Int(1, 0), v2Int(1, 1), v2Int(1, -1), v2Int(-1, 1), v2Int(-1, -1) };

        genSlidingMoves(queenOffsets);
    }

    public static void genKingMoves()
    {
        Vector2Int[] kingOffsets = { v2Int(0, 1), v2Int(-1, 0), v2Int(0, -1), v2Int(1, 0), v2Int(1, 1), v2Int(1, -1), v2Int(-1, 1), v2Int(-1, -1) };

        genPosMoves(kingOffsets);
    }

    public static void genKnightMoves()
    {
        Vector2Int[] knightOffsets = { v2Int(1, 2), v2Int(1, -2), v2Int(-1, 2), v2Int(-1, -2), v2Int(2, 1), v2Int(2, -1), v2Int(-2, 1), v2Int(-2, -1) };

        genPosMoves(knightOffsets);
    }

    public static void genPawnMoves()
    {
        Vector2Int curr;
        int type = ((int)moved.color) * (-2) + 1;
        Vector2Int[] pawnOffsets = { v2Int(0, 1), v2Int(0, 2), v2Int(-1, 1), v2Int(1, 1) };
        for (int i = 0; i < pawnOffsets.Length; i++) { pawnOffsets[i] = pawnOffsets[i] * type; }

        curr = start + pawnOffsets[0];
        if (isOnBoard(curr) && !pieceAt(curr).hasPiece)
        {
            moves.Add(curr);//one square move
            curr = start + pawnOffsets[1];
            if (isOnBoard(curr) && (start.y == ((int)moved.color) * 7 + type) && !pieceAt(curr).hasPiece)//two square move
                moves.Add(curr);
        }

        for (int i = 2; i < 4; i++)
        {//two diagonal moves
            curr = start + pawnOffsets[i];
            if (isOnBoard(curr) && pieceAt(curr).hasPiece && pieceAt(curr).color != moved.color)
                moves.Add(curr);
        }
    }


    //utilitiy functions
    public static Piece pieceAt(Vector2Int loc)
    {
        return pieces[loc.x, loc.y];
    }
    public static Piece pieceAt(int x, int y)
    {
        return pieces[x, y];
    }

    public static Vector2Int v2Int(int x, int y)
    {
        return new Vector2Int(x, y);
    }
    public static bool isOnBoard(Vector2Int v)
    {
        if (v.x < 0 || v.x > 7 || v.y < 0 || v.y > 7)
            return false;
        return true;
    }
}
