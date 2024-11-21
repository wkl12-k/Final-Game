using UnityEngine;

public class PieceStatus : MonoBehaviour
{
    public bool pieceOnBoard = false;

    public void SetPieceStatus(bool status)
    {
        pieceOnBoard = status;
    }

    public bool GetPieceStatus()
    {
        return pieceOnBoard;
    }
}