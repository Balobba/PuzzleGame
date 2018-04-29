using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {//Contains all movements of the player, including attacks and animations

    Rigidbody2D rbody;
    Animator anim;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    public float playerMovementSpeed; //the speed of the player character (1 is good for now. Increases when in bossbattle)


    // Use this for initialization
    void Start () {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
            if (!attacking) // add !spinning later
            {
                Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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


                if (Input.GetKeyDown(KeyCode.Space)) //keybinding for attacking
                {
                    attackTimeCounter = attackTime;
                    attacking = true;
                    rbody.velocity = Vector2.zero; //stops moving the character
                    anim.SetBool("is_attacking", true);

                }

            }


 

        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;

        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("is_attacking", false);

        }

     


        


    }
}
