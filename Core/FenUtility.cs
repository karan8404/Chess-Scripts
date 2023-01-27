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
                Piece pc=charPiece(c);
                pc.location=location;
                board.pieces.Add(pc);
                board.squares[location[0], location[1]] = new Square(board.pieces[^1], location);
            }
            else if (c == '/')
            {
                location[1]++;
            }
        }
        fixColors(board);
    }

    static Piece charPiece(char c){
        Piece piece=new Piece();
        if(char.IsUpper(c))
            piece.color=Color.White;
        else
            piece.color=Color.Black;

        switch(char.ToLower(c)){
            case 'k':
                piece.type=Piece.Type.King;
                break;
            case 'q':
                piece.type=Piece.Type.Queen;
                break;
            case 'r':
                piece.type=Piece.Type.Rook;
                break;
            case 'b':
                piece.type=Piece.Type.Bishop;
                break;
            case 'n':
                piece.type=Piece.Type.Knight;
                break;
            case 'p':
                piece.type=Piece.Type.Pawn;
                break;
            default:
                piece.type=Piece.Type.King;
                break;
        }
        return piece;
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
}