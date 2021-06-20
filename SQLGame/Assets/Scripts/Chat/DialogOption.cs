using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOption
{
    string option;
    string msg;
    int next;

    public DialogOption(string option, string msg, int next)
    {
        this.option = option;
        this.msg = msg;
        this.next = next;
    }
}
