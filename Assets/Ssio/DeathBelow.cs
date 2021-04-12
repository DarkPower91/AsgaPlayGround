using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBelow : MonoBehaviour
{
    public Vector3 spawnPosition;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        other.transform.position = spawnPosition;
        other.rigidbody.velocity = Vector2.zero;
        other.rigidbody.angularVelocity = 0;
    }
}
