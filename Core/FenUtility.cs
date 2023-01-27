using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FenUtility
{
    string fen;
    public static string startingPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    public static void createBoard(Board board, string fen)
    {
        int[] location = { 0, 0 };
        for (int i = 0; i < fen.Length; i++)
        {
            char c = fen[i];
            if (char.IsDigit(c))
            {
                int cNum = ((int)char.GetNumericValue(c));
                while (cNum-- > 0)
                {
                    board.squares[location[0], location[1]] = new Square(location);
                    location[0]++;
                }
            }
            else if (char.IsLetter(c))
            {
                board.pieces.Add(pieceDictionary[c]);
                board.squares[location[0], location[1]] = new Square(board.pieces[^1], location);
            }
            else if (c == '/')
            {
                location[1]++;
            }
        }
        fixColors(board);
    }

    static void fixColors(Board board)
    {
        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                if ((row + column) % 2 == 0)
                {
                    board.squares[column, row].color = Color.White;
                }
                else
                {
                    board.squares[column, row].color = Color.Black;
                }
            }
        }
    }

    public static Dictionary<char, Piece> pieceDictionary = new Dictionary<char, Piece>{
        {'p', Piece.blackPawn},
        {'n', Piece.blackKnight},
        {'b', Piece.blackBishop},
        {'r', Piece.blackRook},
        {'q', Piece.blackQueen},
        {'k', Piece.blackKing},

        {'P', Piece.whitePawn},
        {'N', Piece.whiteKnight},
        {'B', Piece.whiteBishop},
        {'R', Piece.whiteRook},
        {'Q', Piece.whiteQueen},
        {'K', Piece.whiteKing}
    };
}