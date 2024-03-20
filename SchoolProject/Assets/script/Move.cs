using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed = 0;
    public float leftBorder = -2.5f, rightBorder = 2.5f;
    public Animator animator = new Animator ();
    //public animator = new gameObject.GetComponent<Animator>();
    //float height = 1.25f;
    float transSpeed = 0.25f;
    public bool onLeft = false, mid = true, onRight = false;
    // Update is called once per frame

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        //GetComponent<Rigidbody>().MovePosition(transform.position + (new Vector3(0, 0, 1) * Time.deltaTime * speed));

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Run", true);
            speed = 15;
        }


        if (Input.GetKeyDown(KeyCode.A) && onLeft == false && mid == true)
        {
            onLeft = true;
            mid = false;
            transform.DOMoveX(leftBorder, transSpeed);
            //transform.position = new Vector3(-2, height, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.A) && mid == false && onRight == true)
        {
            onRight = false;
            mid = true;
            transform.DOMoveX(0, transSpeed);
            //transform.position = new Vector3(0, height, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && onRight == false && mid == true)
        {
            onRight = true;
            mid = false;
            transform.DOMoveX(rightBorder, transSpeed);
            //transform.position = new Vector3(2, height, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.D) && onLeft == true && mid == false)
        {
            onLeft = false;
            mid = true;
            transform.DOMoveX(0, transSpeed);
            //transform.position = new Vector3(0, height, transform.position.z);
        }
    }
    
}
