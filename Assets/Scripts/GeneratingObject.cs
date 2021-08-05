using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneratingObject : MonoBehaviour
{


    public int appearanceDistance = 10;
    public GameObject[] cubeCreate;
    private GameObject cubes;
    private GameObject coins;
    public GameObject Coin;
    public List<GameObject> AllCoins = new List<GameObject>();

    protected int dis = -290;

    protected int fullDistance = 580;

    void Start()
    {
        CreateCube();
        CreateCoin();
    }


    void Update()
    {
        foreach (GameObject element in AllCoins)
        {
            if (element != null)
            {
                element.transform.Rotate(0, 0, 0.09f, Space.Self);
            }
            
        }
    }


    public void CreateCube()
    {

        for (int i = 0; i < 38; i++)
        {
            int rand = Random.Range(0, cubeCreate.Length);
            if (rand == 0 && i % 2 == 0)
            {
                cubes = Instantiate(cubeCreate[rand], new Vector3(-2.5f, 1.77f, -290 + i * 15), Quaternion.identity) as GameObject;
                cubes.transform.localScale = new Vector3(9, 4, 1);
            }
            else if(rand==0)
            {
               cubes = Instantiate(cubeCreate[rand], new Vector3(2.5f, 1.77f, -290 + i * 15), Quaternion.identity) as GameObject;
               cubes.transform.localScale = new Vector3(9, 4, 1);
            }
            if (rand == 1)
            {
               cubes = Instantiate(cubeCreate[rand], new Vector3(0,0.1f, -290 + i * 15), Quaternion.identity) as GameObject;
               cubes.transform.localScale = new Vector3(14, 0.5f, 1);
            }

        }
    }

    public void CreateCoin()
    {
        int rand = Random.Range(5, 11);

        for (int i = 0; i < rand; i++)
        {
            coins = Instantiate(Coin, new Vector3(0f, 1f, -290 + i * fullDistance/ rand), Quaternion.identity) as GameObject;
            coins.transform.localScale = new Vector3(1, 0.04f, 1);
            coins.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
            AllCoins.Add(this.coins);
        }
    }

}
