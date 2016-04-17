using UnityEngine;
using System.Collections;

public class PC : APC
{
    public override void Enter(APC other)
    {
        base.Enter(other);
        CanEnter = false;
        OtherPC = other;
        transform.tag = "Player";
    }

    public override void Exit(APC other)
    {
        base.Exit(other);
        CanEnter = true;
        OtherPC = null;
        transform.tag = "Possessable";
    }

    public override void KnockBack(EKnockType type, Vector2 knockbackDirection, float knockback)
    {
        knockbackDirection = 0 < knockbackDirection.magnitude ? knockbackDirection : -RigidBody2D.velocity.normalized;

        if (type == EKnockType.KnockOut)
        {
            var other = OtherPC;
            SwitchInputHandler(this, OtherPC);
            Exit(OtherPC);
            other.Enter(this);
            other.KnockBack(type, knockbackDirection, knockback);
        }
        else if(type == EKnockType.KnockBack)
        {
            mKnockBackTime = 100;
            mKnockBackVelocity = knockbackDirection * knockback;
        }
    }
}
