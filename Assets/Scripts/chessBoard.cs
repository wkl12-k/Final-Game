using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject whiteBoardTile;
    public GameObject blackBoardTile;
    [SerializeField] private Material tileMaterial;

    [Header("Grid Creation")]
    [SerializeField] private int gridSize = 8;
    [SerializeField] private int tileSize = 1;
    [SerializeField] private float y = 0.1f;

    private GameObject[,] tiles;
    private Vector2 boardDimensions;  

    void Start()
    {
        CreateBoard();
        //CalculateBoardDimensions();
    }

    void Update()
    {
        
    }

    public void CreateBoard()
    {
        tiles = new GameObject[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for(int z = 0; z < gridSize; z++)
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

                tiles[x, z] = tile;
            }
        }
    }

    //private void CalculateBoardDimensions()
    //{
    //    boardDimensions = new Vector2(gridSize * tileCubicSize, gridSize * tileCubicSize);
    //}

    //public Vector2 GetBoardDimensions()
    //{
    //    return boardDimensions;
    //}

}
