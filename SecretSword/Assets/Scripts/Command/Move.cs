using UnityEngine;

namespace Commands
{
    class Move : ACommand
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
