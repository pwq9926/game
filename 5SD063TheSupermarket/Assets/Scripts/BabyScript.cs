using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class BabyScript : MonoBehaviour
{
    public Rigidbody myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    void RandomSpawn()
    {

        GameObject TM = GameObject.FindGameObjectWithTag("map");
        Tilemap TileMap = TM.GetComponent<Tilemap>();

        BoundsInt bi = TileMap.cellBounds;

        // får tag i en random tile å tilemapen
        Vector3Int vi = new Vector3Int(Random.Range(bi.xMin, bi.xMax), Random.Range(bi.yMin, bi.yMax), Random.Range(bi.zMin, bi.zMax));  

        // sparar den random tilen
        TileBase T = TileMap.GetTile(vi);

        // om random-tilen är en golvtile, placera objektet på den tilen
        // hur får jag tag i den tilens position och hur kollar jag if-satsen igen om det inte är en golvtile?
        if (T.name == "tile" || T.name == "cerealaisle" || T.name == "hamaisle" || T.name == "milkaisle" || T.name == "cheeseaisle")
        {
            //Instantiate(gameObject, T.);
        }

    }

}
