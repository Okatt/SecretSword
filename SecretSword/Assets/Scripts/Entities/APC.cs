using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public abstract class APC : MonoBehaviour
{
    [SerializeField]
    protected float mSpeed;

    public bool CanEnter;
    public APC OtherPC { get; set; }
    public Vector2 Direction { get; set; }
    public Rigidbody2D RidgidBody2D { get; set; }
    public InputHandler InputHandler { get; set; }

    public virtual void ButtonA() { }
    public virtual void ButtonB() { }
    public virtual void ButtonX() { }
    public virtual void ButtonY()
    {
        if (SwitchInputHandler(this, OtherPC))
        {
            Exit();
            OtherPC.Enter(this);
        }
    }

    public virtual void Enter(APC other)
    {
        RidgidBody2D.velocity = Vector2.zero;
    }

    public virtual void Exit()
    {
        RidgidBody2D.velocity = Vector2.zero;
        Direction = Vector2.zero;
    }

    protected static bool SwitchInputHandler(APC from, APC to)
    {
        if (!to)
            return false;

        to.InputHandler = from.InputHandler;
        to.InputHandler.mCharacter = to;
        from.InputHandler = null;

        return true;
    }
    
    #region Messages
    protected virtual void Start ()
    {
        RidgidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
    protected virtual void Update()
    {
        RidgidBody2D.velocity = Direction.normalized*mSpeed;
        if (InputHandler)
            InputHandler.transform.position = RidgidBody2D.position + (RidgidBody2D.velocity * Time.deltaTime);
    }
    #endregion
}
