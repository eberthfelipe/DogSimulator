using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBonus : MonoBehaviour {
    private ScoreManager scoreManager;
    // Use this for initialization
    
    [Header("Velocity")]
    public float bonusVelocity;

    // Use this for initialization
    void Start()
    {
        //set bonus initial position
        //Vector3 position = new Vector3(10, Random.Range(-5.0f, 3.0f), 0);
        //transform.position = position;
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * bonusVelocity * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            scoreManager.AddScore(20);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bonus")
        {
            Debug.Log(collision.collider.tag);
            Debug.Log("bonus");

        }
    }
}
