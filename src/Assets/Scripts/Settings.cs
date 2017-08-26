using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Windows.Forms;

public class Settings : MonoBehaviour
{
    InputField[] inputField;

    void Awake()
    {
        inputField = new InputField[6];
        for (int i = 0; i < inputField.Length; i++)
        {
            GameObject go = GameObject.Find("InputField" + i.ToString());
            if (go)
            {
                inputField[i] = go.GetComponent<InputField>();
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        inputField[0].placeholder.GetComponent<Text>().text = Global.Instance.distance.ToString("0");
        inputField[1].placeholder.GetComponent<Text>().text = Global.Instance.playerSpeed.ToString("0");
        inputField[3].placeholder.GetComponent<Text>().text = Global.Instance.delayLeft.ToString("0.000");
        inputField[5].placeholder.GetComponent<Text>().text = Global.Instance.delayRight.ToString("0.000");

        if (Global.Instance.audioLeft == null)
        {
            StartCoroutine(GetAudio(UnityEngine.Application.streamingAssetsPath + "/" + Global.Instance.audioLeftName, true));
        }
        else
        {
            GameObject.Find("Text2").GetComponent<Text>().text =
                "Audio File for the Left Stage: " + Path.GetFileName(Global.Instance.audioLeftName);
        }
        if (Global.Instance.audioRight == null)
        {
            StartCoroutine(GetAudio(UnityEngine.Application.streamingAssetsPath + "/" + Global.Instance.audioRightName, false));
        }
        else
        {
            GameObject.Find("Text4").GetComponent<Text>().text =
                "Audio File for the Right Stage: " + Path.GetFileName(Global.Instance.audioRightName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEndEdit(int index)
    {
        float number;
        switch (index)
        {
            case 0:
                if (Single.TryParse(inputField[0].text, out number))
                {
                    Global.Instance.distance = number;
                }
                inputField[0].text = Global.Instance.distance.ToString("0");
                break;
            case 1:
                if (Single.TryParse(inputField[1].text, out number))
                {
                    Global.Instance.playerSpeed = number;
                }
                inputField[1].text = Global.Instance.playerSpeed.ToString("0");
                break;
            case 3:
                if (Single.TryParse(inputField[3].text, out number))
                {
                    Global.Instance.delayLeft = number;
                }
                inputField[3].text = Global.Instance.delayLeft.ToString("0.000");
                break;
            case 5:
                if (Single.TryParse(inputField[5].text, out number))
                {
                    Global.Instance.delayRight = number;
                }
                inputField[5].text = Global.Instance.delayRight.ToString("0.000");
                break;
        }
    }

    public void OnDialogButtonClicked(bool isLeft)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "Wav Files (*.wav)|*.wav";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            StartCoroutine(GetAudio(dialog.FileName, isLeft));
        }
    }

    IEnumerator GetAudio(string path, bool isLeft)
    {
        WWW www = new WWW("file:///" + path);
        yield return www;
        if (isLeft)
        {
            GameObject.Find("Text2").GetComponent<Text>().text =
                "Audio File for the Left Stage: " + Path.GetFileName(path);
            Global.Instance.audioLeftName = path;
            Global.Instance.audioLeft = www.GetAudioClip(true, false);
        }
        else
        {
            GameObject.Find("Text4").GetComponent<Text>().text =
                "Audio File for the Right Stage: " + Path.GetFileName(path);
            Global.Instance.audioRightName = path;
            Global.Instance.audioRight = www.GetAudioClip(true, false);
        }
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Live");
    }

    public void OnExitButtonClicked()
    {
        UnityEngine.Application.Quit();
    }
}
