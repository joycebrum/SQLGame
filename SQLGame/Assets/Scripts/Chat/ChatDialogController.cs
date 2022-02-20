﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatDialogController : MonoBehaviour
{
    [SerializeField] private Transform messageParentPanel = null;
    [SerializeField] private ScrollRect scrollRect = null;

    [SerializeField] private GameObject newPlayerMessagePrefab = null;
    [SerializeField] private GameObject newMessagePrefab = null;
    [SerializeField] private Image profile = null;
    [SerializeField] private Text textName = null;

    [SerializeField] private GameObject chatScreen = null;
    [SerializeField] private GameObject contactScreen = null;

    string message = "";

    void OnDisable()
    {
        DestroyAllMessages();
    }

    private void UpdateScrollRect()
    {
        Canvas.ForceUpdateCanvases();

        messageParentPanel.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        messageParentPanel.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        scrollRect.verticalNormalizedPosition = 0;
    }

    public void OnBackButton()
    {
        DestroyAllMessages();
        ShowContacts();
    }

    public void SetMessage(string message)
    {
        this.message = message.Replace("#{player}", PlayerPrefs.GetString("playerName"))
            .Replace("#{npc}", textName.text)
            .Replace("#{playerFull}", PlayerPrefs.GetString("playerFullName"));
    }
     
    public void DestroyAllMessages()
    {
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[messageParentPanel.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in messageParentPanel)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

    }

    public void ShowMessage()
    {
        if (message != "")
        {
            GameObject clone = (GameObject)Instantiate(newMessagePrefab);
            clone.transform.SetParent(messageParentPanel);
            clone.transform.localScale = new Vector3(1f, 1f, 1f);
            clone.GetComponent<MessageFunctions>().ShowMessage(message);
            this.message = null;

            UpdateScrollRect();
        }
    }

    public void ShowPlayerMessage()
    {
        GameObject clone = (GameObject)Instantiate(newPlayerMessagePrefab);

        clone.transform.SetParent(messageParentPanel);
        clone.transform.localScale = new Vector3(1f, 1f, 1f);

        clone.GetComponentInChildren<MessageFunctions>().ShowMessage(message);
        this.message = null;

        UpdateScrollRect();
    }

    private string GetDialogueName(int index)
    {
        switch (index)
        {
            case 0: return Constants.AIChat;
            case 1: return Constants.bossChat;
            case 2: return Constants.reporterChat;
            default: return null;
        }
    }

    private string GetNPCName(int index)
    {
        switch (index)
        {
            case 0: return Constants.AIName;
            case 1: return Constants.bossName;
            case 2: return Constants.reporterName;
            default: return null;
        }
    }

    public void OnContactSelect(int index)
    {
        string dialogName = GetDialogueName(index);
        if (dialogName != null)
        {
            this.gameObject.GetComponent<VIDEUIManager>().dialogueNameToLoad = dialogName;
            ShowChat(index, GetNPCName(index));
        }
            
    }

    public void ShowChat(int spritePos, string name)
    {
        this.contactScreen.SetActive(false);
        this.chatScreen.SetActive(true);
        this.textName.text = name;
        VIDEUIManager videUiManager = this.gameObject.GetComponent<VIDEUIManager>();
        this.profile.sprite = videUiManager.getNPCSprite();
        videUiManager.LoadChat();
    }

    public void ReleaseChat(int index)
    {
        string dialogName = GetDialogueName(index);
        if (dialogName != null)
        {
            PlayerPrefs.SetInt(GetDialogueName(index), 2); // 0 or null - not blocked; 1 - blocked; 2 - released
            // TODO: Add visual notification of new message
        }
    }

    public void ShowContacts()
    {
        this.contactScreen.SetActive(true);
        this.chatScreen.SetActive(false);
    }
}
