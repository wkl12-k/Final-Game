using UnityEngine;
using System.Collections;

public class KingMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private const float tileSize = 2f;  
    private const float minX = -9f;
    private const float maxX = -1f;
    private const float minZ = -9f;
    private const float maxZ = -1f;
    private bool isMoving;

    void Update()
    {
        if (isMoving == false)
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
        return target.x >= -9 && target.x <= -1 && target.z >= -9 && target.z <= -1;
    }

    public float[][] CheckAvailableTiles()
    {
        return new float[0][];
    }
}