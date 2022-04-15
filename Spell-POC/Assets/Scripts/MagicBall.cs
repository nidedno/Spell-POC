using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public bool Collided = false;
    public Transform collider;
    public Vector3 point;


    private void OnCollisionEnter(Collision collision)
    {
        if (!Collided)
        {
            point = transform.position;
            collider = collision.transform;
            Collided = true;
            Debug.Log(collider.name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
