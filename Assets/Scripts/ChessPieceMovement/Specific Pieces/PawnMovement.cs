using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PawnMovement : MonoBehaviour, ChessPieceMovement
{
    public float speed => pieceSpeed;
    public bool isMoving { get; set; }
    public ChessBoard chessBoard { get; set; }

    [SerializeField] private float pieceSpeed = 1f;

    private Vector3[] pawnMoves = new Vector3[]
    {
        Vector3.forward, Vector3.back  
    };

    void Start()
    {
        chessBoard = FindAnyObjectByType<ChessBoard>();
    }

    public List<Vector3> CheckAvailableMoves(Vector3 position)
    {
        List<Vector3> availableMoves = new List<Vector3>();

        foreach (Vector3 move in pawnMoves)
        {
            Vector3 availablePosition = position + move;
            if (IsValidPosition(availablePosition))
            {
                availableMoves.Add(availablePosition);
            }
        }
        return availableMoves;
    }

    public void Move(Vector3 targetPosition)
    {
        if (CheckAvailableMoves(transform.position).Contains(targetPosition))
        {
            chessBoard.StartCoroutine(MoveToTarget(targetPosition));
        }
        else
        {
            Debug.Log("Invalid move.");
        }
    }

    public IEnumerator MoveToTarget(Vector3 target)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
        isMoving = false;
    }

    protected bool IsValidPosition(Vector3 targetPosition)
    {
        const float minX = 0f;
        const float maxX = 7f;
        const float minZ = 0f;
        const float maxZ = 7f;

        return targetPosition.x >= minX && targetPosition.x <= maxX && targetPosition.z >= minZ && targetPosition.z <= maxZ;
    }

    protected void OnMouseDown()
    {
        chessBoard.SetSelectedPiece((ChessPieceMovement)this);
    }

   
}
