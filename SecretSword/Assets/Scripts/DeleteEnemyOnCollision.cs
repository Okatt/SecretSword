using UnityEngine;
using System.Collections;

public class DeleteEnemyOnCollision : MonoBehaviour
{
    #region Messages
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Enemy")
            Destroy(other.gameObject);
    }
    #endregion
}
