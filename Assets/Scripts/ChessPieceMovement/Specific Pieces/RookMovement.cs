using UnityEngine;
using System.Collections;

public class RookMovement : MonoBehaviour
{
    private float speed = 3f;  
    private const int boardSize = 5;  
    private const float tileSize = 2f;
    private bool isMoving;

    void Update()
    {
        if (isMoving == false) {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move(Vector3.forward);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(Vector3.right);
            }
        }
    }

    private Vector3 GetTargetPos(Vector3 direction)
    {
        Vector3 target = transform.position;

        if (direction == Vector3.back)  
        {
            target.z = 7;
        }
        else if (direction == Vector3.forward)  
        {
            target.z = 0;
        }
        else if (direction == Vector3.right)  
        {
            target.x = 0;
        }
        else if (direction == Vector3.left)  
        {
            target.x = 0;
        }

        return target;
    }

    public void Move(Vector3 direction)
    {
        Vector3 target = GetTargetPos(direction);
        isMoving = true;

        if (target != transform.position)
        {
            StartCoroutine(MoveToTarget(target));
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

    public float[][] CheckAvailableTiles()
    {
        return new float[0][];
    }
}
