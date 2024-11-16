using System.Collections.Generic;
using UnityEngine;

public class chessPuzzleSpawner : MonoBehaviour
{

    [Header("Piece Prefabs")]
    [SerializeField] GameObject rookPrefab;
    [SerializeField] GameObject bishopPrefab;
    [SerializeField] GameObject kingPrefab;
    [SerializeField] GameObject knightPrefab;
    [SerializeField] GameObject pawnPrefab;

    [Header("Other Components")]
    [SerializeField] ChessPieceMovement pieceMovement;
    [SerializeField] ChessBoard chessBoard;

    private List<GameObject> pieceMenu;

    List<GameObject> CreatePieceMenu()
    {
        pieceMenu = new List<GameObject>();
        int randomAmount = Random.Range(4, 8);
        List<GameObject> pieces = new List<GameObject> { rookPrefab, bishopPrefab, knightPrefab, kingPrefab, pawnPrefab };

        for (int i = 0; i < randomAmount; i++)
        {
            int randomPiece = Random.Range(0, pieces.Count);
            pieceMenu.Add(pieces[randomPiece]);
        }

        return pieceMenu;

    }

    public void CreateEndGoal()
    {
       
        CreatePieceMenu();
       
        Vector3 prevPosition=chessBoard.GetStartTilePosition();

        foreach (GameObject piece in pieceMenu)
        {
            if (piece.CompareTag("rook"))
            {
                pieceMovement = piece.GetComponent<RookMovement>();
            }
            else if (piece.CompareTag("king"))
            {
                pieceMovement = piece.GetComponent<KingMovement>();
            }
            else if (piece.CompareTag("bishop"))
            {
                pieceMovement = piece.GetComponent<BishopMovement>();
            }
            else if (piece.CompareTag("pawn"))
            {
                pieceMovement = piece.GetComponent<PawnMovement>();
            }
            else if (piece.CompareTag("knight"))
            {
                pieceMovement = piece.GetComponent<KnightMovement>();
            }

            List<Vector3> availableTiles = pieceMovement.CheckAvailableMoves(prevPosition);
            //if(availableTiles.Contains(new Vector3(7, 0, 7)))
            //availableTiles.Remove(new Vector3(7, 0, 7));

            int randomPosition = Random.Range(0, availableTiles.Count);
            prevPosition = availableTiles[randomPosition];

            //Debug.Log(prevPosition.ToString());
            
        }
        chessBoard.SetEndGoalTile((int)prevPosition.x, (int)prevPosition.z);
    }


    public List<GameObject> GetPieceMenu()
    {
        return pieceMenu;
    }
}
