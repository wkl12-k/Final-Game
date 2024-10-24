using UnityEngine;
using System.Collections;

public class RookMovement : MonoBehaviour, ChessPieceMovement
{
    private Vector3 position;
    [SerializeField] float speed;
    [SerializeField] Transform movePoint;
    void Start()
    {
        position = transform.position;
        
    }   

    void Update()
    {

    }

    public void Move()
    {

    }

    public float[][] CheckAvailableTiles()
    {
        return new float[3][];
    }

}
