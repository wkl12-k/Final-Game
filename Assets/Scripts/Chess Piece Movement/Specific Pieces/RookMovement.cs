using UnityEngine;
using System.Collections;

public class RookMovement : MonoBehaviour, ChessPieceMovement
{
    [SerializeField] float speed = 0.2f;
    private Vector3 position;

    void Start()
    {
        position = transform.position;
    }   

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Move();
        }
    }

    public void Move()
    {
        Vector3 target = transform.position;
        target.z -= 2;
        target.x -= 2;

        //StartCoroutine("MoveRoutine");
        //.position = transform.position;
        while (transform.position != target) {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        
    }

    public IEnumerator MoveRoutine()
    {
        Vector3 target = transform.position;
        target.z -= 2;
        target.x -= 2;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        yield return null;
    }

    public float[][] CheckAvailableTiles()
    {
        return new float[3][];
    }

}
