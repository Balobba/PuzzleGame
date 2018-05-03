using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;


public class NumberMaze : MonoBehaviour
{

    private int[,] layout = new int[, ]
        {
            {5, 3, 3, 2, 4, 4},
            {3, 3, 4, 4, 2, 4},
            {1, 4, 1, 2, 4, 2},
            {3, 4, 1, 3, 2, 3},
            {4, 3, 2, 4, 4, 4},
            {2, 3, 5, 2, 3, 0},
        };

    public GameObject pressurePlatePrefab;
    public GameObject numberTilePrefab;

    private int startX, startY;
    private int mazeSize = 6;
    private int height = 6;
    private Vector2Int entrance = new Vector2Int(4, 5);

    private string startSprite = "base_out_atlas_367";
    private Tilemap tileMap;
    private List<PressurePlate> pressurePlateList;

    private Vector2Int lastTileP1;
    private Vector2Int lastTileP2;

    private Vector3[,] teleportList = new Vector3[6,6];


    //DEBUG
    private bool jumped = false;

    // Use this for initialization
    void Start()
    {
        FindStart();
        SpawnMaze();
        Debug.Log(teleportList.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //CheckForFailure();
    }



    public void PressurePlateActivated(Vector2Int position, GameObject player)
    {
        if (player.name == "Player Male")
        {
            player.transform.position = SetNewPos(position, lastTileP1, player);
        }
        else
        {
            player.transform.position = SetNewPos(position, lastTileP2, player);
        }
    }

    private int GetStepsToMove(Vector2Int lastTile)
    {
        return layout[(int)lastTile.x / 2, (int)lastTile.y / 2];
    }

    private Vector3 SetNewPos(Vector2Int platePosition, Vector2Int lastTile, GameObject player)
    {
        Vector3 newPos = new Vector3();
        int steps = GetStepsToMove(lastTile);

        Debug.Log("steps: " + steps + " lastTile: " + lastTile);
        //Player moved north
        if (lastTile.x == platePosition.x && lastTile.y > platePosition.y)
        {
            newPos = teleportList[lastTile.x / 2, lastTile.y / 2 - steps];
            Debug.Log("NORTH" + "lastTIle: " + lastTile + "steps: " + steps);
        }
        //EAST
        else if (lastTile.x < platePosition.x && lastTile.y == platePosition.y)
        {
            Debug.Log("EAST" + "lastTIle: " + lastTile + "steps: " + steps);
            newPos = teleportList[lastTile.x / 2 + steps, lastTile.y / 2];

        }
        //SOUTH
        else if (lastTile.x == platePosition.x && lastTile.y < platePosition.y)
        {
            Debug.Log("SOUTH: " + "lastTIle: " + lastTile + "steps: " + steps);
            newPos = teleportList[lastTile.x / 2, lastTile.y / 2 + steps];
        }
        //WEST
        else
        {


            Debug.Log("WEST" + "lastTIle: " + lastTile + "steps: " + steps);
            newPos = teleportList[lastTile.x / 2 - steps, lastTile.y / 2];
        }
        //Make sure the player ends up in the middle of the next tile
        float paddingY = 0.6f;
        float paddingX = -0.12f;
        newPos.y += paddingY;
        newPos.x += paddingX;

        return newPos;
    }

    public void NumberTileActivated(Vector2Int position, GameObject player)
    {
        if(player.name == "Player Male")
        {
            lastTileP1 = position;
        }
        else
        {
            lastTileP2 = position;
        }
    }

    private void TeleportPlayer(int playerID, GameObject player)
    {

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

    private void SpawnMaze()
    {
        float padding = 0.5f;

        for (int x = 0; x < mazeSize; x++)
        {
            for (int y = 0; y < mazeSize; y++)
            {

                Vector3 spawnPos = new Vector3(startX + 2*x + padding, startY - 2*y + padding, 0);

                GameObject gameObject = Instantiate(numberTilePrefab, spawnPos, Quaternion.identity);
                NumberSpriteHandler nsh = gameObject.GetComponent<NumberSpriteHandler>();
                nsh.SetNumberSprite(layout[x, y]);
                nsh.Position = new Vector2Int(2*x, 2*y);
                teleportList[x, y] = gameObject.transform.position;

                //Spawn the surrounding teleports
                if(x < mazeSize-1)
                {
                    Vector3 eastSpawnPos = new Vector3(spawnPos.x + 1, spawnPos.y, 0);
                    gameObject = Instantiate(pressurePlatePrefab, eastSpawnPos, Quaternion.identity);
                    PressurePlate pressurePlate = gameObject.GetComponent<PressurePlate>();
                    pressurePlate.Position = new Vector2Int(2*x + 1, 2*y);
                    pressurePlate.PuzzleName = "NumberMaze";
                }
                if(y < mazeSize-1)
                {
                    Vector3 southSpawnPos = new Vector3(spawnPos.x, spawnPos.y -1, 0);
                    gameObject = Instantiate(pressurePlatePrefab, southSpawnPos, Quaternion.identity);
                    PressurePlate pressurePlate = gameObject.GetComponent<PressurePlate>();
                    pressurePlate.Position = new Vector2Int(2*x, 2*y + 1);
                    pressurePlate.PuzzleName = "NumberMaze";
                }
                //PressurePlate pressurePlate = gameObject.GetComponent<PressurePlate>();
                //pressurePlate.Position = new Vector2Int(x, y);
            }
        }
    }


}
