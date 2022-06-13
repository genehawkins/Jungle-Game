using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HowToPlay : MonoBehaviour
{
    [Header("Key Binds")]
    public KeyCode helpKey = KeyCode.F1;
    
    [Header("Unity Setup")]
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private TextMeshProUGUI bodyText;

    private bool active = false;
    private Canvas canvas;

    [Header("Text")] 
    [SerializeField][TextArea(8,15)][NonReorderable]
    private List<string> pages = new List<string>();
    private int pageIdx = 0;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        bodyText.text = pages[pageIdx];
    }

    public void NextPage()
    {
        pageIdx++;
        bodyText.text = pages[pageIdx];
    }

    public void PrevPage()
    {
        pageIdx--;
        bodyText.text = pages[pageIdx];
    }

    public void ToggleActive()
    {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0f : 1f;
    }


    //Disables side buttons on first and last pages
    void Update()
    {
        if (Input.GetKeyDown(helpKey))
        {
            ToggleActive();
        }
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        if (!active) return;
        leftButton.SetActive( pageIdx > 0 );
        rightButton.SetActive( pageIdx < pages.Count - 1 );
    }
}
