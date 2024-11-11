using System.Collections.Generic;
using UnityEngine;

public class ShowAvailableTiles : MonoBehaviour
{
    [SerializeField] ChessPieceMovement pieceMovement;
    [SerializeField] GameObject piece;
    [SerializeField] GameObject availableTileLight;
    private float lightHeight = 1.5f;

    void Start()
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

        
        List<Vector3> avilableTiles = pieceMovement.CheckAvailableMoves(piece.transform.position);
        foreach (Vector3 tilePos in avilableTiles)
        {
            Instantiate(availableTileLight);//piece.transform
            availableTileLight.transform.position = new Vector3(tilePos.x, lightHeight, tilePos.z);
            //availableTileLight.transform.parent = piece.transform;
        }
    }

    void Update()
    {
        
    }
}
