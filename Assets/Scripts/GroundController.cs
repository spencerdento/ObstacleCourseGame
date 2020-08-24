using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

    public float smooth;
    private float frontRotation;
    private float sideRotation;


    // Start is called before the first frame update
    void Start() {
        smooth = 5.0f;

    }

    // Update is called once per frame
    void LateUpdate() {
        frontRotation = Input.GetAxis("Vertical") * 35.0f;
        sideRotation = Input.GetAxis("Horizontal") * -35.0f;

        Quaternion target = Quaternion.Euler(frontRotation, 0, sideRotation);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);


    }
}
