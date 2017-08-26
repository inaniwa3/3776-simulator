using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed;

    void Awake()
    {
        speed = Global.Instance.playerSpeed * 1000 / 3600;
        transform.Translate(0F, 0F, -Global.Instance.distance / 2 - 2.5F);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h * speed * Time.deltaTime, 0F, v * speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            float x = Input.GetAxis("Mouse X");
            transform.Rotate(0F, x, 0F);
        }
    }
}
