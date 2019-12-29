using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public SaveLoad saveLoad;

    public Text timeText;
    public Text actualTimeText;
    public Text bestTimeText;
    public GameObject characterChoosePanel;
    public Image characterChooseSprite;
    public GameObject NextBtn;
    public GameObject PrevBtn;
    public Sprite astolfo;
    public Sprite rikka;
    public Sprite claudius;
    int charNumber = 1;

    public GameObject Player;

    void Start()
    {
        saveLoad.Load();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
        characterChoosePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    void Update()
    {
        timeText.text = System.Math.Round(Time.timeSinceLevelLoad, 2).ToString() + " sec";
        actualTimeText.text = System.Math.Round(Time.timeSinceLevelLoad, 2).ToString() + " sec";
        bestTimeText.text = System.Math.Round(VariableTag.BEST+0.01f, 2).ToString() + " sec";
        switch (charNumber)
        {
            case 1:
                PrevBtn.GetComponent<Button>().interactable = false;
                characterChooseSprite.sprite = claudius;
                break;
            case 2:
                PrevBtn.GetComponent<Button>().interactable = true;
                NextBtn.GetComponent<Button>().interactable = true;
                characterChooseSprite.sprite = rikka;
                break;
            case 3:
                NextBtn.GetComponent<Button>().interactable = false;
                characterChooseSprite.sprite = astolfo;
                break;
            default:
                break;
        }

    }
    public void Next()
    {
        if(charNumber<=2)
        {
            charNumber += 1;
        }

    }
    public void Prev()
    {
        if (charNumber <= 3 && charNumber>1)
        {
            charNumber -= 1;
        }
    }
    public void Confirm()
    {
        Time.timeScale = 1f;
        characterChoosePanel.SetActive(false);
        Player.GetComponent<SpriteRenderer>().sprite = characterChooseSprite.sprite;
    }
}
