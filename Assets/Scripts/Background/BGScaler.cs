﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        
        transform.position = Vector3.zero;

        Vector3 temp = transform.localScale;
        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        temp.x = worldScreenWidth/width;
        temp.y = worldScreenHeight/height;
        transform.localScale = temp;
    }
    private void Update() {
      
    }

}
