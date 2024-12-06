using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.SceneManagement;


public class chessBoard : MonoBehaviour
{
    public static event Action OnBoardCreated;
    public MusicManagement musicManager;

    [Header("Game Objects")]
    public GameObject whiteBoardTile;
    public GameObject blackBoardTile;
    [SerializeField] GameObject endLight;
    private float lightHeight = 1.5f;

    public ChessPuzzleSpawner chessPuzzleSpawner;

    public ChessPuzzleSpawner chessSpawner = null;
    [SerializeField] PieceButtons pieceButtons = null;

    [Header("Grid Creation")]
    [SerializeField] private int gridSize = 8;
    [SerializeField] private int tileSize = 1;
    [SerializeField] private float y = 0.1f;

    [SerializeField] GameObject oppQueenPrefab;

    private Vector3 oppQueenPosition;
    private GameObject oppQueen;
    private bool queenDestroyed;


    private GameObject[,] tiles;
    private ChessPieceMovement selectedPiece;
    private Vector3 endGoalPosition;


    void Start()
    {

        endLight.SetActive(false);
        CreateBoard();
        OnBoardCreated?.Invoke();
        

        //if (SceneManager.GetActiveScene().name == "TutorialLevel")
        //{
        //    StartCoroutine(SetGoalsForTutorialLevel());
        //}

    if (chessSpawner != null && pieceButtons != null)
        {
            StartCoroutine(SetGoalsAfterBoardCreated());
            //StartCoroutine(SetQueenAfterBoardCreated());
        }


    }

    private IEnumerator SetGoalsAfterBoardCreated()
    {
        yield return new WaitForEndOfFrame();
        

        SetStartTile(7, 7);
        
        chessSpawner.CreateEndGoal();

        List<GameObject> pieceMenu = chessSpawner.GetPieceMenu();
        pieceButtons.CreatePieceMenu(pieceMenu);
        StartCoroutine(SetQueenAfterBoardCreated());
    }

    private IEnumerator SetGoalsForTutorialLevel()
    {
        yield return new WaitForEndOfFrame();

        SetStartTile(7, 7);
        SetEndGoalTile(3, 7);

    }

    private IEnumerator SetQueenAfterBoardCreated()
    {
        yield return new WaitForEndOfFrame();
        
            Quaternion uprightRotation = Quaternion.Euler(-90, 90, 0);
            Debug.Log("queen in chess board" + oppQueenPosition);
            oppQueen = Instantiate(oppQueenPrefab, oppQueenPosition, uprightRotation);
            oppQueen.SetActive(true);
        
        
    }

    public void ResetQueenOnRestart()
    {
        if (oppQueen == null)
        {
            StartCoroutine(SetQueenAfterBoardCreated());
        }
        
    }

    public void setQueenPosition(Vector3 position)
    {
        oppQueenPosition = position;
    }

  public void KillQueen(Vector3 position)
    {
        if (position == oppQueenPosition)
        {
            Destroy(oppQueen);
            oppQueen = null;
            queenDestroyed = true;
        }
    }


    public bool IsQueenDestroyed()
    {
        return queenDestroyed;
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
            selectedPiece.Move(tilePosition);
            
        }
    }

    public void SetSelectedPiece(ChessPieceMovement piece)
    {
        selectedPiece = piece;
    }

    public Tile SetStartTile(int x, int z)
    {
        Tile startTile = null;

        if (x >= 0 && x < gridSize && z >= 0 && z < gridSize)
        {
            startTile = tiles[x, z].GetComponent<Tile>();
            if (startTile != null)
            {
                startTile.setStartTileColor();
            }
        }
        return startTile;
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
                endGoalPosition = endGoalTile.transform.position;
            }
        }

        
        endLight.transform.position = new Vector3(x, lightHeight, z);
        endLight.SetActive(true);

        return endGoalTile;
    }

    public Vector3 EndGoalPosition
    {
        get { return endGoalPosition; }
    }
}

