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
    public GameObject levelPanel;
    public GameObject learningPanel;

    public GameObject gameText;
    public GameObject auxText;
    public GameObject gfxText;
    public GameObject levelText;

    public GameObject auxSliders;
    public GameObject gfxDropdowns;

    void Start()
    {
        gfxText.SetActive(false);
        gfxPanel.SetActive(false);
        auxText.SetActive(false);
        auxPanel.SetActive(false);
        levelPanel.SetActive(false);
        levelText.SetActive(false);
        gameText.SetActive(true);
        gamePanel.SetActive(true);
        learningPanel.SetActive(false);
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
        levelPanel.SetActive(false);
        levelText.SetActive(false);
        learningPanel.SetActive(false);
    }

    public void ChangeToAuxTab()
    {
        gfxText.SetActive(false);
        gfxPanel.SetActive(false);
        auxText.SetActive(true);
        auxPanel.SetActive(true);
        gameText.SetActive(false);
        gamePanel.SetActive(true);
        auxSliders.SetActive(true);
        gfxDropdowns.SetActive(false);
        levelPanel.SetActive(false);
        levelText.SetActive(false);
        learningPanel.SetActive(false);
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
        levelPanel.SetActive(false);
        levelText.SetActive(false);
        learningPanel.SetActive(false);
    }

    public void ChangeToLevelTab()
    {
        gfxText.SetActive(false);
        gfxPanel.SetActive(false);
        auxText.SetActive(false);
        auxPanel.SetActive(false);
        gameText.SetActive(false);
        gamePanel.SetActive(false);
        auxSliders.SetActive(false);
        gfxDropdowns.SetActive(false);
        levelPanel.SetActive(true);
        levelText.SetActive(true);
        learningPanel.SetActive(false);
    }

    public void ChangeToLearningTab()
    {
        gfxText.SetActive(false);
        gfxPanel.SetActive(false);
        auxText.SetActive(false);
        auxPanel.SetActive(false);
        levelPanel.SetActive(false);
        levelText.SetActive(false);
        gameText.SetActive(false);
        gamePanel.SetActive(false);
        learningPanel.SetActive(true);
    }
}
