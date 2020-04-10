using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
	public bool isRunning; 
	private event Action<string> ChoiceMade;
	[SerializeField] private Image portrait;
	[SerializeField] private Image backgroundView;
	[SerializeField] private Image textBackground;
	[SerializeField] private TextMeshProUGUI actorName;
	[SerializeField] private TextMeshProUGUI dialogueText;
	[SerializeField] private Canvas canvas;
	[SerializeField] private AudioSource letterSource;
	private int currentPiece;
	public Dialogue dialogue;

	public void StartDialogue(List<Dialogue> dialogueToShow)
	{
		
	}

	private void StopDialogue() {
		canvas.enabled = false;
	}

	private void ShowButton()
	{
		
	}

	private void PressButton()
	{
		//Debug.Log(EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text);
	}

	private void NextDialoguePiece() {
		currentPiece++;
		if (currentPiece < dialogue.dialoguePieces.Count) {
			StartCoroutine(RunningDialoguePiece(dialogue.dialoguePieces[currentPiece]));
		}
		else {
			StopDialogue();
		}
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
	
	[Button]
	private void DebugUI() {
		StartCoroutine(RunningDialoguePiece(dialogue.dialoguePieces[currentPiece]));
	}

	IEnumerator RunningDialoguePiece(DialoguePiece piece) {
		bool isSkip = false;
		actorName.text = piece.actor.name;
		portrait.sprite = piece.spriteReaction;
		dialogueText.text = "";
		foreach (char c in piece.dialogueText) {
			dialogueText.text += c;
			letterSource.clip = piece.letterSound;
			letterSource.Play();
			for (int i = 0; i < piece.speed * 60; i++) {
				if (Input.anyKeyDown) {
					dialogueText.text = piece.dialogueText;
					isSkip = true;
					break;
				}
				yield return null;
			}
			if (isSkip) {
				break;
			}
			yield return null;
		}
		yield return StartCoroutine(WaitForInput());
		NextDialoguePiece();
		yield return null;
	}

	IEnumerator WaitForInput() {
		bool pressed = false;
		while (!pressed) {
			if (Input.anyKeyDown) {
				pressed = true;
				yield return null;
			}
			yield return null;
		}
	}
}
