using System.Collections.Generic;
using UnityEngine;

public class chessPuzzleSpawner : MonoBehaviour
{

    [Header("Piece Prefabs")]
    public GameObject rookPrefab;
    public GameObject bishopPrefab;
    public GameObject kingPrefab;
    public GameObject knightPrefab;
    public GameObject pawnPrefab;


    [SerializeField] ChessPieceMovement pieceMovement;

    






    public ChessBoard chessBoard;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<GameObject> CreatePieceMenu()
    {
        List<GameObject> pieceMenu = new List<GameObject>();
        pieceMenu.Clear();
        int randomAmount = Random.Range(4, 8);
        List<GameObject> pieces = new List<GameObject> { rookPrefab, bishopPrefab, knightPrefab, kingPrefab };

        for (int i = 0; i < randomAmount; i++)
        {
            int randomPiece = Random.Range(0, pieces.Count);
            pieceMenu.Add(pieces[randomPiece]);
        }

        return pieceMenu;

    }


    public void CreateEndGoal()
    {

       List<GameObject> pieceMenu=CreatePieceMenu();
       
        Vector3 prevPosition=chessBoard.GetStartTilePosition();
      
        


        foreach (GameObject piece in pieceMenu)
        {
            if (piece.CompareTag("rook"))
            {
                pieceMovement = GetComponent<RookMovement>();
            }
            else if (piece.CompareTag("king"))
            {
                pieceMovement = GetComponent<KingMovement>();
            }
            else if (piece.CompareTag("bishop"))
            {
                pieceMovement = GetComponent<BishopMovement>();
            }
            else if (piece.CompareTag("pawn"))
            {
                pieceMovement = GetComponent<PawnMovement>();
            }
            else if (piece.CompareTag("knight"))
            {
                pieceMovement = GetComponent<KnightMovement>();
            }

            List<Vector3> availableTiles = pieceMovement.CheckAvailableMoves(prevPosition);
            


            int randomPosition = Random.Range(0, availableTiles.Count);
            prevPosition = availableTiles[randomPosition];

            Debug.Log(prevPosition.ToString());
            
        }
        chessBoard.SetEndGoalTile((int)prevPosition.x, (int)prevPosition.z);



    }

   

  

}
