using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBonus : MonoBehaviour {

    [Header("Velocity")]
    public float bonusVelocity;

    // Use this for initialization
    void Start()
    {
        //set bonus initial position
        //Vector3 position = new Vector3(10, Random.Range(-5.0f, 3.0f), 0);
        //transform.position = position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * bonusVelocity * Time.deltaTime;
    }
}
