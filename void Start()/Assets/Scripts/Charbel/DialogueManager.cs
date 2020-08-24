using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshPro nameText;
    public TextMeshPro dialogueText;

 //   public Animator animator;
    private Queue<string> sentances;

    void Start()
    {
        sentances = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
       // animator.SetBool("IsOpen", true);

        //nameText.text = dialogue.name;

        sentances.Clear();

        foreach (string sentance in dialogue.sentances)
        {
            sentances.Enqueue(sentance);

        }
        DisplayNextSentance();
    }



    public void DisplayNextSentance()
    {
        if (sentances.Count == 0)

        {
           // EndDialogue();
            return;
        }

        string sentance = sentances.Dequeue();
        dialogueText.text = sentance;

        //    StopAllCoroutines();
        //    StartCoroutine(TypeSentance(sentance));
        //    }

        //IEnumerator TypeSentance (string sentance)
        //{
        //    dialogueText.text = "";
        //    foreach (char letter in sentance.ToCharArray())
        //    {
        //        dialogueText.text += letter;
        //        yield return null;
        //    }
        //}

        //void EndDialogue()
        //{
        //    animator.SetBool("IsOpen", false);
        //}
    }
}


    

  

