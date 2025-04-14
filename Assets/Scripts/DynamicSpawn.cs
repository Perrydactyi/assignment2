using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSpawn : MonoBehaviour
{
    public GameObject hovercraft1;
    public GameObject hovercraft2;
    public GameObject hovercraft3;

    private int maxHovercrafts = 10;
    private List<GameObject> spawned = new List<GameObject>();
    private Vector3 spawnStart = new Vector3(0, 0, 0); // start point
    private float spacing = 25f; // space between hovercrafts

    void Update()
    {
        if (spawned.Count >= maxHovercrafts)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnHovercraft(hovercraft1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnHovercraft(hovercraft2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnHovercraft(hovercraft3);
        }
    }

    void SpawnHovercraft(GameObject prefab)
    {
        // Spread them out on the X axis
        float x = spawnStart.x + spawned.Count * spacing;
        float z = spawnStart.z + Random.Range(-2f, 2f);

        // Get Y based on the terrain height at that X, Z
        float y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z));

        Vector3 spawnPosition = new Vector3(x, y + 100f, z); // +10 to float above ground a bit
        GameObject newHovercraft = Instantiate(prefab, spawnPosition, Quaternion.identity);
        spawned.Add(newHovercraft);

        

    }
}