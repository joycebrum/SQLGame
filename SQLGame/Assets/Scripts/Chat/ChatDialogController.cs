using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChatEnum { 
    ia = 0, patrocinio = 1, reporter = 2, amigo = 3, soares = 4
}

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
    [SerializeField] TutorialController tutorial;

    [SerializeField] OperationalSystemController main = null;

    [SerializeField] GameObject contactList;
    private ContactController[] contacts = null;

    private VIDEUIManager videUiManager;

    string message = "";

    void Start()
    {
        this.videUiManager = this.gameObject.GetComponent<VIDEUIManager>();
        InitializeContacts();

        if (tutorial.checkTutorial("MessageTutorialComplete"))
        {
            tutorial.StartTutorial(FinishTutorial);
        }
    }

    private void InitializeContacts()
    {
        this.contacts = this.contactList.GetComponentsInChildren<ContactController>(true);
    }

    void OnDisable()
    {
        DestroyAllMessages();
    }

    private void OnEnable()
    {
        if (this.contacts == null)
        {
            InitializeContacts();
        }   

        foreach (ContactController contactController in contacts)
        {
            contactController.gameObject.SetActive(true);
        }
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
        this.videUiManager.OnBackButton();
        DestroyAllMessages();
        ShowContacts();
    }

    public void OnCloseButton()
    {
        this.gameObject.SetActive(false);
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

    public static string GetDialogueName(ChatEnum type)
    {
        switch (type)
        {
            case ChatEnum.ia: return Constants.AIChat;
            case ChatEnum.patrocinio: return Constants.bossChat;
            case ChatEnum.reporter: return Constants.reporterChat;
            case ChatEnum.amigo: return Constants.friendChat;
            case ChatEnum.soares: return Constants.soaresChat;
            default: return null;
        }
    }

    public static string GetNPCName(ChatEnum type)
    {
        switch (type)
        {
            case ChatEnum.ia: return Constants.AIName;
            case ChatEnum.patrocinio: return Constants.bossName;
            case ChatEnum.reporter: return Constants.reporterName;
            case ChatEnum.amigo: return Constants.friendName;
            case ChatEnum.soares: return Constants.soaresName;
            default: return null;
        }
    }

    public void OnContactSelect(int index)
    {
        ChatEnum type = (ChatEnum)index;
        string dialogName = GetDialogueName(type);
        if (dialogName != null)
        {
            this.videUiManager.dialogueNameToLoad = dialogName;
            ShowChat(index, GetNPCName(type));
        }
            
    }

    public void ShowChat(int spritePos, string name)
    {
        this.contactScreen.SetActive(false);
        this.chatScreen.SetActive(true);
        this.textName.text = name;
        this.profile.sprite = this.videUiManager.getNPCSprite();
        this.videUiManager.LoadChat();
    }

    public void ReleaseChat(ChatEnum type)
    {
        string dialogName = GetDialogueName(type);
        if (dialogName != null)
        {
            PlayerPrefs.SetInt(dialogName, 2); // 0 or null - not blocked; 1 - blocked; 2 - released
            PlayerPrefs.SetInt("ShouldShow" + dialogName, 1);

            if (this.isActiveAndEnabled)
            {
                foreach (ContactController contactController in contacts)
                {
                    if (contactController.GetDialogName() == dialogName)
                    {
                        contactController.ShowContact();
                        break;
                    }
                }
            }

            main.SetMessageNotificationVisibility(isVisible: true);
        }
    }

    public void ShowContacts()
    {
        this.contactScreen.SetActive(true);
        this.chatScreen.SetActive(false);
    }

    private void FinishTutorial()
    {
        PlayerPrefs.SetInt("MessageTutorialComplete", 1);
    }

    private void FinishTutorialAfterFirstChat()
    {
        PlayerPrefs.SetInt("MessageTutorialComplete2", 1);
        main.ReleaseButton();
    }

    public void ContinueChatTutorial()
    {
        if (tutorial.checkTutorial("MessageTutorialComplete2"))
        {
            tutorial.StartTutorial(FinishTutorialAfterFirstChat);
        }
    }

    public void HasNewChats()
    {
        main.SetMessageNotificationVisibility(isVisible: ContactsHasNewMessages());
    } 

    private bool ContactsHasNewMessages()
    {
        foreach (ContactController contactController in this.contactScreen.GetComponentsInChildren<ContactController>())
        {
            if (contactController.HasNotification())
            {
                return true;
            }
        }
        return false;
    }
}
