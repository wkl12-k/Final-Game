using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class ChessBoard : MonoBehaviour
{
    public static event Action OnBoardCreated;
    public MusicManagement musicManager;

    [Header("Game Objects")]
    public GameObject whiteBoardTile;
    public GameObject blackBoardTile;

    public chessPuzzleSpawner chessSpawner = null;
    [SerializeField] PieceButtons pieceButtons = null;

    [Header("Grid Creation")]
    [SerializeField] private int gridSize = 8;
    [SerializeField] private int tileSize = 1;
    [SerializeField] private float y = 0.1f;

    private GameObject[,] tiles;
    private ChessPieceMovement selectedPiece;
    

    void Start()
    {
        CreateBoard();
        OnBoardCreated?.Invoke();

        if (chessSpawner != null && pieceButtons != null)
        {
            StartCoroutine(SetEndGoalAfterBoardCreated());
        }
    }

    private IEnumerator SetEndGoalAfterBoardCreated()
    {
        yield return new WaitForEndOfFrame(); 
        chessSpawner.CreateEndGoal();

        List<GameObject> pieceMenu = chessSpawner.GetPieceMenu();
        pieceButtons.CreatePieceMenu(pieceMenu);
    }

    public Vector3 GetStartTilePosition()
    {
        if (tiles != null && tiles[7, 7] != null)
        {
            return tiles[7, 7].transform.position;
        }
        else
        {
            return Vector3.zero; 
        }
    }



    public void CreateBoard()
    {
        tiles = new GameObject[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                GameObject tile;

                if ((x + z) % 2 == 0)
                {
                    tile = Instantiate(whiteBoardTile, new Vector3(x * tileSize, y, z * tileSize), Quaternion.identity);
                }
                else
                {
                    tile = Instantiate(blackBoardTile, new Vector3(x * tileSize, y, z * tileSize), Quaternion.identity);
                }



                tile.transform.parent = transform;

                Tile tileComponent = tile.GetComponent<Tile>();
                tileComponent.chessBoard = this;

               

                tiles[x, z] = tile;
            }
        }
    }

   

    public void OnTileClicked(Tile tile)
    {
        Vector3 tilePosition = new Vector3(Mathf.Round(tile.transform.position.x), tile.transform.position.y, Mathf.Round(tile.transform.position.z));

        if (selectedPiece != null)
        {
            List<Vector3> validMoves = selectedPiece.CheckAvailableMoves(transform.position);
            if (IsValidMove(tilePosition, validMoves))
            {
                selectedPiece.Move(tilePosition);
                selectedPiece = null;
                //musicManager.PlayChessMoveSound();
            }
            else
            {
                Debug.Log("Invalid move.");
            }
        }
    }

    private bool IsValidMove(Vector3 tilePosition, List<Vector3> validMoves)
    {
        foreach (Vector3 move in validMoves)
        {
            if (Mathf.Approximately(tilePosition.x, move.x) && Mathf.Approximately(tilePosition.z, move.z))
            {
                return true;
            }
        }
        return false;
    }

    public void SetSelectedPiece(ChessPieceMovement piece)
    {
        selectedPiece = piece;
    }

    public Tile SetEndGoalTile(int x, int z)
    {
        Tile endGoalTile = null;

        if (x >= 0 && x < gridSize && z >= 0 && z < gridSize)
        {
            endGoalTile = tiles[x, z].GetComponent<Tile>();
            if (endGoalTile != null)
            {
                endGoalTile.SetEndGoal();
            }
        }
        return endGoalTile;
    }
}

