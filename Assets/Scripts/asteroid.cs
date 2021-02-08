using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Random.Range(15f, 30f);
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < -10)
            Destroy(gameObject);
    }
}
