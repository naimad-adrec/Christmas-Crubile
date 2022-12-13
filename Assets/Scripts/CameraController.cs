using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform santa;

    void Update()
    {
        transform.position = new Vector3(santa.position.x, transform.position.y, transform.position.z);
    }
}
