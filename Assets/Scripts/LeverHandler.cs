using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandler : MonoBehaviour {
    PlayerController player1;
    PlayerController player2;
    private bool player1Close = false;
    private bool player2Close = false;
    private string player1Name = "Player Male";
    private string player2Name = "Player Female";
    private float coolDown = 1f;
    private float coolDownTimer = 0;

    private SpriteRenderer spriteRenderer;
    public Sprite leverLeft;
    public Sprite leverRight;



    // Use this for initialization
    void Start () {
        player1 = GameObject.Find(player1Name).GetComponent<PlayerController>();
        player2 = GameObject.Find(player2Name).GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (coolDownTimer <= 0)
        {
            if (player1Close || player2Close)
            {
                HandleAction();
            }

        }
        else
        {
            coolDownTimer -= Time.deltaTime;
            if (coolDownTimer < 0)
            {
                coolDownTimer = 0;
            }
        }     
    }

    private void HandleAction()
    {
        if (player1.Action && player1Close)
        {
            coolDownTimer = coolDown;
            FlipLever();
        }
        else if (player2.Action && player2Close)
        {
            coolDownTimer = coolDown;
            FlipLever();
        }
    }

    private void FlipLever()
    {
        if (spriteRenderer.sprite == leverLeft)
        {
            spriteRenderer.sprite = leverRight;
        }
        else
        {
            spriteRenderer.sprite = leverLeft;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == player1Name)
        {
            player1Close = true;
        }
        if (collision.gameObject.name == player2Name)
        {
            player2Close = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == player1Name)
        {
            player1Close = false;
        }
        if (collision.gameObject.name == player2Name)
        {
            player2Close = false;
        }
    }
}
