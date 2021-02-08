using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
//using System.Numerics;
using UnityEngine;

public class movement : MonoBehaviour
{
    face_detector fd;
    public float speed = 5f;

    [Range(1f, 100f)]
    public float min_sensibility;
    [Range(1f, 100f)]
    public float max_sensibility;


    Vector3 last_pos = Vector3.zero;
    Vector3 move;

    Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        fd = (face_detector) FindObjectOfType(typeof(face_detector));
        manager = FindObjectOfType<Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(last_pos != Vector3.zero)
            move = last_pos - new Vector3(fd.face_x, fd.face_y, 0);
    

        if(min_sensibility < move.magnitude &&  move.magnitude < max_sensibility)
        {
            Vector3 current_pos = transform.position;
            transform.position = Vector3.Lerp(current_pos, current_pos + (move / 2), .05f);
        }

        last_pos = new Vector3(fd.face_x, fd.face_y, 0);

        manager.score += 10 * Time.deltaTime;
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "asteroid")
        {
            Destroy(collision.collider.gameObject);
            manager.lives--;

        }

    }
}
