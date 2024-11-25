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
    public int totalPieces;


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

            for (int i = 0; i < randomAmount; i++)
            {
                int randomPiece = Random.Range(0, pieces.Count);
                pieceMenu.Add(pieces[randomPiece]);
            }
        }

        return pieceMenu;

    }

    public void CreateEndGoal()
    {
        CreatePieceMenu();

        
        Vector3 endPosition = chessBoard.GetStartTilePosition();

        Vector3 prevPosition = chessBoard.GetStartTilePosition();
        string prevPieceType = "";

        //while (oppQueenPosition == prevPosition || oppQueenPosition == new Vector3(7, 0, 7))
        //{
        //    oppQueenPosition = new Vector3(Random.Range(0, 8), 0, Random.Range(0, 8));
        //    oppQueen = Instantiate(oppQueenPrefab, oppQueenPosition, Quaternion.identity);
        //}


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

          

            int randomPosition = Random.Range(0, availableTiles.Count);

            while(prevPosition == new Vector3(7,0,7))
            prevPosition = availableTiles[randomPosition];
            
        

            //Debug.Log(prevPosition.ToString());

        }
        endPosition = prevPosition;
        chessBoard.SetEndGoalTile((int)endPosition.x, (int)endPosition.z);
        
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
