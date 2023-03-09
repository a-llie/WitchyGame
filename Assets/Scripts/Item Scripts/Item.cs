using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemData data;
    public RuleTile plantVersion;

    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



}
