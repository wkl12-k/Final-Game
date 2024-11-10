using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour, ChessPieceMovement
{
    public float speed => pieceSpeed;
    public bool isMoving { get; set; }
    public ChessBoard chessBoard { get; set; }

    [SerializeField] private float pieceSpeed = 1f;

    private Vector3[] bishopDirections = new Vector3[]
    {
        new Vector3(1, 0, 1),  
        new Vector3(-1, 0, 1),  
        new Vector3(1, 0, -1), 
        new Vector3(-1, 0, -1)  
    };

    void Start()
    {
        chessBoard = FindAnyObjectByType<ChessBoard>();
    }

    public List<Vector3> CheckAvailableMoves()
    {
        List<Vector3> availableMoves = new List<Vector3>();

        foreach (Vector3 direction in bishopDirections)
        {
            AddMovesInDirection(availableMoves, direction);
        }

        return availableMoves;
    }

    public void Move(Vector3 targetPosition)
    {
        if (CheckAvailableMoves().Contains(targetPosition))
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

    private void AddMovesInDirection(List<Vector3> availableMoves, Vector3 direction)
    {
        Vector3 targetPosition = transform.position;
        Vector3 validPosition = targetPosition;

        
        while (IsValidPosition(targetPosition + direction))
        {
            targetPosition += direction;
            validPosition = targetPosition;  
        }

        
        if (validPosition != transform.position)
        {
            availableMoves.Add(validPosition);
        }
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
        chessBoard.SetSelectedPiece(this);
    }

    public List<Vector3> CheckAvailableMoves(Vector3 pos)
    {
        throw new System.NotImplementedException();
    }
}
