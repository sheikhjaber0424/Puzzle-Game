using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;

    public GameObject bjTilePrefab;

    public Gem[] gems;

    public Gem[,] allGems;

    public float gemSpeed;
    // Start is called before the first frame update
    void Start()
    {
        allGems = new Gem[width,height];
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 pos = new Vector2(i, j);
                GameObject bgTile = Instantiate(bjTilePrefab, pos, Quaternion.identity); // Quaternion.identity means 0 rotation for our object
                bgTile.transform.parent = transform;
                bgTile.name = "BG tile -" + i + "," + j;

                int gemToUse = Random.Range(0, gems.Length);

                SpawnGem(new Vector2Int(i, j), gems[gemToUse]);
            }
        }
    }

    private void SpawnGem(Vector2Int pos,Gem gemToSpawn)
    {
        Gem gem = Instantiate(gemToSpawn,new Vector3(pos.x, pos.y, 0f), Quaternion.identity);
        gem.transform.parent =transform;
        gem.name ="Gem - "+ pos.x+", "+pos.y;
        allGems[pos.x,pos.y] = gem;

        gem.SetupGem(pos, this);
    }
}
