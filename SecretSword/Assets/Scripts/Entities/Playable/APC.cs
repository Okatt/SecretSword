using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public abstract class APC : MonoBehaviour
{
    [SerializeField]
    protected float mSpeed = 10;
    protected int mKnockBackTime;
    protected Vector2 mKnockBackVelocity;

    public bool CanEnter = true;
    public APC OtherPC { get; set; }
    public Vector2 Direction { get; set; }
    public Rigidbody2D RigidBody2D { get; set; }
    public InputHandler InputHandler { get; set; }

    public virtual void ButtonA() { }
    public virtual void ButtonB() { }

    public virtual void ButtonX()
    {
        Body.Singleton.Target += (Vector2)transform.position;
    }
    public virtual void ButtonY()
    {
        if (SwitchInputHandler(this, OtherPC))
        {
            var other = OtherPC;
            Exit(OtherPC);
            other.Enter(this);
        }
    }

    public virtual void Enter(APC other)
    {
        RigidBody2D.velocity = Vector2.zero;
    }

    public virtual void Exit(APC other)
    {
        RigidBody2D.velocity = Vector2.zero;
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

    protected virtual void handleVelocity()
    {
        if (mKnockBackTime == 0)
            RigidBody2D.velocity = Direction.normalized * mSpeed;
        else
        {
            RigidBody2D.velocity = mKnockBackVelocity;
            mKnockBackTime = --mKnockBackTime < 0 ? 0 : mKnockBackTime;
        }
    }

    public virtual void KnockBack(EKnockType type, Vector2 knockbackDirection, float knockback) {}

    #region Messages
    protected virtual void Start ()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
    protected virtual void Update()
    {
        handleVelocity();
        if (InputHandler)
            InputHandler.transform.position = RigidBody2D.position + (RigidBody2D.velocity * Time.deltaTime);
    }
    #endregion
}
