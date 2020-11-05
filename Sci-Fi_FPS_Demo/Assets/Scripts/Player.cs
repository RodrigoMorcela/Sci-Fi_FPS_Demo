using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private NavMeshAgent _navAgent;

    [SerializeField]
    private float _speed;
    private float _gravity;

    // Start is called before the first frame update
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();

        _speed = 3.5f;

        _gravity = 9.81f;
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        Vector3 velocity = direction * _speed;

        velocity.y -= _gravity;

        velocity = transform.transform.TransformVector(velocity);

        _navAgent.Move(velocity * Time.deltaTime);

    }
}
