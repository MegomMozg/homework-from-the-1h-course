using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _direction;
    public float speed = 2;
    // Start is called before the first frame update
    private void Awake()
    {
        _direction = Vector3.zero;
    }
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            _direction.z = 1;
        else if (Input.GetKey(KeyCode.A))
            _direction.z = -1;
        else
            _direction.z = 0;
        if (Input.GetKey(KeyCode.S))
            _direction.x = 1;
        else if (Input.GetKey(KeyCode.W))
            _direction.x = -1;
        else
            _direction.x = 0;
    }
    private void move()
    {
        Vector3 direction = _direction * speed * Time.fixedDeltaTime;
        transform.position += direction;
    
    }
    private void FixedUpdate()
    {
        move();
    }

}
