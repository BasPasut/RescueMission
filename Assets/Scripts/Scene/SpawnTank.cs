using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTank : MonoBehaviour
{

    public List<Transform> SpawnPoints = new List<Transform>();
    private List<Animator> _tanks;
    private int loop = 0;
    public GameObject[] obj;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StaticClass.GetLevel.ToString());
        if (StaticClass.GetLevel == null)
        {
            loop = 1;
        }
        else if (StaticClass.GetLevel.ToString().ToLower().Contains("normal"))
        {
            loop = 2;
        }
        else if (StaticClass.GetLevel.ToString().ToLower().Contains("difficult"))
        {
            loop = 3;
        }
        else if (StaticClass.GetLevel.ToString().ToLower().Contains("nightmare"))
        {
            loop = 4;
        }

       // Debug.Log(loop+" shit");
        
            
        Spawn();
    }

    public void Awake()
    {
        _tanks = new List<Animator>();
        for (int i = 0; i < obj.Length; i++)
        {
            _tanks.Add(obj[i].GetComponent<Animator>());
        }

        Debug.Log(_tanks[0]);
        
    }

    void Spawn()
    {
        int spawnIndex;
        for (int i = 0; i < loop; i++)
        {
            obj[0].SetActive(true);
            spawnIndex = Random.Range(0, SpawnPoints.Count);
            Transform[] spawn = SpawnPoints.ToArray();
            Instantiate(obj[0], spawn[spawnIndex].position, spawn[spawnIndex].rotation);
            SpawnPoints.RemoveAt(spawnIndex);
        }
    }
}
