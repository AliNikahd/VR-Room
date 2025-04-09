using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public float frequency;
    public float x;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x*Mathf.Sin(2 * Mathf.PI * frequency * Time.time), 0, z);
    }
}
