using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KingMovement : MonoBehaviour, ChessPieceMovement
{
    [SerializeField] private float speed = 3f;
    private const float tileSize = 1f;
    private const float maxX = 7f;
    private const float minX = 0f;
    private const float maxZ = 7f;
    private const float minZ = 0f;
    private bool isMoving;
    private Vector3[] kingMoves = new Vector3[] {Vector3.back, Vector3.forward, Vector3.left, Vector3.right,
        new Vector3(1, 0, -1), new Vector3(-1, 0, -1), new Vector3(1, 0, 1), new Vector3(-1, 0, 1)};

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(Vector3.back);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                Move(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.A)) // Move Left
            {
                Move(Vector3.right);
            }
            else if (Input.GetKeyDown(KeyCode.D)) // Move Right
            {
                Move(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.Q)) // Move Diagonal Up-Left
            {
                Move(new Vector3(1, 0, -1));
            }
            else if (Input.GetKeyDown(KeyCode.E)) // Move Diagonal Up-Right
            {
                Move(new Vector3(-1, 0, -1));
            }
            else if (Input.GetKeyDown(KeyCode.Z)) // Move Diagonal Down-Left
            {
                Move(new Vector3(1, 0, 1));
            }
            else if (Input.GetKeyDown(KeyCode.C)) // Move Diagonal Down-Right
            {
                Move(new Vector3(-1, 0, 1));
            }
        }
    }

    private Vector3 GetTargetPos(Vector3 direction)
    {
        float targetX = transform.position.x + direction.x * tileSize;
        float targetZ = transform.position.z + direction.z * tileSize;

        return new Vector3(targetX, transform.position.y, targetZ);
    }

    public void Move(Vector3 direction)
    {
        Vector3 target = GetTargetPos(direction);
        isMoving = true;

        if (IsValidPosition(target) && target != transform.position)
        {
            StartCoroutine(MoveToTarget(target));
        }
        else
        {
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

}
