using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChatDialogScriptableObject", order = 1)]
public class ChatDialogScriptableObject : ScriptableObject
{
    public Dictionary<string, List<string>> history = new Dictionary<string, List<string>>(); //user from: string -> messages: list<string>
}