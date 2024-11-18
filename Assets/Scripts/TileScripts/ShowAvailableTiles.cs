using System.Collections.Generic;
using UnityEngine;

public class ShowAvailableTiles : MonoBehaviour
{
    [SerializeField] ChessPieceMovement pieceMovement;
    [SerializeField] GameObject piece;
    [SerializeField] GameObject availableTileLight;

    private List<GameObject> lights = new List<GameObject>();
    private PieceStatus pieceStatus;
    private float lightHeight = 1.5f;
    private Vector3 startPos;

    void Start()
    {
        
        startPos = piece.transform.position;

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


        
        List<Vector3> avilableTiles = pieceMovement.CheckAvailableMoves(piece.transform.position); //piece.transform.position


        foreach (Vector3 tilePos in avilableTiles)
        {
            GameObject tileLight = Instantiate(availableTileLight);
            tileLight.transform.position = new Vector3(tilePos.x, lightHeight, tilePos.z);
            lights.Add(tileLight);
        }
    }

    void Update()
    {
        if (piece.transform.position != startPos) 
        {
            DestroyTileLights();
        }
    }

    public void DestroyTileLights()
    {
        foreach (GameObject light in lights)
        {
            Destroy(light);
        }
    }
}
