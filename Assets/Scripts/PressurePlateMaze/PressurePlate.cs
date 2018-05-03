using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public Sprite activeSprite;
    public Sprite dormantSprite;

    public string[] puzzleNames;

    // True while someone steps on it, false otherwise
    private bool isActive = false;
    private Vector2Int position;
    private string puzzleName;

    public bool IsActive
    {
        get
        {
            return isActive;
        }

        private set
        {
            isActive = value;
        }
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

    public string PuzzleName
    {
        get
        {
            return puzzleName;
        }

        set
        {
            puzzleName = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsActive = true;
        SetSprite();
        SignalPuzzle(collision.gameObject);    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsActive = false;
        SetSprite();
    }

    private void SignalPuzzle(GameObject player)
    {
        GameObject gameObject;
        switch (PuzzleName)
        {
            case "PressurePlatePuzzle":
                gameObject = GameObject.Find("PressurePlatePuzzle");
                PressurePuzzleLogic ppl = gameObject.GetComponent<PressurePuzzleLogic>();
                ppl.PressurePlateActivated(Position, player);
                break;
            case "NumberMaze":
                gameObject = GameObject.Find("NumberMaze");
                NumberMaze numberMaze = gameObject.GetComponent<NumberMaze>();
                numberMaze.PressurePlateActivated(Position, player);
                break;
            default:
                break;

        }
    }

    private void SetSprite()
    {
        if (IsActive)
        {
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            spriteRenderer.sprite = dormantSprite;
        }
    }
}
