using UnityEngine;
using Commands;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PossessableObject : MonoBehaviour
{
    #region Memebers
    public InputHandler mInputHandler;
    public float mSpeed = 1;
    public bool mIsEnterable = true;

    public PossessableObject OtherPO { get; set; }
    public Rigidbody2D Rigidbody2D { get; set; }
    public SpriteRenderer SpriteRenderer { get; set; }

    #region Commands
    public ACommand mMoveUp;
    public ACommand mMoveDown;
    public ACommand mMoveLeft;
    public ACommand mMoveRight;

    public ACommand mButtonB;
    #endregion
    #endregion

    #region Messages
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        var drag = .1f;
        Rigidbody2D.velocity *= drag;
    }
    #endregion
}
