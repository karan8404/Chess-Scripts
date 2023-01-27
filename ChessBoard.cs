using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public GameObject whiteSquare;
    public GameObject blackSquare;

    public GameObject[] whitePieces;
    public GameObject[] blackPieces;

    public GameObject boardTiles;
    public GameObject pieces;

    Dictionary<Color, GameObject> squareDisplay = new Dictionary<Color, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Board board=new Board();
        board.startGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
