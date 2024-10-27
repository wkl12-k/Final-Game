using UnityEngine;
using System.Collections;

public class KingMovement : MonoBehaviour, ChessPieceMovement
{
    [SerializeField] float speed = 1;
    private Vector3 position;
    private float tileSize = 2f;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move();
        }
    }

    public void Move()
    {
        Vector3 target = GetTargetPos();

        if (target != Vector3.zero) // Ensure target is valid
        {
            StartCoroutine(MoveToTarget(target));
        }
    }

    private Vector3 GetTargetPos()
    {
        Vector3 target = transform.position + new Vector3(-tileSize, 0, -tileSize); // Example diagonal move
        return target;
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    public float[][] CheckAvailableTiles()
    {
        return new float[3][];
    }

}
