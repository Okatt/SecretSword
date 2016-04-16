using UnityEngine;

namespace Commands
{
    public abstract class ACommand : MonoBehaviour
    {
        protected GeneralObject mGeneralObject;

        protected virtual void Start()
        {
        }

        public abstract bool Execute();
    }
}

