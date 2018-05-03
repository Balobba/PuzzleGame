using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{//Contains all movements of the player, including actions and animations

    Rigidbody2D rbody;
    Animator anim;

    private bool action;
    public float actionTime;
    private float actionTimeCounter;
    public float playerMovementSpeed; //the speed of the player character (1 is good for now)
    public string actionButton = "";
    public string horizontalMovement = "";
    public string verticalMovement = "";

    public bool Action
    {
        get
        {
            return action;
        }

        private set
        {
            action = value;
        }
    }



    // Use this for initialization
    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!Action)
        {
            Vector2 movement_vector = new Vector2(Input.GetAxisRaw(horizontalMovement), Input.GetAxisRaw(verticalMovement));
            if (movement_vector != Vector2.zero)
            {
                anim.SetBool("is_walking", true);
                anim.SetFloat("input_x", movement_vector.x);
                anim.SetFloat("input_y", movement_vector.y);
            }
            else
            {
                anim.SetBool("is_walking", false);
            }

            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * playerMovementSpeed);


            if (Input.GetButton(actionButton)) //keybinding for performing an action
            {

                print("PRESSED: " + actionButton);
                actionTimeCounter = actionTime;
                Action = true;
                //rbody.velocity = Vector2.zero; //stops moving the character
                anim.SetBool("is_performing_action", true);

            }

        }




        if (actionTimeCounter > 0)
        {
            actionTimeCounter -= Time.deltaTime;

        }

        if (actionTimeCounter <= 0)
        {
            Action = false;
            anim.SetBool("is_performing_action", false);

        }







    }
}
