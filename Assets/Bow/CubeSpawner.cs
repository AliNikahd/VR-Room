using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    public GameObject cubePrefab;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (time > 2.0f)
        {
            GameObject cube = Instantiate(cubePrefab);
            cube.transform.parent = this.transform;
            cube.transform.localPosition = Vector3.zero;
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            time = 0.0f;
        }
        time += Time.deltaTime;
    }
}
