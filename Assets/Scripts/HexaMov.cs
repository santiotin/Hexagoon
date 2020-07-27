using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaMov : MonoBehaviour
{
    public Rigidbody2D rb;
    float shrinkSpeed = 2.7f;
    float rotationSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, rotationSpeed, Space.Self);

        if(transform.localScale.x <= 0.05f) {
            Destroy(gameObject);
        }
    }

    public void setRotationSpeed(float rSpeed) {
        rotationSpeed = rSpeed;
    }
}
