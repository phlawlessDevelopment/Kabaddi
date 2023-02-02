using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    /* A kinematic rigid body player control script */

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    private Rigidbody rb;

    private List<AIControl> tagged = new List<AIControl>();
    private bool bonus = false;

    enum PlayerState
    {
        Raiding,
        Defending,
        Struggle,
        Out
    }
    private PlayerState state = PlayerState.Raiding;

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
        
        if (other.gameObject.CompareTag("Ai Char")){
            tagged.Add(other.gameObject.GetComponent<AIControl>());
            state = PlayerState.Struggle;
        }
        else if (other.gameObject.CompareTag("Bonus L"))
        {

        }
        
        else if (other.gameObject.CompareTag("Mid Line"))
        {

        }
        
        else if (other.gameObject.CompareTag("Baulk L"))
        {

        }
        else if (other.gameObject.CompareTag("Bonus R"))
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
            case PlayerState.Raiding:
                RaidingOnTrigger();
                break;
            case PlayerState.Defending:
                DefendingOnTrigger();
                break;
            case PlayerState.Struggle:
                StruggleOnTrigger();
                break;
            case PlayerState.Out:
                break;
            default:
                break;
        }

       
        

        
    }

}
