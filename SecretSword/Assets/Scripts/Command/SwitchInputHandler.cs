using UnityEngine;

namespace Commands
{
    [DisallowMultipleComponent]
    public class SwitchInputHandler : ACommand
    {
        public override bool Execute()
        {
            if (mPossessableObject.OtherPO)
            {
                mPossessableObject.OtherPO.Rigidbody2D.velocity = Vector2.zero;
                mPossessableObject.OtherPO.mInputHandler = mPossessableObject.mInputHandler;
                mPossessableObject.OtherPO.mInputHandler.mActive = mPossessableObject.OtherPO;

                mPossessableObject.mInputHandler = null;
                mPossessableObject.Rigidbody2D.velocity = Vector2.zero;

                return true;
            }
            else return false;
        }
    }
}

