using UnityEngine;
using System.Collections;

public class Shield : PC
{
    private bool mCanAttack = true;
    private SpriteRenderer mSpriteRenderer;

    public GameObject mColliderPrefab;

    public override void ButtonA()
    {
        if (mCanAttack)
        {
            StartCoroutine(attack());
        }
    }

    protected override void handleVelocity()
    {
        if(mCanAttack)
            base.handleVelocity();
    }

    IEnumerator attack()
    {
        mCanAttack = false;
        GameObject go = (GameObject)Instantiate(mColliderPrefab, transform.position, transform.rotation);
        go.transform.rotation = Quaternion.FromToRotation(Vector3.right, RigidBody2D.velocity);
        RigidBody2D.isKinematic = true;
        RigidBody2D.velocity = Vector2.zero;
        mKnockBackTime = 0;
        var oldColor = mSpriteRenderer.color;
        mSpriteRenderer.color = Color.cyan;
        yield return new WaitForSeconds(3);
        mSpriteRenderer.color = oldColor;
        Destroy(go);
        mCanAttack = true;
        RigidBody2D.isKinematic = false;
    }

    public override void KnockBack(EKnockType type, Vector2 knockbackDirection, float knockback)
    {
        if(mCanAttack)
            base.KnockBack(type, knockbackDirection, knockback);
    }

    protected override void Start()
    {
        base.Start();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
