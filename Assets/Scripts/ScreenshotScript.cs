﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Code for OnMouseDown in the iPhone. Unquote to test.
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SendMessage("OnMouseDown");
                }
            }
        }
    }

    void OnMouseDown()
    {
        Application.CaptureScreenshot("Screenshot.png");
    }

    public void saveScreenShot()
    {
        Application.CaptureScreenshot("Screenshot.png");
    }
}
