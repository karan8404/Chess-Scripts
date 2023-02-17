using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FenUtility : MonoBehaviour
{
    public static string startingPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    public void createBoard(string fen, out Piece[,] pieces)
    {
        pieces = new Piece[8, 8];
        int column = 0, row = 7;
        foreach (char c in fen)
        {
            if (char.IsDigit(c))
            {
                int count = ((int)char.GetNumericValue(c));
                while (count-- > 0)
                {
                    pieces[column,row]=new Piece();
                    column=column+1;
                }
            }
            else if (char.IsLetter(c))
            {
                Vector3 location = new Vector3(column - 3.5f, row - 3.5f, 0);
                pieces[column,row]=charPiece(c);

                GetComponent<Instantiater>().createPiece(pieces[column,row],location);
                column = column + 1;
            }
            else if (c == '/')
            {
                row = row - 1;
                column = 0;
            }
        }
    }

    Piece charPiece(char c)
    {
        Color color;
        Type type;
        if (char.IsUpper(c))
            color = Color.White;
        else
            color = Color.Black;

        switch (char.ToLower(c))
        {
            case 'k':
                type = Type.King;
                break;
            case 'q':
                type = Type.Queen;
                break;
            case 'r':
                type = Type.Rook;
                break;
            case 'b':
                type = Type.Bishop;
                break;
            case 'n':
                type = Type.Knight;
                break;
            case 'p':
                type = Type.Pawn;
                break;
            default:
                type = Type.King;
                break;
        }
        return new Piece(type,color);
    }
}