using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TargetManager : MonoBehaviour
{

    public GameObject[] targets;
    private Vector3[] initialPositions;
    private Quaternion[] intiialRotations;

    // Start is called before the first frame update
    void Start()
    {
        initialPositions = new Vector3[targets.Length];
        intiialRotations = new Quaternion[targets.Length];
        for (int i = 0; i < targets.Length; ++i) {
            initialPositions[i] = targets[i].transform.position;
            intiialRotations[i] = targets[i].transform.rotation;
         }
    }

    // Update is called once per frame
    void Update()
    {
        bool reset = true;
        for (int i = 0; i < targets.Length; ++i) {
            if (targets[i].transform.position.y == initialPositions[i].y || targets[i].GetComponent<Rigidbody>().velocity != Vector3.zero)
                reset = false;
        }
        if (reset)
            ResetTargets();
    }

    void ResetTargets() {
        for (int i = 0; i < targets.Length; ++i) {
            targets[i].transform.position = initialPositions[i];
            targets[i].transform.rotation = intiialRotations[i];
         }
    }
}
