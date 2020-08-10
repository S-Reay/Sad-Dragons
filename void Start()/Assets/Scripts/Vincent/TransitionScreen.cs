using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    private static Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public static void PlayTransitionScreen() {
        anim.SetTrigger("Transition");
    }
}
