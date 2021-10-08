using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _direction;
    private Rigidbody _body;
    public float TurnSpeed = 20f;
    
     Quaternion _rotation = Quaternion.identity;

    private bool _isSprint;
    public float speed = 2;
    bool facingRight;
    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _direction = Vector3.zero;
    }
    void Start()
    {

    }

    private void FixedUpdate()
    {
        move();
    }
    void Update()
    {
        
        _isSprint = Input.GetButton("Sprint");
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction.y = 0;
        _direction = transform.TransformDirection(_direction);
        _rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, _direction, TurnSpeed * Time.deltaTime, 0f));
    }


    private void move()
    {
        _body.MovePosition(_body.position + _direction.normalized * ((_isSprint) ? speed * 2 : speed) * Time.deltaTime);
        _body.MoveRotation(_rotation);

    }
}
   
