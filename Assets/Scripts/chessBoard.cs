using UnityEngine;

public class chessBoard : MonoBehaviour
{
    public GameObject whiteBoardTile;
    public GameObject blackBoardTile;
    int gridSize =8;
    float tileCubicSize = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateBoard();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBoard()
    {
        for (int i=1; i<=gridSize; i++)
        {
            for(int j=1; j<=gridSize; j++)
            {
                GameObject tile;
                if ((i+j)% 2 == 0)
                {
                    tile = Instantiate(whiteBoardTile, new Vector3(i * tileCubicSize, 0, j * tileCubicSize), Quaternion.identity);
                }
                else
                {
                    tile = Instantiate(blackBoardTile, new Vector3(i * tileCubicSize, 0, j * tileCubicSize), Quaternion.identity);
                }

                tile.transform.parent = transform;
            }
        }
    }
}
