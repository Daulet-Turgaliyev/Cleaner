using UnityEngine;
using System.Collections;


public class Move_Cleaner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate;

    public FloatingJoystick Joystick;

    private Rigidbody _rb;

    private Vector3 _input;

    public float Speed{ set{_speed = value;} }


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _rb.velocity = Vector3.zero;
            _input = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {

        _input = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);

        if (_input != Vector3.zero)
        {  
            _rb.velocity = _input.normalized * _speed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_input), _speedRotate);
        }
    }
}
 