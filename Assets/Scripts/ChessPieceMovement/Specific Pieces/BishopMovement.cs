using UnityEngine;
using System.Collections;

public class BishopMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    private Vector3 position;

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
        Vector3 target = transform.position;
        target.z += 1; // moving one square will be -2
        target.x += 1;

        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }


    }

    public float[][] CheckAvailableTiles(Vector3 pos)
    {
        return new float[3][];
    }

}
