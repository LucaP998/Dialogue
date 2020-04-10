using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class DialogueEncounter : MonoBehaviour
{
    public List<Dialogue> dialogues;
    public event Action ChoiceEvent;

    [Button]
    protected virtual void SendDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogues);
    }

    void StartEvent()
    {
        ChoiceEvent?.Invoke();
    }

}
