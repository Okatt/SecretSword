using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D),typeof(SpriteRenderer))]
public class SpikeBall : MonoBehaviour
{
    public float Speed;
    public GameObject Target;

    private int waitTime;

    private EState mState;
    private EState State
    {
        get { return mState;}
        set
        {
            switch (value)
            {
                case EState.vulnerable:
                    mState = EState.vulnerable;
                    mSpriteRenderer.color = Color.green;
                    mDirection = Vector2.zero;
                    mRigidbody2D.velocity = Vector2.zero;
                    waitTime = 100;
                    break;
                case EState.normal:
                    mState = EState.normal;
                    mSpriteRenderer.color = Color.blue;
                    waitTime = 100;
                    break;
                case EState.charge:
                    mState = EState.charge;
                    mSpriteRenderer.color = Color.magenta;
                    mDirection = Vector2.zero;
                    mRigidbody2D.velocity = Vector2.zero;
                    waitTime = 100;
                    break;
                case EState.dash:
                    mState = EState.dash;
                    mSpriteRenderer.color = Color.red;
                    mDirection = Target.transform.position - transform.position;
                    mDirection.Normalize();
                    mDirection *= Speed * 2f;
                    waitTime = 100;
                    break;
            }
        }
    }
    private Rigidbody2D mRigidbody2D;
    private SpriteRenderer mSpriteRenderer;
    private Vector2 mDirection;
    
    #region Messages
    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();

        State = EState.normal;
    }

    void Update()
    {
        --waitTime;
        if (waitTime < 0)
            waitTime = 0;
        switch (State)
        {
            case EState.normal:
                mDirection = Target.transform.position - transform.position;
                if (mDirection.magnitude < 10 && waitTime == 0)
                    State = EState.charge;
                else
                {
                    mDirection.Normalize();
                    mDirection *= Speed;
                    mRigidbody2D.velocity = mDirection;
                }
                break;
            case EState.charge:
                if (waitTime == 0)
                    State = EState.dash;
                break;
            case EState.dash:
                if (waitTime == 0)
                    State = EState.normal;
                else
                    mRigidbody2D.velocity = mDirection;
                break;
            case EState.vulnerable:
                if (waitTime == 0)
                    State = EState.normal;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(State == EState.dash && (other.gameObject.layer == 8 || other.gameObject.layer == 10))
        {
            State = EState.vulnerable;
        }
    }
    #endregion

    private enum EState
    {
        normal,
        charge,
        dash,
        vulnerable
    }
}
