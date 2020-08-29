using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//IF ROCK = 3
//THEN EXIT IS TRUE
public class SP_2_2_IFTHEN : MonoBehaviour
{
    [SerializeField] private List<GameObject> rocks = new List<GameObject>();
    public TMP_Text rockText;
    public GameObject exit;

    private void Start()
    {
        UpdateRockCount();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            UpdateRockCount();
        }
    }
    public void UpdateRockCount()
    {
        StartCoroutine(Delayed());
    }
    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Updating Rock Count");
        rocks.Clear();
        foreach (GameObject rock in GameObject.FindGameObjectsWithTag("Rock"))
        {
            rocks.Add(rock);
        }
        rockText.text = rocks.Count.ToString();

        if (rocks.Count == 3)
        {
            exit.SetActive(true);
        }
        else
        {
            exit.SetActive(false);
        }
    }
}
