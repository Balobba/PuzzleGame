using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;


public class PressurePuzzleLogic : MonoBehaviour {


    public GameObject pressurePlatePrefab;


    private int startX, startY;
    private int width = 9;
    private int height = 6;
    private Vector2Int entrance = new Vector2Int(4, 5);
    private Vector3 restartPos = new Vector3(0,0,0); 

    private string startSprite = "base_out_atlas_366";
    private Tilemap tileMap;
    private List<PressurePlate> pressurePlateList;


    private string solutionsFileName = "PressurePlatePuzzleSolutions.json";

    PressurePuzzleSolutions solutions = new PressurePuzzleSolutions();

    private int currentSolutionID = 0;
    private List<Vector2Int> currentSolution;

    // Use this for initialization
    void Start ()
    {
        currentSolution = solutions.GetSolution(currentSolutionID);
        FindStart();
        SpawnPlates();

    }
	
	// Update is called once per frame
	void Update () {
        //CheckForFailure();
	}

    private void PrintSolution()
    {
        foreach (Vector2Int solutionPos in currentSolution)
        {
            Debug.Log("Solution: " + solutionPos);

        }
    }

    public void PressurePlateActivated(Vector2Int position, GameObject player)
    {
        // PLayer stepped on the wrong plate
        if (!currentSolution.Contains(position))
        {
            ResetPuzzle(player);
        }

    }

    private void ResetPuzzle(GameObject player)
    {
        //TODO: randomize next solution
        if(currentSolutionID == 0)
        {
            currentSolutionID = 1;
        }
        else
        {
            currentSolutionID = 0;
        }
        currentSolution = solutions.GetSolution(currentSolutionID);
        //PrintSolution();
        //Reset player position
        player.transform.position = restartPos;

    }

    private void FindStart()
    {

        GameObject tileBase = GameObject.Find("Base");
        tileMap = tileBase.GetComponent<Tilemap>();
        tileMap.CompressBounds();
        BoundsInt bounds = tileMap.cellBounds;
        TileBase[] allTiles = tileMap.GetTilesBlock(bounds);
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null && tile.name == startSprite)
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                    
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
                //Debug.Log("SPAWNING at: " + spawnPos);

                GameObject gameObject = Instantiate(pressurePlatePrefab, spawnPos, Quaternion.identity);
                PressurePlate pressurePlate = gameObject.GetComponent<PressurePlate>();
                pressurePlate.Position = new Vector2Int(x, y);
            
            }
        }
    }
}
