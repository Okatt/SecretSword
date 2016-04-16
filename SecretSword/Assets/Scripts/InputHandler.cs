using UnityEngine;
using Commands;

public class InputHandler : MonoBehaviour
{
    #region Memebers
    public PossessableObject mActive;
    #endregion

    #region Messages
    void Start()
    {
        mActive.mInputHandler = this;
    }
	void Update ()
	{
	    updateMovement();
	    updateButtonPress();
	}
    #endregion

    private void updateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        if (0 < x && mActive.mMoveRight)
            mActive.mMoveRight.Execute();
        else if (x < 0 && mActive.mMoveLeft)
            mActive.mMoveLeft.Execute();

        var y = Input.GetAxis("Vertical");
        if (0 < y && mActive.mMoveUp)
            mActive.mMoveUp.Execute();
        else if (y < 0 && mActive.mMoveDown)
            mActive.mMoveDown.Execute();
    }

    private void updateButtonPress()
    {
        if (Input.GetKeyDown(KeyCode.Keypad6) && mActive.mButtonB)
        {
            mActive.mButtonB.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad8) && mActive.mButtonY)
        {
            mActive.mButtonY.Execute();
        }
    }
}
