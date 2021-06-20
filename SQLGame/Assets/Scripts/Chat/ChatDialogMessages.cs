using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatDialogMessages
{
    public string from;
    public List<string> msgs;
    public List<DialogOption> options;

    public ChatDialogMessages(string from, List<string> msgs, List<DialogOption> options)
    {
        this.from = from;
        this.msgs = msgs;
        this.options = options;
    }
}
