using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatDialogController : MonoBehaviour
{
    private List<ChatDialogMessages> stage1 = new List<ChatDialogMessages>{
        new ChatDialogMessages("Mina", 
            new List<string>{"Ah Joyce que bom poder falar com você"}, 
            new List<DialogOption> {
                new DialogOption("Quem é você?", "Como assim? Quem é você?", 1), 
                new DialogOption("Não tô afim de trote.", "Não tô afim de receber trote hoje, obrigada", 2)})
    };

    public void Start()
    {
        /*show messages from history*/
        ChatBoxFunctions chatBoxFunctions = gameObject.GetComponent<ChatBoxFunctions>();
        chatBoxFunctions.SetMessage(stage1[0].msgs[0]);
        chatBoxFunctions.ShowMessage();
    }

}
