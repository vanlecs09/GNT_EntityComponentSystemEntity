using UnityEngine;

public interface IRigidbody
{
    Vector3 Velocity { get; set; }
    
    void AddForce(Vector3 force);
    void AddImpulse(Vector3 force);
}