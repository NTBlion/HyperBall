using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndWave : MonoBehaviour
{
    public event UnityAction<EndWave> WaweEnded;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BallMover ball))
        {
            WaweEnded?.Invoke(this);
        }
    }
}
