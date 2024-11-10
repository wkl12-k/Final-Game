using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ChessPieceMovement
{
    float speed { get; }
    bool isMoving { get; set; }
    ChessBoard chessBoard { get; set; }

    List<Vector3> CheckAvailableMoves(Vector3 position);
    void Move(Vector3 targetPosition);
    IEnumerator MoveToTarget(Vector3 target);
}
