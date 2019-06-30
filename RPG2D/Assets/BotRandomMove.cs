using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotRandomMove : MonoBehaviour
{
    Rigidbody _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        // _rigidBody.velocity = new Vector3(10, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        _rigidBody.velocity = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
    }
}
