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
        target.z -= 2; // moving one square will be -2
        target.x -= 2;

        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }


    }

    public float[][] CheckAvailableTiles()
    {
        return new float[3][];
    }

}
