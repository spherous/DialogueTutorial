using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private DialogueStrip currentStrip;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private int currentStripIndex = 0;

    private void Start()
    {
        DisplayDialogue(currentStrip.dialogueList[currentStripIndex]);
    }

    public void DisplayDialogue(Dialogue toDisplay)
    {
        nameText.text = toDisplay.speaker;
        dialogueText.text = toDisplay.dialogue;
    }

    public void NextDialogue(CallbackContext context)
    {
        if(!context.performed)
            return;
        
        currentStripIndex = currentStripIndex + 1 > currentStrip.dialogueList.Count - 1 ? 0 : currentStripIndex + 1;
        DisplayDialogue(currentStrip.dialogueList[currentStripIndex]);
    }
}