using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<BirdController>() != null) ;//无论通过什么触发器，检查它是不是鸟
        {
            GameControl.instance.BirdScored ();
        }
    }
}
