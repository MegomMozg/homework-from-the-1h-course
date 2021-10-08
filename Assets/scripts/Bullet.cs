using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage;

    public void Initialization(float damage, float lifeTime, Transform target)
    {
        _damage = damage;
        Destroy(this.gameObject, lifeTime);

    }
    private void FixedUpdate()
    {
        Vector3 direction = transform.forward * 5f * Time.fixedDeltaTime;
        transform.position += direction;
    }

}
