using UnityEngine;

public class PieceMenuHandler : MonoBehaviour
{
    public GameObject knightPrefab;
    public GameObject rookPrefab;
    public GameObject bishopPrefab;
    public GameObject kingPrefab;

    private Vector3 currentTilePosition;
    private bool isFirstPiece = true;
    private ChessBoard chessBoard;

    void OnEnable()
    {
        ChessBoard.OnBoardCreated += InitializePosition;
    }

    void OnDisable()
    {
        ChessBoard.OnBoardCreated -= InitializePosition;
    }

    
    private void InitializePosition()
    {
        chessBoard = FindObjectOfType<ChessBoard>();
        if (chessBoard != null)
        {
            currentTilePosition = chessBoard.GetStartTilePosition();
        }
    }

    public void SpawnPiece(string pieceType)
    {
        if (isFirstPiece && chessBoard != null)
        {
            currentTilePosition = chessBoard.GetStartTilePosition();
            isFirstPiece = false;
        }

        GameObject pieceToSpawn = null;

        switch (pieceType)
        {
            case "Knight":
                pieceToSpawn = knightPrefab;
                break;
            case "Rook":
                pieceToSpawn = rookPrefab;
                break;
            case "Bishop":
                pieceToSpawn = bishopPrefab;
                break;
            case "King":
                pieceToSpawn = kingPrefab;
                break;
        }

        if (pieceToSpawn != null && chessBoard != null)
        {
            GameObject newPiece = Instantiate(pieceToSpawn, currentTilePosition, Quaternion.identity);
            currentTilePosition = newPiece.transform.position;
        }
    }
}
