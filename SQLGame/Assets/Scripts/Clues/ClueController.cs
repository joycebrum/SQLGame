using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueController : MonoBehaviour
{
    [SerializeField] private Text clueText;
    [SerializeField] private List<Sprite> sprites;

    private string initialClue;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Count)];
    }

    public void SetAsFound(string clueContent)
    {
        this.initialClue = this.clueText.text;
        this.clueText.text = clueContent;

        this.clueText.  color = new Color32(0, 0, 0, 255);

        GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void SetAsNotFound()
    {
        this.clueText.text = initialClue;

        this.clueText.GetComponent<Image>().color = new Color32(154, 150, 150, 255);

        GetComponent<Image>().color = new Color32(255, 255, 225, 50);
    }
}
