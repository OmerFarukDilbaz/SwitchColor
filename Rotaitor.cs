﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaitor : MonoBehaviour
{
    
    public float spped = 100f;
    void Update()
    {
      transform.Rotate(0f,0f,spped * Time.deltaTime);    
    }
}
