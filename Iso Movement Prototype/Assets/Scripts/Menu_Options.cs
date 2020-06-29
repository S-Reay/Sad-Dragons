using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Options : MonoBehaviour
{

    [SerializeField]

    public GameObject gamePanel;
    public GameObject auxPanel;
    public GameObject gfxPanel;

    public GameObject gameText;
    public GameObject auxText;
    public GameObject gfxText;

    public GameObject auxSliders;
    public GameObject gfxDropdowns;

    void Start()
    {
        gfxText.SetActive(false);
        gfxPanel.SetActive(false);
        auxText.SetActive(false);
        auxPanel.SetActive(false);
        gameText.SetActive(true);
        gamePanel.SetActive(true);
    }

    public void ChangeToGameTab()
    {
        gfxText.SetActive(false);
        gfxPanel.SetActive(false);
        auxText.SetActive(false);
        auxPanel.SetActive(false);
        gameText.SetActive(true);
        gamePanel.SetActive(true);
        auxSliders.SetActive(false);
        gfxDropdowns.SetActive(false);
    }

    public void ChangeToAuxTab()
    {
        gfxText.SetActive(false);
        gfxPanel.SetActive(false);
        auxText.SetActive(true);
        auxPanel.SetActive(true);
        gameText.SetActive(false);
        gamePanel.SetActive(false);
        auxSliders.SetActive(true);
        gfxDropdowns.SetActive(false);
    }

    public void ChangeToGFXTab()
    {
        gfxText.SetActive(true);
        gfxPanel.SetActive(true);
        auxText.SetActive(false);
        auxPanel.SetActive(false);
        gameText.SetActive(false);
        gamePanel.SetActive(false);
        auxSliders.SetActive(false);
        gfxDropdowns.SetActive(true);
    }
}
