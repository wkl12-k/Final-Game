using UnityEngine;

public interface ChessPiece
{
    public void Move()
    {
        
    }

    public float[][] CheckAvailableTiles()
    {
        return new float[3][];
    }
}
