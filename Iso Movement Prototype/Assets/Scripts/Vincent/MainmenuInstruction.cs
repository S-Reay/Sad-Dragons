using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuInstruction : MonoBehaviour
{
    public List<SpriteRenderer> mainBackGround;
    public GameObject mainTrigger;
    public Player_mainMenu pm;

    [SerializeField]
    private bool isFinished;
    private float colorValue;


    void Start()
    {
        for (int i = 0; i < mainBackGround.Count; i++)
        {
            mainBackGround[i].color = new Color(0,0,0,0);
        }
        mainTrigger.SetActive(false);
    }

    void Update()
    {
        if (pm.isPicking) {
            isFinished = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isFinished = true;
        }
        if (isFinished) {
            pm.directionInstruction.gameObject.SetActive(false);
            if (colorValue <= 1)
            {
                colorValue += Time.deltaTime;
                for (int i = 0; i < mainBackGround.Count; i++)
                {
                    mainBackGround[i].color = new Color(colorValue, colorValue, colorValue, colorValue);
                }
            }
            else {
                mainTrigger.SetActive(true);
            }
        }
    }
}
