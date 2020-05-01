using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace DialogueSystem
{
    [Serializable]
    public class DialoguePiece
    {
        [OnValueChanged("RefreshSprite")] public Actor actor;
        [VerticalGroup("Reaction")] [OnValueChanged("RefreshSprite")] [HideLabel]
        public Reaction reaction;
        [VerticalGroup("Reaction")] [PreviewField(ObjectFieldAlignment.Center)] [HideLabel]
        public Sprite spriteReaction;
        [TextArea, TableColumnWidth(59)] public string dialogueText;
        [VerticalGroup("Sound")] [TableColumnWidth(50)] [LabelText("Letter")]
        public AudioClip letterSound;
        [VerticalGroup("Sound")] public AudioClip sound;
        // [VerticalGroup("Sound")] [LabelText("BGM")]
        // public AudioClip backgroundSound;
        [FormerlySerializedAs("dialogueSpeed")]
        public float speed = 0.1f;

        public void RefreshSprite()
        {
            spriteReaction = actor.GetSprite(reaction);
        }
    }
}
