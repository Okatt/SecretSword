using UnityEngine;
using Commands;

public class PossessableObject : GeneralObject
{
    #region Memebers
    public InputHandler mInputHandler;
    public bool mIsEnterable = true;

    public PossessableObject OtherPO { get; set; }
    public SpriteRenderer SpriteRenderer { get; set; }

    #region Commands
    public ACommand mMoveUp;
    public ACommand mMoveDown;
    public ACommand mMoveLeft;
    public ACommand mMoveRight;

    public ACommand mButtonB;
    public ACommand mButtonY;
    #endregion
    #endregion

    #region Messages
    protected override void Start()
    {
        base.Start();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion
}
