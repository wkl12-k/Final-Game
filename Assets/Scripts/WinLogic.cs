using UnityEngine;

public class WinLogic : MonoBehaviour
{

    private PieceStatus pieceStatus;
    private chessPuzzleSpawner chessPuzzleSpawner;
    private bool allPiecesUsed = false;
    private int counter;
    private int totalPieces;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = pieceStatus.GetCounter();
        totalPieces = chessPuzzleSpawner.GetTotalPieces();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == totalPieces)
        {
            allPiecesUsed = true;
        }
    }

    public bool GetAllPiecesUsed()
    {
        return allPiecesUsed;
    }
}
