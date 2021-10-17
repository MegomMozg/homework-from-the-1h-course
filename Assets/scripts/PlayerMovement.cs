using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Приватные переменные
    Quaternion _rotation = Quaternion.identity;
    [SerializeField] private Transform _Gun1;
    [SerializeField] private Transform _enemy;
    [SerializeField] private GameObject _Bullet;
    private Vector3 _direction;
    private Rigidbody _rb;
    private bool _isSprint;
    private bool _isFire;
    bool facingRight;

    #endregion

    #region Публичные переменные
    [HideInInspector] public float damage;
    public float TurnSpeed = 20f;
    public float speed = 2;
    public float speedSprint = 2;
    public float JumpForce = 3;
    public float BulletSpeed = 2;

    #endregion

    #region методы

    #region Cтандартные методы
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _direction = Vector3.zero;
        damage = 4;
    }
    private void FixedUpdate()
    {
        if (_isFire)
        {
            _isFire = false;
            Fire();
        }
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
        if (Input.GetButtonDown("Jump"))
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        if (Input.GetMouseButtonDown(0))
            _isFire = true;



    }
    #endregion

    #region Мои методы
    private void move()
    {
        _rb.MovePosition(_rb.position + _direction.normalized * ((_isSprint) ? speed * speedSprint : speed) * Time.deltaTime);
        _rb.MoveRotation(_rotation);

    }

    private void Fire()
    {
        GameObject BulletObject = Instantiate(_Bullet, _Gun1.position, _Gun1.rotation);
        Bullet Bullet = BulletObject.transform.gameObject.GetComponent<Bullet>();
        Bullet.Initialization(damage, 30f, BulletSpeed, _enemy);
        
    }
    #endregion

    #endregion
}