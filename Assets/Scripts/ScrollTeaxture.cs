﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTeaxture : MonoBehaviour {

    [Header("Scene References")]
    public Material material;

    [Header("Velocity")]
    public Vector2 scrollVelocity;

    private Vector2 scrollOffset;

    // Use this for initialization
    void Start () {
        scrollOffset = Vector2.zero;

        material.mainTextureOffset = scrollOffset;
        // Outra forma abaixo:
        //material.SetTextureOffset("_MainTex", scrollOffset);
    }

    // Update is called once per frame
    void Update () {
        // Atualiza offset
        scrollOffset += scrollVelocity * Time.deltaTime;

        material.mainTextureOffset = scrollOffset;
    }
}
