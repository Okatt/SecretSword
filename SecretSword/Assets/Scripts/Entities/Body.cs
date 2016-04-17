using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D),typeof(SpriteRenderer))]
public class Body : MonoBehaviour
{
    private static Body singleton;
    public static Body Singleton
    {
        get
        {
            if (singleton == null)
                singleton = FindObjectOfType<Body>();

            return singleton;
        }
    }

    public float mSpeed;
    public Vector2 Target { get; set; }

    private Rigidbody2D mRigidbody2D;
    
    // Use this for initialization
    void Start ()
    {
        mRigidbody2D = GetComponent <Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    mRigidbody2D.velocity = Target == Vector2.zero ? Vector2.zero : (Target - (Vector2) transform.position).normalized*mSpeed;
        Target = Vector2.zero;
    }
}