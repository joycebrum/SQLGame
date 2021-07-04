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
    [SerializeField] List<Sprite> sprites;

    private float messageWidth = 155;

    string message = "";


    public void Start()
    {
    }

    public void OnBackButton()
    {
        this.gameObject.SetActive(false);
    }


    public void SetMessage(string message)
    {
        this.message = message.Replace("#{player}", PlayerPrefs.GetString("playerName")).Replace("#{npc}", textName.text);
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
            return ((int)message.Length / 28) * 20;
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
            case 0: ShowChat(index, Configuration.AIName); break;
            default: break;
        }
    }

    public void ShowChat(int spritePos, string name)
    {
        this.contactScreen.SetActive(false);
        this.chatScreen.SetActive(true);
        this.profile.sprite = this.sprites[spritePos];
        this.textName.text = name;
    }

    public void ShowContacts()
    {
        this.contactScreen.SetActive(true);
        this.chatScreen.SetActive(false);
    }
}
