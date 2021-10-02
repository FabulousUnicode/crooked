using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset inkFile;
    Story story;

    public void TriggerDia()
    {
        //FindObjectOfType<Dialogue>().StartDialogue(inkFile);
    }
}
