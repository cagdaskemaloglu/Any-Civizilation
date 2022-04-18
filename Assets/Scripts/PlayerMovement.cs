using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    private Vector3 movementDir;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotSpeed=100f;
    [SerializeField] private float jumpHeight=.8f;
    [SerializeField] private bool canJump=true;
    [SerializeField] private bool sprint=false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
 
    }
 
    // Update is called once per frame
    void FixedUpdate () 
    {
        Move();
    }



    void Move(){
        movementDir = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0, Input.GetAxisRaw("Vertical") * speed);

        movementDir.Normalize();
        transform.Translate(movementDir * speed * Time.deltaTime,Space.World);

        if (movementDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
            anim.SetBool("isWalk", true);
            StartCoroutine(Sprint());
        }
        else
        {
            anim.SetBool("isWalk", false);
            sprint=false;
        }

         if (Input.GetKeyDown(KeyCode.Space)&&canJump)
        {
            transform.Translate(Vector3.up * jumpHeight);
            anim.SetBool("isJump",true);
            StartCoroutine(Jump());
        }

        if(sprint){
            speed=3.5f;
            anim.SetBool("isRun",true);
        }
        else{
            speed=2f;

            anim.SetBool("isRun",false);
        }
    }
        

    IEnumerator Jump(){
        canJump=false;
        yield return new WaitForSeconds(.5f);
        anim.SetBool("isJump",false);
        yield return new WaitForSeconds(.1f);
        canJump=true;
    }

    IEnumerator Sprint(){

            yield return new WaitForSeconds(2f);
            sprint=true;
    }

}
