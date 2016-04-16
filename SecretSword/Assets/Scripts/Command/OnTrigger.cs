using UnityEngine;
using Commands;

public class OnTrigger : MonoBehaviour
{
    [SerializeField]
    private ACommand mOnTriggerEnter;
    [SerializeField]
    private ACommand mOnTriggerExit;


    #region Messages
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (mOnTriggerEnter)
            mOnTriggerEnter.Execute();
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (mOnTriggerExit)
            mOnTriggerExit.Execute();
    }
    #endregion
}
