using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Live : MonoBehaviour
{
    AudioSource[] audioSource;

    void Awake()
    {
        audioSource = new AudioSource[2];

        GameObject stage = Resources.Load<GameObject>("Stage");
        for (int i = 0; i < 2; i++)
        {
            GameObject go = Instantiate(
                stage,
                new Vector3(Global.Instance.distance / 2 * (i * 2 - 1), 0F, 0F),
                stage.transform.rotation
            );
            go.name = i == 0 ? "LeftStage" : "RightStage";
            audioSource[i] = go.transform.Find("AudioSource").GetComponent<AudioSource>();
            audioSource[i].clip =
                i == 0 ? Global.Instance.audioLeft : Global.Instance.audioRight;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource[0].isPlaying && !audioSource[1].isPlaying)
        {
            audioSource[0].PlayDelayed(Global.Instance.delayLeft);
            audioSource[1].PlayDelayed(Global.Instance.delayRight);
        }
    }

    public void OnSettingsButtonClicked()
    {
        SceneManager.LoadScene("Settings");
    }
}
