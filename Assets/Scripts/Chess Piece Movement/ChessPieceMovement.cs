using UnityEngine;

public interface ChessPieceMovement
{
    void Move();
    float[][] CheckAvailableTiles();
}
