using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class CubeControler : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float _force=100;
    Vector2 _direction;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        // _rigidbody.AddForce(new Vector3(_direction.x,0,_direction.y)*_force*Time.fixedDeltaTime);
        _rigidbody.AddTorque(new Vector3(_direction.y, 0, _direction.x) * _force * Time.fixedDeltaTime);
    }
}
