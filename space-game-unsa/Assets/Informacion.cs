using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informacion : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            uiObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        uiObject.SetActive(false);
    }
}
