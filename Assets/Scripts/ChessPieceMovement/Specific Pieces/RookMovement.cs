using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookMovement : MonoBehaviour, ChessPieceMovement
{
    public float speed { get { return 7f; } }
    public bool isMoving { get; set; }
    public ChessBoard chessBoard { get; set; }

    [SerializeField] PieceStatus pieceStatus;
    [SerializeField] SelectPiece selectPiece;
    private SceneManagement sceneManagement;
    private MusicManagement musicManagement;
    public GameObject oppQueen;

    private bool hasMoved = false;

    private Vector3[] rookMoves = new Vector3[] {
        Vector3.forward, Vector3.back, Vector3.left, Vector3.right
    };

    void Start()
    {
        selectPiece = FindAnyObjectByType<SelectPiece>();
        chessBoard = FindAnyObjectByType<ChessBoard>();
        pieceStatus = FindAnyObjectByType<PieceStatus>();
        sceneManagement = FindAnyObjectByType<SceneManagement>();
        musicManagement = FindAnyObjectByType<MusicManagement>();
    }

    public List<Vector3> CheckAvailableMoves(Vector3 position)
    {
        List<Vector3> availableMoves = new List<Vector3>();

        foreach (Vector3 direction in rookMoves)
        {
            Vector3 targetPosition = position;

            while (IsValidPosition(targetPosition + direction))
            {
                targetPosition += direction;
            }
            if (targetPosition != position)
            {
                availableMoves.Add(targetPosition);
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
            if (selectPiece.IsLastPiece() && oppQueen == null)
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
