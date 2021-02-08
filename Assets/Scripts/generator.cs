using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public GameObject pref_1;
    public GameObject pref_2;
    GameObject[] prefs;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        prefs = new GameObject[] { pref_1, pref_2 };
        player = GameObject.FindGameObjectWithTag("player");
        InvokeRepeating("CreateAstr", 2.0f, 2f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateAstr()
    {
        Vector3 pos = new Vector3(Random.Range(-10, 10), Random.Range(-2, 10), 90);
        //Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, 100);
        Instantiate(prefs[Random.Range(0, 1)], pos, Quaternion.identity);
    }
}
