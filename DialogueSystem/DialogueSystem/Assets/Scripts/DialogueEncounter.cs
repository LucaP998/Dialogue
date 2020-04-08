using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueEncounter : MonoBehaviour
{
    public List<Dialogue> dialogues;
    public event Action ChoiceEvent;

    protected virtual void SendDialogue()
    {
        
    }

    void StartEvent()
    {
        ChoiceEvent?.Invoke();
    }

}
