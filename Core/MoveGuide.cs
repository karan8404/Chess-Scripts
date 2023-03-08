using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveGuide
{
    public static bool whiteToMove = true;
    //public static Piece whiteKing=pieces[4,0];
    //public static Piece blackKing=pieces[4,7];
    public static Vector3Int EnpassantPos;

    public static Piece[,] pieces;
    public static Piece moved;
    public static Piece captured;
    public static Vector2Int start;
    public static Vector2Int end;
    public static Vector2Int move;
    public static Instantiater instantiater;


    //vectors passed are passed as array indices.
    public static bool isLegal(ref Piece[,] pcs, Piece mvd, Piece cptrd, Vector2Int st, Vector2Int ed, Instantiater instr)
    {
        //resetting data members
        pieces = pcs;
        moved = mvd;
        captured = cptrd;
        start = st;
        end = ed;
        move = end - start;
        instantiater = instr;

        if (capturesSameColorPiece())
        {
            Debug.Log("captures same color piece");
            return false;
        }

        if (!isCorrectTurn())
        {
            Debug.Log("wrong color to move");
            return false;
        }

        if (!isPieceMoveLegal())
        {
            Debug.Log("Illegal move for piece");
            return false;
        }

        if (hasPieceinBetween())
        {
            Debug.Log("Piece in between");
            return false;
        }

        if (!(start == end))
        {
            whiteToMove = !whiteToMove;
        }
        if (EnpassantPos.z == 0)
        {
            EnpassantPos = Vector3Int.one * (-1);
        }
        else
        {
            EnpassantPos.z -= 1;
        }
            
        return true;
    }

    //check directly in game class.
    public static bool isOnBoard(Vector2Int end)
    {
        if (end.x < 0 || end.y < 0 || end.x > 7 || end.y > 7)
        {
            Debug.Log("Not on board");
            return false;
        }
        return true;
    }

    public static bool capturesSameColorPiece()
    {
        if (moved.color == captured.color)
        {
            return true;
        }
        return false;
    }

    public static bool isCorrectTurn()
    {
        if (whiteToMove && moved.color == Color.Black)
        {
            return false;
        }
        else if (!whiteToMove && moved.color == Color.White)
        {
            return false;
        }
        return true;
    }

    public static bool isPieceMoveLegal()
    {
        if (moved.type == Type.King)
        {
            if (!isKingMove())
            {
                return false;
            }
        }
        else if (moved.type == Type.Queen)
        {
            if (!(isRookMove() || isBishopMove()))
            {
                return false;
            }
        }
        else if (moved.type == Type.Rook)
        {
            if (!isRookMove())
            {
                return false;
            }
        }
        else if (moved.type == Type.Bishop)
        {
            if (!isBishopMove())
            {
                return false;
            }
        }
        else if (moved.type == Type.Knight)
        {
            if (!isKnightMove())
            {
                return false;
            }
        }
        else if (moved.type == Type.Pawn)
        {
            if (moved.color == Color.White && !isWhitePawnMove())
            {
                return false;
            }
            else if (moved.color == Color.Black && !isBlackPawnMove())
            {
                return false;
            }
        }

        return true;
    }

    public static bool hasPieceinBetween()
    {

        if (moved.type == Type.Knight)
        {
            return false;
        }

        Vector2Int current = start;

        translateVector(ref current, ref end);

        while (current != end)
        {
            if (pieces[current.x, current.y].hasPiece)
            {
                return true;
            }
            translateVector(ref current, ref end);
        }
        return false;
    }

    public static bool isUnderCheck(){
        
        return false;
    }

    public static void translateVector(ref Vector2Int current, ref Vector2Int target)//moves current towards target one step
    {
        if (current.x != target.x)
        {
            current.x -= ((int)Mathf.Sign(current.x - target.x));
        }
        if (current.y != target.y)
        {
            current.y -= ((int)Mathf.Sign(current.y - target.y));
        }
    }

    public static bool isRookMove()
    {
        //atleast one of the axes must be zero
        if (move.x == 0 || move.y == 0)
        {
            return true;
        }
        return false;
    }

    public static bool isBishopMove()
    {
        //if absolute value of movement in both axes is equal.
        if (Mathf.Abs(move.x) == Mathf.Abs(move.y))
        {
            return true;
        }
        return false;
    }

    public static bool isKingMove()
    {
        //absolute values of x and y must not be greater than 1
        if (Mathf.Abs(move.x) > 1 || Mathf.Abs(move.y) > 1)
            return false;
        return true;
    }

    public static bool isKnightMove()
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

    public static bool isWhitePawnMove()
    {
        if (move == Vector2Int.up && !captured.hasPiece)
        {
            return true;
        }
        else if (start.y == 1 && move == Vector2Int.up * 2 && !captured.hasPiece)//two square movement on first move
        {
            EnpassantPos = new Vector3Int(end.x, end.y - 1, 1);
            return true;
        }
        else if (Mathf.Abs(move.x) == 1 && move.y == 1 && captured.hasPiece)//normal capture
        {
            return true;
        }
        else if (Mathf.Abs(move.x) == 1 && move.y == 1 && (end.x == EnpassantPos.x && end.y == EnpassantPos.y))//En Passant capture
        {
            instantiater.destroyPiece(pieces[end.x, end.y - 1]);
            return true;
        }
        return false;
    }

    public static bool isBlackPawnMove()
    {
        if (move == Vector2Int.down && !captured.hasPiece)
        {
            return true;
        }
        else if (start.y == 6 && move == Vector2Int.down * 2 && !captured.hasPiece)//two square movement on first move
        {
            EnpassantPos = new Vector3Int(end.x, end.y + 1, 1);
            return true;
        }
        else if (Mathf.Abs(move.x) == 1 && move.y == -1 && captured.hasPiece)//normal capture
        {
            return true;
        }
        else if (Mathf.Abs(move.x) == 1 && move.y == -1 && (end.x == EnpassantPos.x && end.y == EnpassantPos.y))//En Passant capture
        {
            instantiater.destroyPiece(pieces[end.x, end.y + 1]);
            return true;
        }
        return false;
    }
}
