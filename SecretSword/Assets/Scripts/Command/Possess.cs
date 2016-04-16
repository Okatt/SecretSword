using UnityEngine;

namespace Commands
{
    public class Possess : SwitchInputHandler
    {
        #region Messages
        void OnTriggerEnter2D(Collider2D collider)
        {
            var other = collider.gameObject.GetComponent<PossessableObject>();
            if (other)
                if (other.mIsEnterable)
                    mPossessableObject.OtherPO = other;
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            var other = collider.gameObject.GetComponent<PossessableObject>();
            if (other)
                if (mPossessableObject.OtherPO == other)
                    mPossessableObject.OtherPO = null;
        }
        #endregion

        public override bool Execute()
        {
            if (base.Execute())
            {
                mPossessableObject.SpriteRenderer.enabled = false;

                mPossessableObject.OtherPO.mIsEnterable = false;
                mPossessableObject.OtherPO.OtherPO = mPossessableObject;
                return true;
            }
            else return false;
        }
    }
}

