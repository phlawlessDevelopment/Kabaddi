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
        Vector3 input = GetInput();
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;
        
        Vector3 moveAmount = velocity * Time.deltaTime;
        rb.MovePosition(rb.position + moveAmount);
        
        Vector3 rotation = Vector3.up * rotationSpeed * Time.deltaTime * input.x;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));   
    }

    private Vector3 GetInput()
    {
        Vector3 input = new Vector3
        {
            x = Input.GetAxis("Horizontal"),
            z = Input.GetAxis("Vertical")
        };
        return input;
    }

    private void RaidingOnTrigger(){
    
        if (other.gameObject.CompareTag("Mid R"))
        {

        }
        else if (other.gameObject.CompareTag("Mid L"))
        {

        }
        else if (other.gameObject.CompareTag("Baulk R"))
        {

        }
        else if (other.gameObject.CompareTag("Baulk L"))
        {

        }
        else if (other.gameObject.CompareTag("Bonus R"))
        {

        }
        else if (other.gameObject.CompareTag("Bonus L"))
        {

        }
        else if (other.gameObject.CompareTag("Lobby T"))
        {

        }
        else if (other.gameObject.CompareTag("Lobby B"))
        {

        }
        else if (other.gameObject.CompareTag("Mid Line"))
        {

        }
    }

    private void DefendingOnTrigger(){


    }


    private void StruggleOnTrigger(){

    }


    public void OnTriggerEnter(Collider other)
    {   
        /*
        Mid L
        Mid R
        Baulk L
        Baulk R
        Bonus L
        Bonus R
        Lobby T
        Lobby B
        Mid Line
        */

        switch (state)
        {
            case State.Raiding:
                RaidingOnTrigger();
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
