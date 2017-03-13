using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    //public Transform enemy;
	// Use this for initialization
	public void Play () {
        Application.LoadLevel("Game");
        //enemy = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //Instantiate(enemy, new Vector3(1, 1, 0), Quaternion.identity);

    }
}
