namespace Commands
{
    class CallBody : ACommand
    {
        public override bool Execute()
        {
            Body.Singleton.WalkToTarget(mPossessableObject.transform.position);
            return true;
        }
    }
}
