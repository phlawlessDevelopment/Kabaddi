using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    /* A kinematic rigid body player control script */

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    private Rigidbody rb;

    // private List<

    enum State
    {
        Raiding,
        Defending,
        Struggle,
        Out
    }
    private State state = State.Raiding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 direction = input.normalized;
        // Vector3 velocity = direction * speed;
        
        // Vector3 moveAmount = velocity * Time.deltaTime;
        // rb.MovePosition(rb.position + moveAmount);
        
        // Vector3 rotation = Vector3.up * rotationSpeed * Time.deltaTime * input.x;
        // rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));   
    }


    private void RaidingOnTrigger(Collider other){
    
        
    }

    private void DefendingOnTrigger(){


    }


    private void StruggleOnTrigger(){

    }


    public void OnTriggerEnter(Collider other)
    {   

        switch (state)
        {
            case State.Raiding:
                RaidingOnTrigger(other);
                break;
            case State.Defending:
                DefendingOnTrigger();
                break;
            case State.Struggle:
                StruggleOnTrigger();
                break;
            case State.Out:
                break;
            default:
                break;
        }

       
        

        
    }

}
