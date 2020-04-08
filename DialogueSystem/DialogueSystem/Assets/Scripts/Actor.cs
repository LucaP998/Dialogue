using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Actor", menuName = "Scriptables/Actor")]
[Serializable]
public class Actor : ScriptableObject
{
    public string actorName;
    
    [Serializable]
    public struct ReactionStruct
    {
        public Reaction reaction;
        public Sprite sprite;
    }

    public List<ReactionStruct> reactions = new List<ReactionStruct>();

    public Sprite GetSprite(Reaction reaction)
    {
        ReactionStruct result = reactions.Find(x => x.reaction == reaction);
        return result.sprite;
    }
    
}