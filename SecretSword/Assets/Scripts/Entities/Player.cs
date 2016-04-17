using UnityEngine;
using System.Collections;

public class Player : APC
{
    private SpriteRenderer mSpriteRenderer;
    private bool mIsActive = true;
    
    public override void Enter(APC other)
    {
        base.Enter(other);
        mSpriteRenderer.enabled = true;
        transform.position = OtherPC.transform.position;
        RigidBody2D.position = OtherPC.RigidBody2D.position;
        mIsActive = true;
    }

    public override void Exit(APC other)
    {
        base.Exit(other);
        mSpriteRenderer.enabled = false;
        mIsActive = false;
    }


    public override void KnockBack(EKnockType type, Vector2 knockbackDirection, float knockback)
    {
        mKnockBackTime = 100;
        mKnockBackVelocity = knockbackDirection * knockback;
    }
    #region Messages
    protected override void Start()
    {
        base.Start();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (mIsActive)
        {
            var other = collider.gameObject.GetComponent<APC>();
            if (other)
                if (other.CanEnter)
                    OtherPC = other;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (mIsActive)
        {
            var other = collider.gameObject.GetComponent<APC>();
            if (other)
                if (OtherPC == other)
                    OtherPC = null;
        }
    }
    #endregion
}
