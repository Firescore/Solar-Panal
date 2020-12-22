using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placingPlaceCheck : MonoBehaviour
{
    public GameObject hitChecker;



    RaycastHit hit;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RAYCAST();
    }
    void RAYCAST()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            hitChecker.transform.position = hit.transform.position;
        }
    }
}
