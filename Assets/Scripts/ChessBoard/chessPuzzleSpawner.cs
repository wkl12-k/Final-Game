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
    [SerializeField] GameObject oppQueenPrefab;

    private Vector3 oppQueenPosition;
    private GameObject oppQueen;
    private int totalPieces;
    private int pawnCount=0;
    private int kingCount=0;
    private int otherPieceCount=0;


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


    //public void CreateEndGoal()
    //{
    //    CreatePieceMenu();


    //    Vector3 endPosition = chessBoard.GetStartTilePosition();

    //    Vector3 prevPosition = chessBoard.GetStartTilePosition();
    //    string prevPieceType = "";


    //    //while (oppQueenPosition == prevPosition || oppQueenPosition == new Vector3(7, 0, 7))
    //    //{
    //    //    oppQueenPosition = new Vector3(Random.Range(0, 8), 0, Random.Range(0, 8));
    //    //    oppQueen = Instantiate(oppQueenPrefab, oppQueenPosition, Quaternion.identity);
    //    //}


    //    foreach (GameObject piece in pieceMenu)
    //    {

    //        if (piece.CompareTag("rook"))
    //        {
    //            pieceMovement = piece.GetComponent<RookMovement>();
    //        }
    //        else if (piece.CompareTag("king"))
    //        {
    //            pieceMovement = piece.GetComponent<KingMovement>();
    //        }
    //        else if (piece.CompareTag("bishop"))
    //        {
    //            pieceMovement = piece.GetComponent<BishopMovement>();
    //        }
    //        else if (piece.CompareTag("pawn"))
    //        {

    //            pieceMovement = piece.GetComponent<PawnMovement>();

    //        }
    //        else if (piece.CompareTag("knight"))
    //        {
    //            pieceMovement = piece.GetComponent<KnightMovement>();
    //        }



    //        List<Vector3> availableTiles = pieceMovement.CheckAvailableMoves(prevPosition);



    //        int randomPosition = Random.Range(0, availableTiles.Count);

    //        while(prevPosition == new Vector3(7,0,7))
    //        prevPosition = availableTiles[randomPosition];



    //        Debug.Log(prevPosition.ToString());

    //    }
    //    endPosition = prevPosition;
    //    chessBoard.SetEndGoalTile((int)endPosition.x, (int)endPosition.z);
    //}

    public void CreateEndGoal()
    {
        CreatePieceMenu();

        Vector3 endPosition = chessBoard.GetStartTilePosition();
        Vector3 prevPosition = chessBoard.GetStartTilePosition();
        string prevPieceType = "";

        // Debug log when the piece menu is created
        Debug.Log("Piece Menu Created with " + pieceMenu.Count + " pieces.");

        foreach (GameObject piece in pieceMenu)
        {
            // Debug log which piece is currently being processed
            Debug.Log("Processing piece: " + piece.name);

            if (piece.CompareTag("rook"))
            {
                pieceMovement = piece.GetComponent<RookMovement>();
                Debug.Log("Piece is Rook.");
            }
            else if (piece.CompareTag("king"))
            {
                pieceMovement = piece.GetComponent<KingMovement>();
                Debug.Log("Piece is King.");
            }
            else if (piece.CompareTag("bishop"))
            {
                pieceMovement = piece.GetComponent<BishopMovement>();
                Debug.Log("Piece is Bishop.");
            }
            else if (piece.CompareTag("pawn"))
            {
                pieceMovement = piece.GetComponent<PawnMovement>();
                Debug.Log("Piece is Pawn.");
            }
            else if (piece.CompareTag("knight"))
            {
                pieceMovement = piece.GetComponent<KnightMovement>();
                Debug.Log("Piece is Knight.");
            }

            // Get available moves
            List<Vector3> availableTiles = pieceMovement.CheckAvailableMoves(prevPosition);

            // Debug log the available moves
            if (availableTiles.Count > 0)
            {
                Debug.Log("Available moves for " + piece.name + ":");
                foreach (Vector3 move in availableTiles)
                {
                    Debug.Log("  " + move.ToString());
                }
            }
            else
            {
                Debug.Log("No available moves for " + piece.name);
            }

            // Randomly select a position
            int randomPosition = Random.Range(0, availableTiles.Count);

            // Debug log the randomly selected position
            Debug.Log("Randomly selected position: " + availableTiles[randomPosition].ToString());

            // Prevent selecting certain positions like (7,0,7)
            while (prevPosition == new Vector3(7, 0, 7))
            {
                prevPosition = availableTiles[randomPosition];
                Debug.Log("Selected position was (7,0,7), trying again: " + prevPosition.ToString());
            }

            prevPosition = availableTiles[randomPosition];

            // Debug log the final chosen position for the piece
            Debug.Log("Final chosen position for " + piece.name + ": " + prevPosition.ToString());
        }

        // Set the end position on the chess board
        endPosition = prevPosition;
        chessBoard.SetEndGoalTile((int)endPosition.x, (int)endPosition.z);

        // Debug log the final end position
        Debug.Log("End position set at: " + endPosition.ToString());
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
