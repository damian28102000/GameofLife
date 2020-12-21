using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[,] spawnees;
    float lastTime;

    void Start()
    {
        spawnees = new GameObject[10, 10];
        for(int col =0, i =0;col<10;col++)
        {
            for(int row =0;row<10;row++,i++)
            {
                spawnees[row,col] = Instantiate(prefab, new Vector3(6*row, 0, 6*col), Quaternion.identity);
            }
        }

        for(int i =0;i<10;i++)
        {
            spawnees[Random.Range(0,10), Random.Range(0, 10)].GetComponent<organism>().isAlive = true;
        }

    }

    void Update()
    {
        float currentTime = Time.time;
        Debug.Log(currentTime - lastTime);
        if (currentTime - lastTime >=1)
        {
            for (int col = 0, i = 0; col < 10; col++)
            {
                for (int row = 0; row < 10; row++, i++)
                {
                    if (row != 9)
                    {
                        // Check if the right neighbor is alive
                        if (spawnees[row + 1, col].GetComponent<organism>().isAlive == true)
                        {
                            spawnees[row, col].GetComponent<organism>().neigbours++;
                        }
                    }

                    if (row != 0)
                    {
                        // Check if the left neighbor is alive
                        if (spawnees[row - 1, col].GetComponent<organism>().isAlive == true)
                        {
                            spawnees[row, col].GetComponent<organism>().neigbours++;
                        }
                    }

                    if (col != 9)
                    {
                        // Check if the up neighbor is alive
                        if (spawnees[row, col + 1].GetComponent<organism>().isAlive == true)
                        {
                            spawnees[row, col].GetComponent<organism>().neigbours++;
                        }
                    }

                    if (col != 0)
                    {
                        // Check if the bottom neighbor is alive
                        if (spawnees[row, col - 1].GetComponent<organism>().isAlive == true)
                        {
                            spawnees[row, col].GetComponent<organism>().neigbours++;
                        }
                    }
                }
            }

            for (int col = 0, i = 0; col < 10; col++)
            {
                for (int row = 0; row < 10; row++, i++)
                {
                    if (spawnees[row, col].GetComponent<organism>().neigbours == 2 || spawnees[row, col].GetComponent<organism>().neigbours == 3)
                    {
                        spawnees[row, col].GetComponent<organism>().isAlive = true;
                    }
                    else
                    {
                        spawnees[row, col].GetComponent<organism>().isAlive = false;
                    }
                }
            }

            lastTime = currentTime;
        }
    }
}
