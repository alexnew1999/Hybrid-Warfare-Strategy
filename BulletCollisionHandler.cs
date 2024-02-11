using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private Collider2D targetCollider;

    public void SetTarget(Collider2D target)
    {
        targetCollider = target;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Если столкнулись с целью, уничтожаем пулю
        if (other == targetCollider)
        {
            Destroy(gameObject);
        }
    }
}
