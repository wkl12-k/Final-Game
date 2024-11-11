using UnityEngine;
using UnityEngine.UI;

public class DragPieces : MonoBehaviour
{
    [Header("Piece Prefabs")]
    public GameObject rookPrefab;
    public GameObject bishopPrefab;
    public GameObject kingPrefab;
    public GameObject knightPrefab;

    [Header("UI Buttons")]
    public Button rookButton;
    public Button bishopButton;
    public Button kingButton;
    public Button knightButton;

    [Header("Chess Board Reference")]
    public ChessBoard chessBoard;

    private GameObject selectedPiecePrefab;
    private GameObject lastPlacedPiece;

    void Start()
    {


        rookButton.onClick.AddListener(() => SelectPiece(rookPrefab));
        bishopButton.onClick.AddListener(() => SelectPiece(bishopPrefab));
        kingButton.onClick.AddListener(() => SelectPiece(kingPrefab));
        knightButton.onClick.AddListener(() => SelectPiece(knightPrefab));
    }

    void SelectPiece(GameObject piecePrefab)
    {
        selectedPiecePrefab = piecePrefab;
        Vector3 position = lastPlacedPiece != null ? lastPlacedPiece.transform.position : chessBoard.GetStartTilePosition();

        if (lastPlacedPiece != null)
            Destroy(lastPlacedPiece);

        lastPlacedPiece=InstantiatePieceOnBoard(position, piecePrefab);
    }

    GameObject InstantiatePieceOnBoard(Vector3 position, GameObject piecePrefab)
    {
        Quaternion uprightRotation = Quaternion.Euler(-90, 90, 0);
        GameObject piece = Instantiate(piecePrefab, position, uprightRotation);

        ChessPieceMovement pieceMovement = piece.GetComponent<ChessPieceMovement>();
        chessBoard.SetSelectedPiece(pieceMovement);

        return piece;
    }

}