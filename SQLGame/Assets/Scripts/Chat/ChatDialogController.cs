using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatDialogController : MonoBehaviour
{
    [SerializeField] Transform messageParentPanel = null;
    [SerializeField] GameObject newPlayerMessagePrefab = null;
    [SerializeField] GameObject newMessagePrefab = null;
    [SerializeField] Image profile = null;
    [SerializeField] Text textName = null;

    [SerializeField] GameObject chatScreen = null;
    [SerializeField] GameObject contactScreen = null;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();

    private float messageWidth = 155;

    string message = "";

    void OnDisable()
    {
        DestroyAllMessages();
    }

    public void OnBackButton()
    {
        this.gameObject.SetActive(false);
    }


    public void SetMessage(string message)
    {
        this.message = message.Replace("#{player}", PlayerPrefs.GetString("playerName")).Replace("#{npc}", textName.text);
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
            float newHeight = GetMessageHeight();
            clone.GetComponent<RectTransform>().sizeDelta = new Vector2(this.messageWidth, newHeight);
            clone.GetComponent<MessageFunctions>().ShowMessage(message);
            this.message = null;
        }
    }

    private float GetMessageHeight()
    {
        if (message.Length > 28)
        {
            return Mathf.Ceil(message.Length / 28f) * 20;
        }
        else
        {
            return 20;
        }
    }

    public void ShowPlayerMessage()
    {
        GameObject clone = (GameObject)Instantiate(newPlayerMessagePrefab);

        clone.transform.SetParent(messageParentPanel);
        clone.transform.localScale = new Vector3(1f, 1f, 1f);
        clone.transform.GetChild(0).localScale = new Vector3(1f, 1f, 1f);

        float newHeight = GetMessageHeight();
        clone.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(this.messageWidth, newHeight);

        RectTransform rectTransform = clone.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(this.gameObject.GetComponent<RectTransform>().sizeDelta[0] - 28 , newHeight);

        clone.GetComponentInChildren<MessageFunctions>().ShowMessage(message);
        this.message = null;
    }

    public void OnContactSelect(int index)
    {
        switch (index)
        {
            case 0:
                this.gameObject.GetComponent<VIDEUIManager>().dialogueNameToLoad = Configuration.AIChat;
                ShowChat(index, Configuration.AIName); 
                break;
            case 1:
                this.gameObject.GetComponent<VIDEUIManager>().dialogueNameToLoad = Configuration.bossChat;
                ShowChat(index, Configuration.bossName);
                break;
            default: break;
        }
    }

    public void ShowChat(int spritePos, string name)
    {
        this.contactScreen.SetActive(false);
        this.chatScreen.SetActive(true);
        this.profile.sprite = this.sprites[spritePos];
        this.textName.text = name;
        this.gameObject.GetComponent<VIDEUIManager>().LoadChat();
    }

    public void ShowContacts()
    {
        this.contactScreen.SetActive(true);
        this.chatScreen.SetActive(false);
    }
}
