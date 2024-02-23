using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestBar : MonoBehaviour
{
    public static QuestBar instance;
    public GameObject questPanel;
    public TextMeshProUGUI questText;
    public GameObject player;
    public GameObject npc;
    public TextMeshProUGUI scoreText;
    public string[] quest;
    public int index;
    public int numCompletedQuests = 0;



    private void Awake() {
        instance = this;
    }

    public void Start()
    {
        questText.text = quest[index];
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = numCompletedQuests.ToString() + " Chou Yee Points";
    }

    public void noQuest()
    {
        questText.text = "NONE";
        index = 0;
        // dialoguePanel.SetActive(false);

    }

    public void NextQuest()
    {
        if (index < quest.Length - 1)
        {
            index++;
            questText.text = quest[index];

        }
        else 
        {
            noQuest();
        }
    }

    public bool completeQuest(int i){
        if (i == 0){
            if (npc.GetComponent<NPC>().talkedToBucky == true){
                numCompletedQuests++;
                UpdateScoreText();
                NextQuest();
                return true;
            }
        }
        if (i == 1){
            if (player.GetComponent<PlayerInventory>().trash >= 4){
                numCompletedQuests++;
                UpdateScoreText();
                NextQuest();
                return true;
            }
        }
        return false;

    }





    


}