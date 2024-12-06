using UnityEngine;

public class PieceStatus : MonoBehaviour
{   
    public bool moving = false; 
    public bool allowEndGoal = true;  

    public void SetPieceMoving(bool status)
    {
        moving = status;
        
    }

    public bool IsPieceMoving()
    {
        return moving;
    }
}
