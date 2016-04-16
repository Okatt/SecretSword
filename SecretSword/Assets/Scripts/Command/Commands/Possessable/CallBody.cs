namespace Commands
{
    class CallBody : ACommandPossesable
    {
        public override bool Execute()
        {
            Body.Singleton.WalkToTarget(mPossessableObject.transform.position);
            return true;
        }
    }
}
