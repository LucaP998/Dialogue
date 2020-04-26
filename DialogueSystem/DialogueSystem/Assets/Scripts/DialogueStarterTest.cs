using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DialogueStarterTest : MonoBehaviour
{
    public Dialogue dialogue;

    [Button]
    public void DialogueTest()
    {
        DialogueManager.instance.StartDialogue(dialogue);
        DialogueManager.instance.ChoiceMade += Listener;
    }


    private void Listener(string message)
    {
        if (message == "Yes")
        {
            Debug.Log("sono incredibilmente triste");
        }
        else if (message == "No")
        {
            Debug.Log("sono moderatamente triste");
        }
    }
}
