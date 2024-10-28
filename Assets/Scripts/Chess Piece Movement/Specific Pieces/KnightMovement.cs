using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KnightMovement : MonoBehaviour, ChessPieceMovement
{

    [SerializeField] float speed = 1;
    private Vector3 currentPosition;
    private int boardSize = 8;


     private Vector3[] knightMoves = new Vector3[] {new Vector3(2, 0, 1), new Vector3(2, 0, -1),new Vector3(-2, 0, 1), new Vector3(-2, 0, -1),
        new Vector3(1, 0, 2), new Vector3(-1, 0, 2), new Vector3(1, 0, -2), new Vector3(-1, 0, -2)
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector3.left);
        }

    }


    private bool IsValidMove(Vector3 targetPosition)
    {
        return CheckAvailableMoves().Contains(targetPosition);
    }


    private bool IsOnBoard(Vector3 targetPosition)
    {
        return targetPosition.x >= 1 && targetPosition.x <= boardSize && targetPosition.z >= 1 && targetPosition.z <= boardSize;
    }


    private IEnumerator MoveTowardsTarget(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        currentPosition = targetPosition;
    }





    public void Move(Vector3 targetPosition)
    {
        if (IsValidMove(targetPosition))
        {
            StartCoroutine(MoveTowardsTarget(targetPosition));
        }
        else
        {
            return;
        }
    }

    public List<Vector3> CheckAvailableMoves()
    {
        List<Vector3> availableMoves = new List<Vector3>();

        foreach (Vector3 move in knightMoves)
        {
            Vector3 availablePosition = currentPosition + move;
            if (IsOnBoard(availablePosition))
            {
                availableMoves.Add(availablePosition);
            }
        }
        return availableMoves;
    }
}
