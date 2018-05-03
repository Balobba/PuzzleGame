using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSpriteHandler : MonoBehaviour {
    public Sprite[] numberSprites;
    // Use this for initialization



    private SpriteRenderer spriteRenderer;
    private Vector2Int position;

    void Start ()
    {

    }

    public Vector2Int Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }

    public void SetNumberSprite(int number)
    {
        if (!spriteRenderer)
        {
            GameObject child = this.gameObject.transform.GetChild(0).gameObject;
            spriteRenderer = child.GetComponent<SpriteRenderer>();
        }
        
        if(number == 0)
        {
            spriteRenderer.enabled = false;
        }
        else if (number > 0 && number <= numberSprites.Length)
        {

            Debug.Log("asdasd:" + spriteRenderer.name);

            spriteRenderer.sprite = numberSprites[number - 1];
        }
        else
        {
            Debug.Log("FEL! nr: " + number + " lista: " + numberSprites.Length);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SignalPuzzle(collision.gameObject);
    }

    private void SignalPuzzle(GameObject player)
    {
        GameObject gameObject = GameObject.Find("NumberMaze");
        NumberMaze numberMaze = gameObject.GetComponent<NumberMaze>();
        numberMaze.NumberTileActivated(Position, player);
         

        
    }
}
