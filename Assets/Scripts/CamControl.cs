using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform _lookAt;

    void Update()
    {
        transform.LookAt(_lookAt);
    }
}
