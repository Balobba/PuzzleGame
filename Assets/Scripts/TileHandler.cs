using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileHandler : MonoBehaviour {

    private TilemapCollider2D tileCollider;
    private Tilemap tileMap;


	// Use this for initialization
	void Start ()
    {
        tileCollider = GetComponent<TilemapCollider2D>();
        tileMap = GetComponent<Tilemap>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 pos = collision.gameObject.transform.position;
        Vector3Int posInt = new Vector3Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y), 0);
        Debug.Log(tileMap.name);
        Debug.Log(tileMap.GetTile(posInt));
        Debug.Log(tileMap.GetUsedTilesCount());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("EXIT");

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3 pos = collision.gameObject.transform.position;
        Vector3Int posInt = new Vector3Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y), 0);
        TileBase tile = tileMap.GetTile(posInt);

        //Debug.Log(tile);
    }
}
