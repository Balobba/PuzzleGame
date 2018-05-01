using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Color successColor = Color.green;
    private Color failColor = Color.red;

    public Sprite activeSprite;
    public Sprite dormantSprite;


    // True while someone steps on it, false otherwise
    private bool isActive = false;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
        SetSprite();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isActive = false;
        SetSprite();
    }

    private void SetSprite()
    {
        if (isActive)
        {
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            spriteRenderer.sprite = dormantSprite;
        }
    }
}
