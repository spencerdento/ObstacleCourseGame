using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "tag_player") {
            other.gameObject.GetComponent<PlayerController>().Jump(3f);
        }
    }
}
