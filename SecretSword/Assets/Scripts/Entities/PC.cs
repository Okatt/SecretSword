using UnityEngine;
using System.Collections;

public class PC : APC
{
    public override void Enter(APC other)
    {
        base.Enter(other);
        CanEnter = false;
        OtherPC = other;
    }

    public override void Exit()
    {
        base.Exit();
        CanEnter = true;
    }
}
