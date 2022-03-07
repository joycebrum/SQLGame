using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueController : MonoBehaviour
{
    [SerializeField] private Text clueText;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<Sprite> conclusionSprites;

    private bool inUse = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!inUse) SetAsHidden();
    }

    public void InitializeClue(string notFoundText)
    {
        inUse = true;
        SetAsNotFound(notFoundText);
    }

    public void InitializeSolution()
    {
        inUse = true;
        SetAsSolutionNotFound();
    }

    public void SetAsFound(string clueContent)
    {
        this.gameObject.SetActive(true);
        this.clueText.text = clueContent;

        this.clueText.color = new Color32(0, 0, 0, 255);

        GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Count)];
        GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void SetAsNotFound(string notFoundText)
    {
        this.gameObject.SetActive(true);
        this.clueText.text = notFoundText;

        this.clueText.color = new Color32(154, 150, 150, 255);

        GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Count)];
        GetComponent<Image>().color = new Color32(255, 255, 225, 50);
    }

    public void SetAsSolutionNotFound()
    {
        this.gameObject.SetActive(true);
        this.clueText.text = "";

        this.clueText.color = new Color32(154, 150, 150, 255);

        GetComponent<Image>().sprite = conclusionSprites[Random.Range(0, conclusionSprites.Count)];
        GetComponent<Image>().color = new Color32(255, 255, 225, 50);
    }

    public void SetAsHidden()
    {
        this.gameObject.SetActive(false);
    }
}
