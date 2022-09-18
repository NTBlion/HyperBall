using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private BallMover _ball;
    [SerializeField] private float _nedeedDistance;

    private float _speed = 5;

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_ball.transform.position.x, transform.position.y, _ball.transform.position.z - _nedeedDistance) ;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
