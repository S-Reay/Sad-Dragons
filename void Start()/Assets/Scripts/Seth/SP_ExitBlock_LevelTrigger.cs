using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SP_ExitBlock_LevelTrigger : MonoBehaviour
{
    [SerializeField] int nextLevelID;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextLevelID);
        }
    }
}
