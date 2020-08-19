using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Linq;

[CreateAssetMenu]
public class DialogueStrip : ScriptableObject
{
    public TextAsset dialogueScript;
    public List<Dialogue> dialogueList = new List<Dialogue>();

    [Button]
    public void ReloadScript()
    {
        dialogueList.Clear();
        
        if(dialogueScript == null)
            return;

        string[] lines = dialogueScript.text.Split(new string[]{Environment.NewLine}, StringSplitOptions.None);
        
        // Convert string[] to List<Dialogue>
        dialogueList.AddRange(lines.Select((line) => {
            Match match = Regex.Match(line, @"(?<speaker>.*): (?<dialogue>.*)");
            return match.Success
                ? new Dialogue{speaker = match.Groups["speaker"].Value, dialogue = match.Groups["dialogue"].Value} //True
                : new Dialogue{dialogue = line}; // False
        }));
    }
}