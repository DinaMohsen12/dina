using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManger : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI currentscoreText,Bestscore;
   public int currentscore;
    public static ScoreManger  instance = null; 
    void Start()
    {
        if (instance == null)
            instance = this;
        currentscore = 0;
        Bestscore.text = PlayerPrefs.GetInt("Best").ToString();

    }
    public void addscore() {
        currentscore += 1;
        currentscoreText.text = currentscore.ToString();
        if (currentscore > PlayerPrefs.GetInt("Best", 0)) {
            Bestscore.text = currentscore.ToString();
            PlayerPrefs.SetInt("Best",currentscore);
        }
    
    } 

}
