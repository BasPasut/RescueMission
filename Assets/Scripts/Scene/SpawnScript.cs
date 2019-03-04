using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public List<Transform> SpawnPoints = new List<Transform>();
    private List<Animator> Hostages;
    public GameObject[] obj;

    // Start is called before the first frame update
    void Start()
    {
        SpawnHostage();
    }

    public void Awake()
    {
        Hostages = new List<Animator>();
        for (int i = 0; i < obj.Length; i++)
        {
            Hostages.Add(obj[i].GetComponent<Animator>());
        }
    }

    void SpawnHostage()
    {
        int spawnIndex;
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(true);
            spawnIndex = Random.Range(0, SpawnPoints.Count);
            Transform[] spawn = SpawnPoints.ToArray();
            Instantiate(obj[i], spawn[spawnIndex].position, spawn[spawnIndex].rotation);
            SpawnPoints.RemoveAt(spawnIndex);
        }
    }
}
