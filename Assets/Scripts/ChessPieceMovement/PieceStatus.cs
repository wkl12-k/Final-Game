using UnityEngine;

public class PieceStatus : MonoBehaviour
{
    private ChessPuzzleSpawner chessPuzzleSpawner;
    public bool pieceOnBoard = false; 
    public bool allowEndGoal = true;  

    void Start()
    {
        chessPuzzleSpawner = FindObjectOfType<ChessPuzzleSpawner>();  
    }

    public void SetPieceStatus(bool status)
    {
        pieceOnBoard = status;
        
    }

    public bool GetPieceStatus()
    {
        return pieceOnBoard;
    }
}
