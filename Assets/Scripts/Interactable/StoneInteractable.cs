using UnityEngine;

public class StoneInteractable : MonoBehaviour
{

    public float pushDistance = 1f;
    Rigidbody2D stoneBody;

    private void Start()
    {
        stoneBody = gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {


            if (Mathf.Abs(gameObject.transform.position.y - collision.gameObject.transform.position.y) > Mathf.Abs(gameObject.transform.position.x - collision.gameObject.transform.position.x))
            {
                if (Mathf.Abs(collision.gameObject.transform.position.y) > Mathf.Abs(gameObject.transform.position.y))
                {
                    Debug.Log("rock over player");
                    gameObject.transform.Translate(0, pushDistance, 0);
                    stoneBody.velocity = new Vector2(0, 0);
                    gameObject.transform.Translate(0, 0, 0);

                }
                else
                {
                    Debug.Log("rock under player");
                    gameObject.transform.Translate(0, -pushDistance, 0);
                    stoneBody.velocity = new Vector2(0, 0);
                    gameObject.transform.Translate(0, 0, 0);
                }
            }
            else
            {
                if (Mathf.Abs(collision.gameObject.transform.position.x) > Mathf.Abs(gameObject.transform.position.x))
                {
                    Debug.Log("rock left of player");
                    gameObject.transform.Translate(-pushDistance, 0, 0);
                    stoneBody.velocity = new Vector2(0, 0);
                    gameObject.transform.Translate(0, 0, 0);

                }
                else
                {
                    Debug.Log("rock right of player");
                    gameObject.transform.Translate(pushDistance, 0, 0);
                    stoneBody.velocity = new Vector2(0, 0);
                    gameObject.transform.Translate(0, 0, 0);

                }
            }
        }
    }
}
