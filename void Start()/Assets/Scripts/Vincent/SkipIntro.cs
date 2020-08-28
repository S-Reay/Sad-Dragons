using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneController.i.LoadSceneBySec(1);
        }
    }


    public void ChairSound() {
        SoundManager.PlaySound(SoundEffect.chair_move);
    }

    public void BedSound() {
        SoundManager.PlaySound(SoundEffect.bed);
    }
}
