using UnityEngine;

namespace Commands
{
    class SwitchTrigger : ACommand
    {
        [SerializeField]
        private BoxCollider2D mCollider;
        [SerializeField]
        private SpriteRenderer mSpriteRenderer;
        [SerializeField]
        private bool mIsTrigger;

        public override bool Execute()
        {
            mCollider.isTrigger = mIsTrigger;
            mSpriteRenderer.enabled = !mIsTrigger;
            return true;
        }
    }
}