using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PressurePuzzleLogic : MonoBehaviour {


    public GameObject pressurePlatePrefab;
    public int restartX, restartY;


    private int startX, startY;
    private int width = 9;
    private int height = 6;

    private string startSprite = "base_out_atlas_366";
    private Tilemap tileMap;

    // Use this for initialization
    void Start ()
    {
        FindStart();
        SpawnPlates();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FindStart()
    {

        GameObject tileBase = GameObject.Find("Base");
        tileMap = tileBase.GetComponent<Tilemap>();
        tileMap.CompressBounds();
        Debug.Log(tileMap.origin);
        BoundsInt bounds = tileMap.cellBounds;
        TileBase[] allTiles = tileMap.GetTilesBlock(bounds);
        Debug.Log(bounds.size);
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null && tile.name == startSprite)
                {
                    Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                    
                    startX = tileMap.origin.x + x;
                    startY = tileMap.origin.y + y;
                }
            }
        }
    }

    private void SpawnPlates()
    {
        float padding = 0.5f;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 spawnPos = new Vector3(startX + x + padding, startY - y  + padding, 0);
                Debug.Log("SPAWNING at: " + spawnPos);

                Instantiate(pressurePlatePrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
