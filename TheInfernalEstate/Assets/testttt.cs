using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testttt : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("SOMETHING");
        }
    }
}
