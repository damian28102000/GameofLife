﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[,] spawnees;
    float lastTime;
    public float everySeconds;
    public int width;
    public int height;

    void Start()
    {
        // Create surface of organisms
        spawnees = new GameObject[width, height];
        for(int col =0, i =0;col<height;col++)
        {
            for(int row =0;row<width;row++,i++)
            {
                spawnees[row,col] = Instantiate(prefab, new Vector3(6*row, 0, 6*col), Quaternion.identity);
            }
        }

        // Filling the surface with randomly living organisms
        for(int i =0;i<height*width;i++)
        {
            spawnees[Random.Range(0,width), Random.Range(0, height)].GetComponent<organism>().isAlive = true;
        }

        /*
        // Kit for test algorithm 
        spawnees[1, 0].GetComponent<organism>().isAlive = true;
        spawnees[0, 1].GetComponent<organism>().isAlive = true;
        spawnees[0, 2].GetComponent<organism>().isAlive = true;
        spawnees[1, 2].GetComponent<organism>().isAlive = true;
        spawnees[2, 2].GetComponent<organism>().isAlive = true;
        */
    }

    void Update()
    {
        // Every given time
        float currentTime = Time.time;
        if (currentTime - lastTime >=everySeconds)
        {
            ResetNeighbours();
            CountNeighbours();

            // Update surface taking into account new neigbours
            for (int col = 0; col < height; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    //Debug.Log("Organizm [" +0+","+3+"] has "+ spawnees[0, 3].GetComponent<organism>().neigbours);
                    if (spawnees[row, col].GetComponent<organism>().isAlive == true && (spawnees[row, col].GetComponent<organism>().neigbours == 2 || spawnees[row, col].GetComponent<organism>().neigbours == 3))
                    {
                        spawnees[row, col].GetComponent<organism>().isAlive = true;
                    }
                    else if (spawnees[row, col].GetComponent<organism>().isAlive == false && spawnees[row, col].GetComponent<organism>().neigbours == 3)
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

    // Clear board 
    private void ResetNeighbours()
    {
        for (int col = 0, i = 0; col < height; col++)
        {
            for (int row = 0; row < width; row++, i++)
            {
                spawnees[row, col].GetComponent<organism>().neigbours = 0;
            }
        }
    }

    // Count neighbours
    private void CountNeighbours()
    {
        for (int col = 0, i = 0; col < height; col++)
        {
            for (int row = 0; row < width; row++, i++)
            {
                if (row != width - 1)
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

                if (col != height - 1)
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

                if(col != height-1 && row != width-1)
                {
                    // Check if the top-right neighbor is alive
                    if (spawnees[row+1, col + 1].GetComponent<organism>().isAlive == true)
                    {
                        spawnees[row, col].GetComponent<organism>().neigbours++;
                    }
                }

                if (col != height - 1 && row != 0)
                {
                    // Check if the top-left neighbor is alive
                    if (spawnees[row -1, col + 1].GetComponent<organism>().isAlive == true)
                    {
                        spawnees[row, col].GetComponent<organism>().neigbours++;
                    }
                }

                if (col != 0 && row != width -1)
                {
                    // Check if the bottom-right neighbor is alive
                    if (spawnees[row + 1, col - 1].GetComponent<organism>().isAlive == true)
                    {
                        spawnees[row, col].GetComponent<organism>().neigbours++;
                    }
                }

                if (col != 0 && row != 0)
                {
                    // Check if the bottom-left neighbor is alive
                    if (spawnees[row-1, col - 1].GetComponent<organism>().isAlive == true)
                    {
                        spawnees[row, col].GetComponent<organism>().neigbours++;
                    }
                }
            }
        }
    }
}
