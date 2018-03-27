using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseClick : MonoBehaviour {
    private bool _clickable = false;
    private Collider2D myCollider;
    public LineRenderer myLine;
    // Use this for initialization
    void Start () {
        myCollider = gameObject.GetComponent<Collider2D>();
	}

    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
        OnTriggerEnter(myCollider);
        //OnTriggerExit(myCollider);
        

    }



    void OnTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "line")
        {
            Debug.Log("hit hit hit");
            _clickable = true;
        }
    }


    void OnMouseDown()
    {
        if (!_clickable) return;
        //do your interaction stuff below this line
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    Destroy(bc.gameObject);
                }
            }
        }
    }

    
    //void OnTriggerExit(Collider2D other)
    //{
    //    if (other.gameObject.name != "LineRenderer")
    //    {
    //        Debug.Log("nope nope nope");
    //        _clickable = false;
    //    }
    //}


}
