using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.Tilemaps;

public static class WallMaker
{

    public static GameObject CreateQuad(string text, Vector3 position, Vector3 rotation)
    {
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        Material quadMat = Resources.Load<Material>("mat");
        quad.GetComponent<Renderer>().material = quadMat;
        quad.transform.position = position;
        MeshCollider quadCol = quad.GetComponent<MeshCollider>();
        quadCol.convex = true;
        Texture2D texture = Resources.Load<Texture2D>(text);
        quad.GetComponent<Renderer>().material.mainTexture = texture;
        quad.transform.rotation = Quaternion.Euler(rotation);

        return quad;
    }

    public static GameObject SpawnProduct(string productname, Vector3 pos, Vector3 rot)
    {
        GameObject prefab = Resources.Load<GameObject>(productname);
        GameObject instance = GameObject.Instantiate(prefab);
        instance.transform.position = pos;
        instance.transform.rotation = Quaternion.Euler(rot);

        return instance;

    }

    //struct ShelfItems
    //{
    //    Tile tile;
    //    int products;
    //}
    //List<ShelfItems> shelfitems;

    public static void CreateMap()
    {
        GameObject TM = GameObject.FindGameObjectWithTag("map");
        Tilemap TileMap = TM.GetComponent<Tilemap>();

        BoundsInt bounds = TileMap.cellBounds;
        TileBase[] tiles = TileMap.GetTilesBlock(bounds);


        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int z = 0; z < bounds.size.y; z++)
            {
                TileBase tile = tiles[x + z * bounds.size.x];

                if (tile != null)
                {
                    if (tile.name == "tile")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);

                    }
                    else if (tile.name == "wall")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        //GameObject platt = CreateQuad("Shelfside", new Vector3(x, 0.7f, z + 1.7f), new Vector3(90, 0, 0));
                        //platt.transform.localScale = new Vector3(1.0f, 0.3f, 1.0f);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelfside", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                    }
                    else if (tile.name == "longwall")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelfsidesingle", new Vector3(x, 0.5f, z - 0.5f), Vector3.zero);
                        CreateQuad("Shelfsidesingle", new Vector3(x, 0.5f, z + 0.5f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 90, 0));
                    }
                    else if (tile.name == "cerealshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/POPS", new Vector3(x, 0.8f, z - 0.39f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/POPS", new Vector3(x - 0.2f, 0.8f, z - 0.39f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/POPS", new Vector3(x + 0.2f, 0.8f, z - 0.39f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/POPS", new Vector3(x, 0.5f, z - 0.39f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/POPS", new Vector3(x - 0.2f, 0.5f, z - 0.39f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/POPS", new Vector3(x + 0.2f, 0.5f, z - 0.39f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "hamshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/Ham_blue 1", new Vector3(x, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_blue 1", new Vector3(x - 0.1f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_blue 1", new Vector3(x - 0.2f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_blue 1", new Vector3(x + 0.1f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_blue 1", new Vector3(x + 0.2f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_blue 1", new Vector3(x + 0.3f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_red", new Vector3(x, 0.48f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_red", new Vector3(x - 0.1f, 0.48f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_red", new Vector3(x - 0.2f, 0.48f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_red", new Vector3(x + 0.1f, 0.48f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_red", new Vector3(x + 0.2f, 0.48f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/Ham_red", new Vector3(x + 0.3f, 0.48f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "mayoshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/mayo", new Vector3(x, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/mayo", new Vector3(x - 0.09f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/mayo", new Vector3(x - 0.18f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/mayo", new Vector3(x - 0.27f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/mayo", new Vector3(x + 0.09f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/mayo", new Vector3(x + 0.18f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/mayo", new Vector3(x + 0.27f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "coffeeshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/coffee", new Vector3(x, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/coffee", new Vector3(x - 0.09f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/coffee", new Vector3(x - 0.18f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/coffee", new Vector3(x - 0.27f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/coffee", new Vector3(x + 0.09f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/coffee", new Vector3(x + 0.18f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));


                    }
                    else if (tile.name == "chipsshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/chips", new Vector3(x, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/chips", new Vector3(x - 0.15f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/chips", new Vector3(x - 0.3f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/chips", new Vector3(x + 0.15f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/chips", new Vector3(x + 0.30f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "cookieshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x + 0.05f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x - 0.05f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x - 0.15f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x - 0.25f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x + 0.15f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x + 0.25f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x, 0.80f, z - 0.33f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x - 0.1f, 0.80f, z - 0.33f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x - 0.2f, 0.80f, z - 0.33f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x + 0.1f, 0.80f, z - 0.33f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x + 0.2f, 0.80f, z - 0.33f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cookies", new Vector3(x + 0.3f, 0.80f, z - 0.33f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "breadshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/bread1", new Vector3(x, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread1", new Vector3(x - 0.1f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread1", new Vector3(x - 0.2f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread1", new Vector3(x + 0.1f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread1", new Vector3(x + 0.2f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread2", new Vector3(x, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread2", new Vector3(x - 0.1f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread2", new Vector3(x - 0.2f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread2", new Vector3(x + 0.1f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/bread2", new Vector3(x + 0.2f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "oatmealshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelfside", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/oatmeal", new Vector3(x, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/oatmeal", new Vector3(x - 0.15f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/oatmeal", new Vector3(x - 0.3f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/oatmeal", new Vector3(x + 0.15f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/oatmeal", new Vector3(x + 0.3f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "cheeseshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelfsidesingle", new Vector3(x, 0.5f, z - 0.5f), Vector3.zero);
                        CreateQuad("Shelfsidesingle", new Vector3(x, 0.5f, z + 0.5f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 90, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.5f, 0.80f, z), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.5f, 0.80f, z - 0.08f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.5f, 0.80f, z - 0.15f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.5f, 0.80f, z - 0.22f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.5f, 0.80f, z - 0.30f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.5f, 0.80f, z + 0.08f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.5f, 0.80f, z + 0.15f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.44f, 0.80f, z), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.44f, 0.80f, z - 0.08f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.44f, 0.80f, z - 0.16f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.44f, 0.80f, z - 0.22f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.44f, 0.80f, z - 0.29f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.44f, 0.80f, z + 0.08f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/cheese", new Vector3(x + 0.44f, 0.80f, z + 0.15f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "milkshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelfsidesingle", new Vector3(x, 0.5f, z - 0.5f), Vector3.zero);
                        CreateQuad("Shelfsidesingle", new Vector3(x, 0.5f, z + 0.5f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 90, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.42f, 0.80f, z), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.42f, 0.80f, z - 0.1f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.42f, 0.80f, z - 0.2f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.42f, 0.80f, z + 0.1f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.42f, 0.80f, z + 0.2f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.34f, 0.80f, z - 0.05f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.34f, 0.80f, z - 0.15f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.34f, 0.80f, z + 0.05f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.34f, 0.80f, z + 0.15f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.24f, 0.80f, z), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/milk", new Vector3(x + 0.24f, 0.80f, z - 0.1f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "chickenshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelfside", new Vector3(x, 0.5f, z - 0.5f), Vector3.zero);
                        CreateQuad("Shelfside", new Vector3(x, 0.5f, z + 0.5f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 90, 0));
                        SpawnProduct("Prefabs/chickenbreast", new Vector3(x + 0.42f, 0.80f, z), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/chickenbreast", new Vector3(x + 0.42f, 0.80f, z - 0.2f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/chickenbreast", new Vector3(x + 0.42f, 0.80f, z + 0.2f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/chickenbreast", new Vector3(x + 0.33f, 0.80f, z - 0.1f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/chickenbreast", new Vector3(x + 0.33f, 0.80f, z + 0.1f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "lemonshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x - 0.08f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x - 0.16f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x - 0.24f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x + 0.08f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x - 0.08f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x - 0.17f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/lemon", new Vector3(x + 0.08f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x - 0.1f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x - 0.2f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x + 0.1f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x + 0.2f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x + 0.03f, 0.80f, z - 0.32f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x - 0.07f, 0.80f, z - 0.32f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x - 0.17f, 0.80f, z - 0.32f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/carrot", new Vector3(x + 0.13f, 0.80f, z - 0.32f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "medelshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/detergent", new Vector3(x + 0.05f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/detergent", new Vector3(x - 0.1f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/detergent", new Vector3(x - 0.25f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/detergent", new Vector3(x + 0.2f, 0.80f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "tomatoshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x - 0.08f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x - 0.16f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x - 0.24f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x - 0.32f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x + 0.08f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x + 0.16f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x + 0.24f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x + 0.32f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x + 0.04f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x + 0.12f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x + 0.2f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x - 0.04f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x - 0.12f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x - 0.2f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x - 0.28f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tomato", new Vector3(x + 0.28f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "potatoshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x - 0.08f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x - 0.16f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x - 0.24f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x + 0.08f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x + 0.16f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x + 0.24f, 0.47f, z - 0.46f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x - 0.07f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x - 0.15f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x - 0.25f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x + 0.07f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/potato", new Vector3(x + 0.16f, 0.47f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "avocadoshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/avocado", new Vector3(x, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/avocado", new Vector3(x + 0.08f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/avocado", new Vector3(x + 0.16f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/avocado", new Vector3(x + 0.24f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/avocado", new Vector3(x - 0.08f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/avocado", new Vector3(x - 0.16f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/avocado", new Vector3(x - 0.24f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/avocado", new Vector3(x - 0.32f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "hotsauseshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/hotsauce", new Vector3(x, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/hotsauce", new Vector3(x - 0.09f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/hotsauce", new Vector3(x - 0.18f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/hotsauce", new Vector3(x - 0.27f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/hotsauce", new Vector3(x + 0.09f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/hotsauce", new Vector3(x + 0.18f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/hotsauce", new Vector3(x + 0.27f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "teashelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/tea", new Vector3(x, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tea", new Vector3(x - 0.12f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tea", new Vector3(x - 0.24f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tea", new Vector3(x - 0.36f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tea", new Vector3(x + 0.12f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/tea", new Vector3(x + 0.24f, 0.77f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "pockyshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/pocky", new Vector3(x, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/pocky", new Vector3(x - 0.1f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/pocky", new Vector3(x - 0.2f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/pocky", new Vector3(x - 0.3f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/pocky", new Vector3(x + 0.1f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/pocky", new Vector3(x + 0.2f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "riceshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelf", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/rice", new Vector3(x, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/rice", new Vector3(x - 0.15f, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/rice", new Vector3(x + 0.15f, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/rice", new Vector3(x + 0.3f, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/rice", new Vector3(x + 0.02f, 0.8f, z + 0.34f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/rice", new Vector3(x - 0.13f, 0.8f, z + 0.34f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x - 0.1f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x - 0.2f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x + 0.1f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x + 0.2f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x + 0.3f, 0.8f, z - 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x, 0.8f, z - 0.34f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x + 0.1f, 0.8f, z - 0.34f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x - 0.1f, 0.8f, z - 0.34f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/sugar", new Vector3(x + 0.2f, 0.8f, z - 0.34f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "peanutbuttershelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z - 0.2f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x, 0.5f, z + 0.2f), new Vector3(0, 180, 0));
                        CreateQuad("Shelfside", new Vector3(x + 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelfside", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, -90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x - 0.1f, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x - 0.2f, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x - 0.3f, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x + 0.1f, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x + 0.2f, 0.8f, z + 0.4f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x, 0.8f, z + 0.34f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x - 0.1f, 0.8f, z + 0.34f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/PeanutButter", new Vector3(x + 0.1f, 0.8f, z + 0.34f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "eggshelf")
                    {
                        CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        CreateQuad("Shelfside", new Vector3(x, 0.5f, z - 0.5f), Vector3.zero);
                        CreateQuad("Shelfside", new Vector3(x, 0.5f, z + 0.5f), Vector3.zero);
                        CreateQuad("Shelf", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.4f, z), new Vector3(90, 90, 0));
                        CreateQuad("Shelf", new Vector3(x, 0.7f, z), new Vector3(90, 90, 0));
                        SpawnProduct("Prefabs/eggs", new Vector3(x + 0.41f, 0.47f, z), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/eggs", new Vector3(x + 0.41f, 0.47f, z - 0.17f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/eggs", new Vector3(x + 0.41f, 0.47f, z - 0.34f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/eggs", new Vector3(x + 0.41f, 0.47f, z + 0.17f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/eggs", new Vector3(x + 0.3f, 0.47f, z + 0.07f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/eggs", new Vector3(x + 0.3f, 0.47f, z - 0.1f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/eggs", new Vector3(x + 0.3f, 0.47f, z - 0.27f), new Vector3(0, 0, 0));
                        SpawnProduct("Prefabs/eggs", new Vector3(x + 0.3f, 0.47f, z + 0.24f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "cashout")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "cerealaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "hamaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "cheeseaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "milkaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "lemonaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "chickenaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "medelaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "mayoaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "cookieaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "chipsaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "coffeeaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "breadaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "tomatoaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "potatoaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "avocadoaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "riceaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "hotsauseaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "teaaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "oatmealaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "pockyaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "sugaraisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "peanutbutteraisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "eggaisle")
                    {
                        GameObject quad = CreateQuad("Floorpatternbright", new Vector3(x, 0, z), new Vector3(90, 0, 0));
                        quad.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
                    }
                    else if (tile.name == "outerwall")
                    {
                        CreateQuad("Wall1", new Vector3(x + 0.49f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Wall1", new Vector3(x + 0.49f, 1.5f, z), new Vector3(0, 90, 0));

                    }
                    else if (tile.name == "outerwall2")
                    {
                        CreateQuad("Fridge", new Vector3(x, 0.5f, z - 0.5f), new Vector3(0, 0, 0));
                        CreateQuad("Wall1", new Vector3(x, 1.5f, z - 0.5f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "outerwall3")
                    {
                        CreateQuad("Wall1", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 270, 0));
                        CreateQuad("Wall1", new Vector3(x - 0.5f, 1.5f, z), new Vector3(0, 270, 0));

                    }
                    else if (tile.name == "outerwall4")
                    {
                        CreateQuad("Wall1", new Vector3(x, 0.5f, z + 0.5f), new Vector3(0, 180, 0));
                        CreateQuad("Wall1", new Vector3(x, 1.5f, z + 0.5f), new Vector3(0, 180, 0));

                    }
                    else if (tile.name == "cornerwall")
                    {
                        CreateQuad("Wall1", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 270, 0));
                        CreateQuad("Wall1", new Vector3(x - 0.5f, 1.5f, z), new Vector3(0, 270, 0));
                        CreateQuad("Fridge", new Vector3(x, 0.5f, z - 0.5f), new Vector3(0, 0, 0));
                        CreateQuad("Wall1", new Vector3(x, 1.5f, z - 0.5f), new Vector3(0, 0, 0));
                    }
                    else if (tile.name == "window")
                    {
                        CreateQuad("Wall1", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Wall1", new Vector3(x - 0.5f, 1.5f, z), new Vector3(0, 90, 0));
                    }
                    else if (tile.name == "window2")
                    {
                        CreateQuad("Wall1", new Vector3(x - 0.5f, 0.5f, z), new Vector3(0, 90, 0));
                        CreateQuad("Wall1", new Vector3(x - 0.5f, 1.5f, z), new Vector3(0, 90, 0));
                    }

                }
            }
        }


    }

    public static void SpawnBaby()
    {
        GameObject TM = GameObject.FindGameObjectWithTag("map");
        Tilemap TileMap = TM.GetComponent<Tilemap>();
        GameObject baby = GameObject.FindGameObjectWithTag("obstacle");


        BoundsInt bounds = TileMap.cellBounds;
        TileBase[] tiles = TileMap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = tiles[x + y * bounds.size.x];

                if (tile != null)
                {
                    if (tile.name == "tile")
                    {
                        
                        // placera baby på random golv-tile
                        //baby.transform.position = Random.Range(0, bounds.size);

                    }



                }


            }
        }
    }

}
