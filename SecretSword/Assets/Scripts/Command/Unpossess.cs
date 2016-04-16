using UnityEngine;

namespace Commands
{
    public class Unpossess : SwitchInputHandler
    {
        public override bool Execute()
        {
            if (base.Execute())
            {
                mPossessableObject.mIsEnterable = true;

                mPossessableObject.OtherPO.transform.position =  mPossessableObject.OtherPO.Rigidbody2D.position = mPossessableObject.Rigidbody2D.position;
                mPossessableObject.OtherPO.SpriteRenderer.enabled = true;

                return true;
            }
            else return false;
        }
    }
}

