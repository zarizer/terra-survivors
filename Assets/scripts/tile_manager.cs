using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_manager : MonoBehaviour
{
    public int tile_x;
    public int tile_y;

    public Transform TilesObject;
    public GameObject TilePrefab;

    void Start()
    {
        TilesObject = transform.parent;
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.GetComponent<Collider2D>().tag);
        if (collision.GetComponent<Collider2D>().tag == "Player")
        {
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    CheckOrCreateTile(tile_x + x, tile_y + y);
                }
            }

            CheckOrDestroyTile(tile_x, tile_y);
        }
    }

    void CheckOrCreateTile (int x, int y)
    {
        bool tile_found = false;
        for (int i = 0; i< TilesObject.transform.childCount; i++)
        {
            if (TilesObject.transform.GetChild(i).GetComponent<tile_manager>().tile_x == x &&
                TilesObject.transform.GetChild(i).GetComponent<tile_manager>().tile_y == y)
            {
                tile_found = true;
                break;
            } 
        }
        if (!tile_found)
        {
            GameObject new_tile = Instantiate(TilePrefab, TilesObject.transform);
            new_tile.transform.GetComponent<tile_manager>().tile_x = x;
            new_tile.transform.GetComponent<tile_manager>().tile_y = y;
            new_tile.transform.position = new Vector3(x * 5.12f*15, y * 5.12f*15, 0);
        }
    }

    void CheckOrDestroyTile(int x, int y)
    {
        for (int i = TilesObject.transform.childCount - 1; i >= 0; i--)
        {
            if (Mathf.Abs(TilesObject.transform.GetChild(i).GetComponent<tile_manager>().tile_x - x) > 1 ||
                Mathf.Abs(TilesObject.transform.GetChild(i).GetComponent<tile_manager>().tile_y - y) > 1)
            {
                Destroy(TilesObject.transform.GetChild(i).gameObject);
            }
        }
    }
}

