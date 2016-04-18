using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Memebers
    public APC mCharacter;
    #endregion

    #region Messages
    void Start()
    {
        mCharacter.InputHandler = this;
    }
	void Update ()
	{
        mCharacter.Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Input.GetKeyDown(KeyCode.Z))
        	mCharacter.ButtonA();
        if(Input.GetKeyDown(KeyCode.X))
        	mCharacter.ButtonB();
        if(Input.GetKey(KeyCode.C))
        	mCharacter.ButtonX();
        if(Input.GetKeyDown(KeyCode.V))
        	mCharacter.ButtonY();

        if (Input.GetKeyDown(KeyCode.Joystick1Button0)) // A
            mCharacter.ButtonA();
        if (Input.GetKeyDown(KeyCode.Joystick1Button1)) // B
            mCharacter.ButtonB();
        if (Input.GetKey(KeyCode.Joystick1Button2)) // X
            mCharacter.ButtonX();
        if (Input.GetKeyDown(KeyCode.Joystick1Button3)) // Y
            mCharacter.ButtonY();
    }
    #endregion
}
