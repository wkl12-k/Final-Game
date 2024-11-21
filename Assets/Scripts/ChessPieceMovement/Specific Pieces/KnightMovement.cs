using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour, ChessPieceMovement
{
    [SerializeField] PieceStatus pieceStatus;

    public float speed => pieceSpeed;
    public bool isMoving { get; set; }
    public ChessBoard chessBoard { get; set; }

    [SerializeField] private float pieceSpeed = 1f;
    private SceneManagement sceneManagement;

    private Vector3[] knightMoves = new Vector3[] {
        new Vector3(2, 0, 1), new Vector3(2, 0, -1),
        new Vector3(-2, 0, 1), new Vector3(-2, 0, -1),
        new Vector3(1, 0, 2), new Vector3(1, 0, -2),
        new Vector3(-1, 0, 2), new Vector3(-1, 0, -2)
    };

    void Start()
    {
        chessBoard = FindAnyObjectByType<ChessBoard>();
        pieceStatus = FindAnyObjectByType<PieceStatus>();
        sceneManagement = FindAnyObjectByType<SceneManagement>();  
    }

    public List<Vector3> CheckAvailableMoves(Vector3 position)
    {
        List<Vector3> availableMoves = new List<Vector3>();

        foreach (Vector3 move in knightMoves)
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
            StartCoroutine(MoveToTarget(targetPosition));
        }
        else
        {
            Debug.Log("Invalid move.");
        }
    }

    public IEnumerator MoveToTarget(Vector3 target)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
        isMoving = false;
        pieceStatus.SetPieceStatus(false);
        if (pieceStatus.allowEndGoal && target == chessBoard.EndGoalPosition)
        {
            OnEndGoalReached();
        }
    }

    private void OnEndGoalReached()
    {
        Debug.Log("End goal reached!");
        sceneManagement.toLevel("WinScene");
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

