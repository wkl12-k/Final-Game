using UnityEngine;

public interface ChessPieceMovement
{
    public void Move()
    {
        
    }

    public float[][] CheckAvailableTiles()
    {
        return new float[3][];
    }
}
