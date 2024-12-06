
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzleSpawner : MonoBehaviour
{

    [Header("Piece Prefabs")]
    [SerializeField] GameObject rookPrefab;
    [SerializeField] GameObject bishopPrefab;
    [SerializeField] GameObject kingPrefab;
    [SerializeField] GameObject knightPrefab;
    [SerializeField] GameObject pawnPrefab;


    private Vector3 oppQueenPosition;
    private GameObject oppQueen;




    private int totalPieces;
    private int pawnCount = 0;
    private int kingCount = 0;
    private int otherPieceCount = 0;


    [Header("Other Components")]
    [SerializeField] ChessPieceMovement pieceMovement;
    [SerializeField] ChessBoard chessBoard;
    [SerializeField] SceneManagement sceneManager;

    [Header("Difficulty Indicator")]
    [SerializeField] int minPieces = 4;
    [SerializeField] int maxPieces = 8;

    private List<GameObject> pieceMenu;


    List<GameObject> CreatePieceMenu()
    {
        pieceMenu = new List<GameObject>();

        if (sceneManager.GetCurrentScene() == "TutorialLevel")
        {
            pieceMenu.Add(rookPrefab);
            pieceMenu.Add(bishopPrefab);
            pieceMenu.Add(knightPrefab);
            pieceMenu.Add(kingPrefab);
            pieceMenu.Add(pawnPrefab);
        }
        else
        {
            int randomAmount = Random.Range(minPieces, maxPieces);
            totalPieces = randomAmount;
            List<GameObject> pieces = new List<GameObject> { rookPrefab, bishopPrefab, knightPrefab, kingPrefab, pawnPrefab };

            while (pieceMenu.Count < randomAmount)
            {
                int randomPiece = Random.Range(0, pieces.Count);
                GameObject selectedPiece = pieces[randomPiece];

                if (selectedPiece.Equals(kingPrefab) && kingCount < 1)
                {
                    pieceMenu.Add(selectedPiece);
                    kingCount++;
                }
                else if (selectedPiece.Equals(pawnPrefab) && pawnCount < 1)
                {
                    pieceMenu.Add(selectedPiece);
                    pawnCount++;
                }
                else if (!selectedPiece.Equals(kingPrefab) && !selectedPiece.Equals(pawnPrefab))
                {
                    pieceMenu.Add(selectedPiece);
                }
            }
        }

        return pieceMenu;
    }


    public void CreateEndGoal()
    {
        CreatePieceMenu();


        Vector3 endPosition = chessBoard.GetStartTilePosition();

        Vector3 prevPosition = chessBoard.GetStartTilePosition();


        int queenListPosition = Random.Range(0, pieceMenu.Count);

        int i = 0;

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


            if (i == queenListPosition)
            {


                oppQueenPosition = availableTiles[Random.Range(0, availableTiles.Count)];

                chessBoard.setQueenPosition(oppQueenPosition);
            }


            int randomPosition = Random.Range(0, availableTiles.Count);
            while (availableTiles[randomPosition] == oppQueenPosition)
            {
                randomPosition = Random.Range(0, availableTiles.Count);
            }

            prevPosition = availableTiles[randomPosition];
            i++;


        }
        endPosition = prevPosition;
        chessBoard.SetEndGoalTile((int)endPosition.x, (int)endPosition.z);
    }


    public GameObject GetOppQueen()
    {
        return oppQueen;
    }


    public List<GameObject> GetPieceMenu()
    {
        return pieceMenu;
    }

    public int GetTotalPieces()
    {
        return totalPieces;
    }


}