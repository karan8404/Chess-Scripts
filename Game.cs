using UnityEngine;
public class Game : MonoBehaviour
{
    void Start()
    {
        Board board = new Board(Vector3.zero);
        board.startGame();
    }
}