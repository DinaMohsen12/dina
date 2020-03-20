using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField]
 GameObject GameOverpanel;
    [SerializeField]
    TextMeshProUGUI scoretext,Bestsoretext;
    public static GameManger instance=null;
    private void Awake()
    {
      Time.timeScale =1.5f;
    }
    private void Start()
    {
        if (instance == null)
            instance = this;
    }
    public void Gameover()
    {
        StartCoroutine(gameoverCoroutine());
    }
    IEnumerator gameoverCoroutine() {
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(0.5f);
        GameOverpanel.SetActive(true);
        scoretext.text = ScoreManger.instance.currentscore.ToString();
        Bestsoretext.text = PlayerPrefs.GetInt("Best", 0).ToString();
        yield break;
    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
