using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleObjects : MonoBehaviour
{

    public List<GameObject> objectsCycle = new List<GameObject>();
    private int index = 0;
    void Start()
    {
         
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            cycle();
        } 
    }

    void cycle(){
        objectsCycle[index].SetActive(false);

        index++;

        if (index >= objectsCycle.Count){
            index = 0;
        }

        objectsCycle[index].SetActive(true);
    }
}
