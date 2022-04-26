using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NematodeSchool : MonoBehaviour
{
    public GameObject prefab;
    public GameObject nematode;

    [Range (1, 5000)]
    public int radius = 50;
    
    public int count = 10;

    Constrain range;

    // Start is called before the first frame update
    void Awake()
    {
        // Put your code here
        for(int i = 0; i < count; i++){
            GameObject a = GameObject.Instantiate<GameObject>(nematode);
            range = a.transform.GetChild(0).gameObject.AddComponent<Constrain>();
            range.center = transform.position;
            range.radius = radius;

            a.transform.parent = this.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
