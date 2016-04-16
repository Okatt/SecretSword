using UnityEngine;

namespace Commands
{
    [RequireComponent(typeof(PossessableObject))]
    public abstract class ACommand : MonoBehaviour
    {
        protected PossessableObject mPossessableObject;

        protected virtual void Start()
        {
            mPossessableObject = GetComponent <PossessableObject>();
        }

        public abstract bool Execute();
    }
}

