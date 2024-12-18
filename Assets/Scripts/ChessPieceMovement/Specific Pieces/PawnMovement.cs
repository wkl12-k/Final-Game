using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PawnMovement : MonoBehaviour, ChessPieceMovement
{
    public float speed { get { return 7f; } }
    public bool isMoving { get; set; }
    public chessBoard chessBoard { get; set; }

    [SerializeField] PieceStatus pieceStatus;
    [SerializeField] SelectPiece selectPiece;
    private SceneManagement sceneManagement;
    private MusicManagement musicManagement;

    public GameObject oppQueen;

    private bool hasMoved = false;

    private Vector3[] pawnMoves = new Vector3[]
    {
        Vector3.forward, Vector3.back  
    };

    void Start()
    {
        selectPiece = FindAnyObjectByType<SelectPiece>();
        chessBoard = FindAnyObjectByType<chessBoard>();
        pieceStatus = FindAnyObjectByType<PieceStatus>();
        sceneManagement = FindAnyObjectByType<SceneManagement>();
        musicManagement = FindAnyObjectByType<MusicManagement>();
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
        if (CheckAvailableMoves(transform.position).Contains(targetPosition) && !hasMoved)
        {
            hasMoved = true;
            chessBoard.StartCoroutine(MoveToTarget(targetPosition));
            musicManagement.PlayChessMoveSound();
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
        chessBoard.KillQueen(target);
        isMoving = false;
        pieceStatus.SetPieceStatus(false);
        if (target == chessBoard.EndGoalPosition)
        {
            if (selectPiece.IsLastPiece() && chessBoard.IsQueenDestroyed())
            {
                musicManagement.PlayReachedGoalSound();
                OnEndGoalReached();
            }
        }
    }

    private void OnEndGoalReached()
    {
        if (sceneManagement.GetCurrentScene() == "TutorialLevel")
        {
            sceneManagement.toLevel("TutorialCompleted");
        }
        else
        {
            sceneManagement.toLevel("WinScene");
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
        chessBoard.SetSelectedPiece((ChessPieceMovement)this);
    }

   
}
