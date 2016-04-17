using System.Collections;
using UnityEngine;

public class Sword : PC
{
    private bool mCanAttack = true;

    public GameObject mColliderPrefab;

    public override void ButtonA()
    {
        if (mCanAttack)
        {
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        mCanAttack = false;
        GameObject go = (GameObject)Instantiate(mColliderPrefab, transform.position, transform.rotation);
        go.transform.SetParent(gameObject.transform);
        go.transform.rotation = Quaternion.FromToRotation(Vector3.right, RigidBody2D.velocity);
        yield return new WaitForSeconds(.1f);
        Destroy(go);
        mCanAttack = true;
    }
}
