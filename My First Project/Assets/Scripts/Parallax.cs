using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, start, pos;
    public float speed;

    void Start() {
        start = transform.position.x;
        pos = start;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        pos += (speed * Time.deltaTime);
        transform.position = new Vector3(pos, transform.position.y, transform.position.z);
        
        if (pos > start + length/2) {
            pos -= length;
        } else if (pos < start - length/2) {
            pos += length;
        }
    }
}
