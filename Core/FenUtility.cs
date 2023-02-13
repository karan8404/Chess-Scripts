using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenUtility : MonoBehaviour
{
    public string startingFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    public void createBoard(Board board, string fen)
    {
        int column = 0, row = 7;
        foreach (char c in fen)
        {
            if (char.IsDigit(c))
            {
                column = column + ((int)char.GetNumericValue(c));
            }
            else if (char.IsLetter(c))
            {
                Piece pc = charPiece(c);
                board.squares[column,row].placePiece(pc);
                column=column+1;
            }
            else if (c == '/')
            {
                row = row - 1;
                column = 0;
            }
        }
    }

    static Piece charPiece(char c)
    {
        Piece.Color color;
        Piece.Type type;
        if (char.IsUpper(c))
            color = Piece.Color.White;
        else
            color = Piece.Color.Black;

        switch (char.ToLower(c))
        {
            case 'k':
                type = Piece.Type.King;
                break;
            case 'q':
                type = Piece.Type.Queen;
                break;
            case 'r':
                type = Piece.Type.Rook;
                break;
            case 'b':
                type = Piece.Type.Bishop;
                break;
            case 'n':
                type = Piece.Type.Knight;
                break;
            case 'p':
                type = Piece.Type.Pawn;
                break;
            default:
                type = Piece.Type.King;
                break;
        }
        Piece piece=new Piece(color,type);
        return piece;
    }
}
