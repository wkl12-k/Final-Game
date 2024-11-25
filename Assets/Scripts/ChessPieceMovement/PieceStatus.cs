using UnityEngine;

public class PieceStatus : MonoBehaviour
{
    private chessPuzzleSpawner chessPuzzleSpawner;      
    public bool pieceOnBoard = false; 
    public bool allowEndGoal = true;  

    void Start()
    {
        chessPuzzleSpawner = FindObjectOfType<chessPuzzleSpawner>();  
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
