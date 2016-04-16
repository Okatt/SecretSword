using UnityEngine;

namespace Commands
{
    [RequireComponent(typeof(PossessableObject))]
    public abstract class ACommandPossesable : ACommand
    {
        protected PossessableObject mPossessableObject;

        protected override void Start()
        {
            base.Start();
            mPossessableObject = GetComponent<PossessableObject>();
        }
    }
}

