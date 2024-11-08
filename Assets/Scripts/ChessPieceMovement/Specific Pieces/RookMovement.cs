using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookMovement : MonoBehaviour
{
    private float speed = 3f;  
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
            target.x = 7;
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

    public List<Vector3> CheckAvailableTiles()
    {
        List<Vector3> availableTiles = new List<Vector3>();
        Vector3 target = transform.position;

        availableTiles.Add(new Vector3(target.x, target.y, 7));
        availableTiles.Add(new Vector3(target.x, target.y, 0));
        availableTiles.Add(new Vector3(7, target.y, target.z));
        availableTiles.Add(new Vector3(0, target.y, target.z));

        return availableTiles;
    }
}
