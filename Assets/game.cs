using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> spawnees = new List<GameObject>();
    int randomInt;

    void Start()
    {
        for(int col =0, i =0;col<10;col++)
        {
            for(int row =0;row<10;row++,i++)
            {
                spawnees.Add(Instantiate(prefab, new Vector3(6*row, 0, 6*col), Quaternion.identity) as GameObject);
                spawnees[i].GetComponent<organism>().isAlive = true;
            }
        }

    }

    void Update()
    {
        
    }
}
