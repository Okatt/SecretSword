using UnityEngine;
using Commands;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class Body : GeneralObject
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
    
    public void WalkToTarget(Vector2 target)
    {
        Rigidbody2D.velocity = (target - (Vector2)transform.position).normalized * mSpeed;
    }
}
