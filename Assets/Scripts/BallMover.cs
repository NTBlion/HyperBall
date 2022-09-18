using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _deflectionSpeedl;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(0,0,_moveSpeed);

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _rigidbody.velocity = new Vector3(touch.deltaPosition.x * _deflectionSpeedl, _rigidbody.velocity.y, _rigidbody.velocity.z );
        }
    }
}
