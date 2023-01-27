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
                    board.squares[location[0],location[1]] = new Square();
                    location[0]++;
                }
            }
            else if (char.IsLetter(c))
            {
                board.pieces.Add(pieceDictionary[c]);
                board.squares[location[0],location[1]] = new Square(board.pieces[^1]);
            }
            else if (c == '/')
            {
                location[1]++;
            }
        }
    }

    public static Dictionary<char, Piece> pieceDictionary = new Dictionary<char, Piece>();

    public static void fillDictionary()
    {
        pieceDictionary.Add('p', Piece.blackPawn);
        pieceDictionary.Add('n', Piece.blackKnight);
        pieceDictionary.Add('b', Piece.blackBishop);
        pieceDictionary.Add('r', Piece.blackRook);
        pieceDictionary.Add('q', Piece.blackQueen);
        pieceDictionary.Add('k', Piece.blackKing);

        pieceDictionary.Add('P', Piece.whitePawn);
        pieceDictionary.Add('N', Piece.whiteKnight);
        pieceDictionary.Add('B', Piece.whiteBishop);
        pieceDictionary.Add('R', Piece.whiteRook);
        pieceDictionary.Add('Q', Piece.whiteQueen);
        pieceDictionary.Add('K', Piece.whiteKing);
    }
}