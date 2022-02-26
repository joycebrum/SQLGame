using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueController : MonoBehaviour
{
    [SerializeField] private Text clueText;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<Sprite> conclusionSprites;

    public bool isSolution;

    private string initialClue = "não achado ainda";
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetClueNote(string notFoundText)
    {
        SetAsNotFound(notFoundText);
    }

    public void SetAsFound(string clueContent)
    {
        this.gameObject.SetActive(true);
        this.initialClue = this.clueText.text;
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

    public void setAsHidden()
    {
        this.gameObject.SetActive(false);
    }
}
