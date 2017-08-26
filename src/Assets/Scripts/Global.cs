using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public float distance;
    public float playerSpeed;
    public string audioLeftName;
    public AudioClip audioLeft;
    public float delayLeft;
    public string audioRightName;
    public AudioClip audioRight;
    public float delayRight;

    public static Global Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        distance = 25F;
        playerSpeed = 5F;
        audioLeftName = "LeftSample.wav";
        delayLeft = 0.0F;
        audioRightName = "RightSample.wav";
        delayRight = 0.0F;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
