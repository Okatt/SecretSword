using UnityEngine;
using Commands;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class GeneralObject : MonoBehaviour
{
    public float mSpeed = 1;

    public Rigidbody2D Rigidbody2D { get; set; }

    #region Messages
    protected virtual void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    #endregion
}
