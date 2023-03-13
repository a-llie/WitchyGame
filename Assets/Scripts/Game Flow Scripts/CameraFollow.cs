using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    //update camera script so it stays within bounds
    private int left = -40; 
    private int right = 30;
    private int top = 15;
    private int bottom = -30;  

    Vector3 camOffset;
    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        transform.position = target.position + camOffset;
    }

}
