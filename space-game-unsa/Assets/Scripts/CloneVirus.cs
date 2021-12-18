using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneVirus : MonoBehaviour
{
    public int CantidadVirus = 1;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CantidadVirus; i++)
        {
            Instantiate(prefab, new Vector3(0, 10, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
