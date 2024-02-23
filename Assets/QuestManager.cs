using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public delegate void QuestChangeHandler(int amount);
    public event QuestChangeHandler OnQuestChange;
    private void Awake()
    {
        // Singleton Check
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }
}
