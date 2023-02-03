using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    /* A kinematic rigid body player control script */
    [SerializeField] private GameObject popupTextPrefab;
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;

    private Rigidbody rb;

    private List<AIControl> tagged = new List<AIControl>();
    private bool bonus = false;

    private bool midLineCrossed = false;
    private bool bonusLineCrossed = false;

    private ScoreSystem scoreSystem;

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
        scoreSystem = GameObject.FindObjectOfType<ScoreSystem>();
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

    private void RaidingOnTrigger(Collider other){
        
        
       
    }

    private void DefendingOnTrigger(){


    }


    private void StruggleOnTrigger(){

    }


    public void OnTriggerEnter(Collider other)
    {   
        if (midLineCrossed && other.gameObject.CompareTag("Ai Char")){
            tagged.Add(other.gameObject.GetComponent<AIControl>());
            state = PlayerState.Struggle;
            SpawnPopupText("Struggle", Color.red);
        }
        if (midLineCrossed && other.gameObject.CompareTag("Bonus"))
        {
            bonus = true;
            SpawnPopupText("Bonus line crossed", Color.yellow);
        }
        if (!midLineCrossed && other.gameObject.CompareTag("Mid Line"))
        {
            midLineCrossed = true;
            SpawnPopupText("kabaddi...", Color.black);
        }
        else if(midLineCrossed && other.gameObject.CompareTag("Mid Line"))
        {
            // Todo: count points
            SpawnPopupText(tagged.Count.ToString() + " points", Color.green);
            scoreSystem.AddPlayerScore(tagged.Count + (bonusLineCrossed ? 1 : 0));
            tagged.Clear();
            midLineCrossed = false;
            bonusLineCrossed = false;
        }
               
        if (midLineCrossed && other.gameObject.CompareTag("Baulk"))
        {

        }
        if (midLineCrossed && other.gameObject.CompareTag("Bonus"))
        {

        }
    }
    private void SpawnPopupText(string text, Color color)
    {
        PopupText popupText = Instantiate(popupTextPrefab, transform.position, Quaternion.identity).GetComponent<PopupText>();
        popupText.SetText(text);
        popupText.SetColor(color);
    }

}
