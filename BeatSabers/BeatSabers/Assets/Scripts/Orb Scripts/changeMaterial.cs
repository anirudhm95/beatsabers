using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterial : MonoBehaviour {
    public Material[] material;
    public Renderer rend;
    BoxCollider myCollider;
    private BoxCollider lineCollider;
    private GameObject line;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        myCollider = GetComponent<BoxCollider>();
        line = GameObject.Find("LineHitBox");

        lineCollider = line.GetComponent<BoxCollider>() as BoxCollider;
    }


    // Update is called once per frame
    void Update () {
        if (myCollider.bounds.Intersects(lineCollider.bounds))
        {
            Debug.Log("hit hit hit");
            rend.sharedMaterial = material[1];
        }
    }
}
