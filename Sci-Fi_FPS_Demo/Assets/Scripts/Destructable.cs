﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    [SerializeField]
    private GameObject _crackedCrate;

    public void DestroyCrate()
    {

        Instantiate(_crackedCrate, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}
