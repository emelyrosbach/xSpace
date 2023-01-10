using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cans : MonoBehaviour
{
    private float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Rock")
        {
            var direction = (transform.position - col.transform.position).normalized;
            transform.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
