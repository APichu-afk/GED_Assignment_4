using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartAndEdit : MonoBehaviour
{
    public CanvasGroup UI;
    public CanvasGroup play;
    public Camera editcam;
    public Camera playcam;
    // Start is called before the first frame update
    void Start()
    {
        playcam.enabled = false;
        editcam.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))//Changes to play mode
        {
            HideUI();
            playcam.enabled = true;
            editcam.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.O))//Changes to edit mode
        {
            ShowUI();
            playcam.enabled = false;
            editcam.enabled = true;
        }
    }

    void HideUI()
    {
        UI.alpha = 0.0f;
        play.alpha = 1.0f;
        UI.blocksRaycasts = false;
        play.blocksRaycasts = true;
    }

    void ShowUI()
    {
        UI.alpha = 1.0f;
        play.alpha = 0.0f;
        UI.blocksRaycasts = true;
        play.blocksRaycasts = false;
    }
}
