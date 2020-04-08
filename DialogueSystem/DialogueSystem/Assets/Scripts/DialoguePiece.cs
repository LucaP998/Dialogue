using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialoguePiece", menuName = "Scriptables/DialoguePiece")]
public class DialoguePiece : ScriptableObject
{
    public Actor actor;
    public Reaction reaction;
    public string dialogueText;
    public AudioClip letterSound;
    public AudioClip sound;
    public AudioClip backgroundSound;
    public float dialogueSpeed = 1;
    
}
