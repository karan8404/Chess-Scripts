using System.Collections;
using System.Collections.Generic;

class FenUtility
{
    string fen;
    string startingPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    public Board createBoard(string fen)
    {
        int[2] location = { 0, 0 };
        Board board = new Board();
        for (int i = 0; i < fen.Length; i++)
        {
            char c = fen[i];
            if (char.IsDigit(c))
            {
                location[0] = location[0] + char.GetNumericValue(c);
            }
            else if (char.IsLetter(c))
            {

            }

        }
    }

    Dictionary<char, Piece> pieceDictionary = new Dictionary<char, Piece>();

    void fillDictionary()
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