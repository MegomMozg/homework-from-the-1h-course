using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turel : MonoBehaviour
{
    [HideInInspector] public float damage;
    public Transform Rotate;
    public Transform Center;
    public Collider Sphere_Collider;
    public GameObject _Bullet;
    public Transform _Gun1;
    public Transform _Gun2;
    private bool _isFire;
    private void Awake()
    {
        damage = 4;
    }
        public void OnTriggerStay(Collider Sphere_Collider)
    {
        if (Sphere_Collider.tag == "Player")
        {
            Vector3 direction = Sphere_Collider.transform.position - Rotate.position;
            Vector3 ForwardDirection = new Vector3(direction.x, 0, direction.z);
            Rotate.rotation = Quaternion.LookRotation(ForwardDirection);
            Fire();
            
        }

    }
    private void Fire()
    {
        GameObject BulletObject = Instantiate(_Bullet, _Gun1.position, _Gun1.rotation);
        GameObject BulletObject1 = Instantiate(_Bullet, _Gun2.position, _Gun2.rotation);
        Bullet Bullet = BulletObject.transform.gameObject.GetComponent<Bullet>();
        Bullet Bullet1 = BulletObject1.transform.gameObject.GetComponent<Bullet>();
        Bullet.Initialization(damage, 7f, null);
        Bullet1.Initialization(damage, 7f, null);
    }
}
