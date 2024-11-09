using System.Collections.Generic;
using UnityEngine;

public interface ChessPieceMovement
{
    void Move(Vector3 targetPosition);
    List<Vector3> CheckAvailableMoves(Vector3 pos);
    List<Vector3> CheckAvailableMoves();
}
