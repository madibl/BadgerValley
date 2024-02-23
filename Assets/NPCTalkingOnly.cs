using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NPCTalkingOnly : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
  void Update()
{
    if (playerIsClose && Input.GetKeyDown(KeyCode.E))
    {     

        if (dialoguePanel.activeInHierarchy) 
        {
            zeroText();
        }
        else 
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }
    if (dialogueText.text == dialogue[index])
    {
        contButton.SetActive(true);
    }  
}

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);

    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {


        // if quest is not complete, and the quest has not started (not on index 1)
        if (index < dialogue.Length - 1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Player")){
            playerIsClose = true;
            zeroText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            playerIsClose = false;
            zeroText();
        }
    }
}
