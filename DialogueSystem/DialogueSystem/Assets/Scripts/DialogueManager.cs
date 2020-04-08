using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	private event Action<string> ChoiceMade;
	private Image portrait;
	private TextMeshProUGUI actorName;
	private TextMeshProUGUI dialogueText;
	private bool isRunning;
	private Canvas canvas;

	public void StartDialogue()
	{
		
	}

	public void StopDialogue()
	{
		
	}

	private void ShowButton()
	{
		
	}

	private void PressButton()
	{
		//Debug.Log(EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text);
	}

	private void NextDialoguePiece()
	{
		
	}

	private void Skip()
	{
		
	}

	private void PlayLetterSound()
	{
		
	}

	private void PlaySound()
	{
		
	}

	private void PlayBackgroundMusic()
	{
		
	}
}
