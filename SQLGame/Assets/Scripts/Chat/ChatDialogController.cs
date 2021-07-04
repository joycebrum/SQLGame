using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChatDialogController : MonoBehaviour
{
    [SerializeField] Transform messageParentPanel = null;
    [SerializeField] GameObject newMessagePrefab = null;
    [SerializeField] Image profile = null;
    [SerializeField] Text textName = null;

    [SerializeField] GameObject chatScreen = null;
    [SerializeField] GameObject contactScreen = null;
    [SerializeField] List<Sprite> sprites;

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
            RectTransform rectTransform = clone.GetComponent<RectTransform>();
            if (message.Length > 28)
            {
                rectTransform.sizeDelta = new Vector2(150, 20 + ((int)message.Length / 28) * 20);
            }
            else
            {
                rectTransform.sizeDelta = new Vector2(150, 20);
            }
            clone.GetComponent<MessageFunctions>().ShowMessage(message);
            this.message = null;
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
