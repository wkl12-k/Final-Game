using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KingMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private const float tileSize = 1f;
    private const float maxX = 7f;
    private const float minX = 0f;
    private const float maxZ = 7f;
    private const float minZ = 0f;
    private bool isMoving;
    private ChessBoard chessBoard;

    private Vector3[] kingMoves = new Vector3[] {
        Vector3.back, Vector3.forward, Vector3.left, Vector3.right,
        new Vector3(1, 0, -1), new Vector3(-1, 0, -1),
        new Vector3(1, 0, 1), new Vector3(-1, 0, 1)
    };

    void Start()
    {
        chessBoard = FindObjectOfType<ChessBoard>();
    }

    void Update()
    {
    }

    public void Move(Vector3 target)
    {
        isMoving = true;

        if (IsValidPosition(target) && target != transform.position)
        {
            StartCoroutine(MoveToTarget(target));
        }
        else
        {
            Debug.Log("Invalid position or no movement required."); // Log if invalid
            isMoving = false;
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
        isMoving = false;
    }

    private bool IsValidPosition(Vector3 target)
    {
        return target.x >= minX && target.x <= maxX && target.z >= minZ && target.z <= maxZ;
    }

    public List<Vector3> CheckAvailableMoves()
    {
        List<Vector3> availableMoves = new List<Vector3>();

        foreach (Vector3 move in kingMoves)
        {
            Vector3 availablePosition = transform.position + move;
            if (IsValidPosition(availablePosition))
            {
                availableMoves.Add(availablePosition);
            }
        }
        return availableMoves;
    }

    public void MoveToTile(Vector3 tilePosition)
    {
        Move(tilePosition);
    }

    void OnMouseDown()
    {
        chessBoard.SetSelectedKing(this);
    }
}
