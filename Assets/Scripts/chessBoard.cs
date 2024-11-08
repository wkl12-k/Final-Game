using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject whiteBoardTile;
    public GameObject blackBoardTile;

    [Header("Grid Creation")]
    [SerializeField] private int gridSize = 8;
    [SerializeField] private int tileSize = 1;
    [SerializeField] private float y = 0.1f;

    private GameObject[,] tiles;
    private Vector2 boardDimensions;

    private KingMovement selectedKing;  

    void Start()
    {
        CreateBoard();
    }

    void Update()
    {
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
        Vector3 tilePosition = tile.transform.position;

        if (selectedKing != null)
        {
            if (selectedKing.CheckAvailableMoves().Contains(tilePosition))
            {
                selectedKing.MoveToTile(tilePosition);
                selectedKing = null;  
            }
            else
            {
                Debug.Log("Invalid move. King cannot move there.");  
            }
        }
    }



    public void SetSelectedKing(KingMovement king)
    {
        selectedKing = king;
    }
}
