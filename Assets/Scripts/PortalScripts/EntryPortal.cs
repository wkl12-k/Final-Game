using UnityEngine;

public class PortalEntry : MonoBehaviour
{
    [SerializeField] ChessBoard chessPiece;
    private Vector3 exitPosition;
    private SpriteRenderer portalSprite;
    private Collider portalCollider;

    void Start()
    {
        portalSprite = GetComponent<SpriteRenderer>();
        portalCollider = GetComponent<Collider>();
        portalSprite.enabled = true;

    }

    // Update is called once per frame
    // Come into contact with piece
    void Update()
    {
        chessPiece.enabled = false; 
    }

   

    void Update()
    {
        if (level == 5 && frog.starCounter == 2)
        {
            portalSR.enabled = true;
            portalCollider.enabled = true;
        }
    }


}
