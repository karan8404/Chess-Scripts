using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenUtility
{
    string fen;
    public static string startingPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    public static void createBoard(Board board, string fen)
    {
        makeBoard(board);
        int[] lc = { 0, 7 };
        foreach (char c in fen)
        {
            if (char.IsDigit(c))
            {
                lc[0] = lc[0] + ((int)char.GetNumericValue(c));
            }
            else if (char.IsLetter(c))
            {
                Piece pc = charPiece(c);
                pc.location[0] = lc[0];
                pc.location[1]=lc[1];
                board.pieces.Add(pc);
                board.squares[lc[0],lc[1]].piece=pc;
                board.squares[lc[0],lc[1]].hasPiece=true;
                lc[0] = lc[0] + 1;
            }
            else if (c == '/')
            {
                lc[1] = lc[1] - 1;
                lc[0] = 0;
            }
        }
    }

    static Piece charPiece(char c)
    {
        Piece piece = new Piece();
        if (char.IsUpper(c))
            piece.color = Color.White;
        else
            piece.color = Color.Black;

        switch (char.ToLower(c))
        {
            case 'k':
                piece.type = Piece.Type.King;
                break;
            case 'q':
                piece.type = Piece.Type.Queen;
                break;
            case 'r':
                piece.type = Piece.Type.Rook;
                break;
            case 'b':
                piece.type = Piece.Type.Bishop;
                break;
            case 'n':
                piece.type = Piece.Type.Knight;
                break;
            case 'p':
                piece.type = Piece.Type.Pawn;
                break;
            default:
                piece.type = Piece.Type.King;
                break;
        }
        return piece;
    }

    static void makeBoard(Board board)
    {
        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                int[] location = { column, row };
                if ((row + column) % 2 == 0)
                {
                    board.squares[column, row] = new Square(location, Color.Black);
                }
                else
                {
                    board.squares[column, row] = new Square(location, Color.White);
                }
            }
        }
    }
}