using UnityEngine;

namespace Commands
{
    class Move : ACommandPossesable
    {
        [SerializeField]
        private Vector2 direction;

        public override bool Execute()
        {
            mPossessableObject.Rigidbody2D.velocity += direction * mPossessableObject.mSpeed;
            return true;
        }
    }
}
