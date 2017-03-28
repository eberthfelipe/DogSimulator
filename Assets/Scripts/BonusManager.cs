using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour {
    [Header("References")]
    public ScrollBonus bonusDogPrefab;
    public NestedPrefab nestedBonusDogPrefab;


    public Transform transform;
    public GameObject prefab;

    [Header("Creating time")]
    public float spawnTime = 10f;
    // Use this for initialization
    void Start () {
        //prefab = GetComponent<GameObject>();
        nestedBonusDogPrefab = GameObject.FindObjectOfType<NestedPrefab>();
        //transform = nestedBonusDogPrefab.transform;
        //Instantiate(transform);
        //Instantiate(prefab);
        InvokeRepeating("createBonusObject", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void createBonusObject()
    {
        //set bonus initial position
        //Vector3 position = new Vector3(10, Random.Range(-5.0f, 3.0f), 0);
        Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(0f, Random.Range(-5.0f, 3.0f), 0f));
        //transform.position = position;

        //prefab.GetComponent<NestedPrefab>().GeneratePrefabs();
        nestedBonusDogPrefab.GetComponent<NestedPrefab>().GeneratePrefabs();

        //GetComponent("BonusDogPrefab").GetComponent<NestedPrefab>().GeneratePrefabs();

    }

    void setBonusPosition(Vector3 position)
    {
        //FindObjectOfType<pre>
    }
}
