using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabcollisions : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
