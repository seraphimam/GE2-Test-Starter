using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length = 10;

    //public GameObject nematode;
    public Material material;
    public GameObject sphere;

    Constrain range;

    void Awake()
    {
        //for(int i = 0; i < nematodeCount; i++){
            spawnNematode(length);
        //}
        

    }

    void spawnNematode(int len){
        Vector3 position = transform.position;
        float x = position.x;
        int r = 255;
        int g = 127;
        int b = 0;
        // Put your code here!
        for(int i = 0; i < len; i++){
            
            GameObject a = GameObject.Instantiate<GameObject>(sphere);

            r = (r - i*5) % 255;
            g = (g + i*5) % 255;
            b = (b + i*5) % 255;
            
            a.GetComponent<Renderer>().material.SetColor("_Color", new Color(r/255.0f, g/255.0f, b/255.0f, 1));

            if(i == 0){
                a.AddComponent<NoiseWander>();
                a.AddComponent<Constrain>();
            }

            if(i < length / 2 + 1){
                float r1 = 0.3f * (i+1);
                
                a.transform.localScale = new Vector3(r1/2, r1, r1/2); 
                
                a.transform.position = new Vector3(x, position.y, position.z); 
                x = a.transform.position.x + (r1/2);
                
            }else{
                float r2 = 0.3f * (len - i + 1);
                
                a.transform.localScale = new Vector3(r2/2, r2, r2/2);  
                a.transform.position = new Vector3(x, position.y, position.z);     
                x = a.transform.position.x + (r2/2);
            } 
             
            a.transform.parent = this.transform;
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        sphere.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
