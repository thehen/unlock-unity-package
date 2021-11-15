using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShape : MonoBehaviour
{
    void Update()
    {
        transform.Rotate( new Vector3(0.0f, 0.2f, 0.0f) );
    }
}
