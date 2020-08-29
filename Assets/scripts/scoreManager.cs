using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class scoreManager : MonoBehaviour
{

    public TextMeshProUGUI t_count;
    public TextMeshProUGUI t_score;
    public TextMeshProUGUI t_special;
    public TextMeshProUGUI t_explain;
    TextMeshProUGUI t_totalScore;

    private GameObject scoreScreen;
    struct frame
    {
        public TextMeshProUGUI t_throw1, t_throw2, t_total;
        public int throw1, throw2, total;
    }

    frame[] gameScore = new frame[10];

    public int turn = 0;
    int currentFrame = 0;
    int score;
    bool strike = false;
    bool spare = false;
    int lastCount = 0;

    private void Start()
    {
        scoreScreen = GameObject.Find("scoreScreen");
        //GameObject row1 = scoreScreen.transform.Find("mainContainer")
        frame f; 
        for(int i = 0; i < 10; i++)
        {
            f = new frame();
            Debug.Log(scoreScreen.transform.Find("mainContainer/pointsContainer/row1/frame1").name);
            f.t_throw1 = scoreScreen.transform.Find("mainContainer/pointsContainer/row1/frame" + (i + 1) + "/Image/firstThrow/firstThrowText").GetComponent<TextMeshProUGUI>();
            f.t_throw2 = scoreScreen.transform.Find("mainContainer/pointsContainer/row1/frame" + (i + 1) +"/Image/secondThrow/secondThrowText").GetComponent<TextMeshProUGUI>();
            f.t_total = scoreScreen.transform.Find("mainContainer/pointsContainer/row1/frame" + (i + 1) + "/total/totalText").GetComponent<TextMeshProUGUI>();
            f.throw1 = 0; f.throw2 = 0; f.total = 0;
            gameScore[i] = f;
        }
        t_totalScore = scoreScreen.transform.Find("mainContainer/pointsContainer/row1/total/totalText").GetComponent<TextMeshProUGUI>();
    }

    public void updateText()
    {
        for (int i = 0; i < 10; i++)
        {
            if (gameScore[i].throw2 > 0 && gameScore[i].throw2 + gameScore[i].throw1 == 10)
            {
                gameScore[i].t_throw2.SetText("/");
            }
            else
            {
                gameScore[i].t_throw2.SetText(gameScore[i].throw2.ToString());
            }

            gameScore[i].t_total.SetText(gameScore[i].total.ToString());

            if (gameScore[i].throw1 < 10) gameScore[i].t_throw1.SetText(gameScore[i].throw1.ToString());
            else
            {
                gameScore[i].t_throw1.SetText("");
                gameScore[i].t_throw2.SetText("X");
                gameScore[i].t_total.SetText(gameScore[i].total.ToString());
            }
        }
        t_totalScore.SetText(score.ToString());
    }

    public void resetScore()
    {
        for(int i = 0; i < 10; i++)
        {
            gameScore[i].throw1 = 0;
            gameScore[i].throw2 = 0;
            gameScore[i].total = 0;
        }
        score = 0;
        lastCount = 0;
        strike = false;
        spare = false;
        turn = 0;
        currentFrame = 0;
        updateText();
    }

    public void addToScore(int count)
    {
        //turn++;
        //if (turn % 2 != 0 && count == 10)
        //{
        //    gameScore[currentFrame].throw1 = count;
        //    gameScore[currentFrame].total += count;
        //    turn = 0;
        //    currentFrame++;
        //}
        //else
        //{
        //    if (turn % 2 != 0)
        //    {
        //        gameScore[currentFrame].throw1 = count;
        //        gameScore[currentFrame].total += count;
        //    }
        //    else
        //    {
        //        gameScore[currentFrame].throw2 = count;
        //        gameScore[currentFrame].total += count;
        //    }
        //    if (turn % 2 == 0)
        //    {
        //        currentFrame++;
        //    }
        //}

        //updateText();
        Debug.Log("---------");
        Debug.Log(turn);
        Debug.Log(currentFrame);
        if (currentFrame > 9) resetScore();
        //Debug.Log(lastCount);
        //Debug.Log(strike);
        score += count;
        if(turn == 0)
        {
            gameScore[currentFrame].throw1 = count;
        }
        else
        {
            gameScore[currentFrame].throw2 = count;
        }
        gameScore[currentFrame].total += count;

        if (strike)
        {
            if (turn == 1 || count + lastCount == 10 || count == 10)
            {
                Debug.Log("current frame points are: " + (count + lastCount) + "; Adding 10 to that for strike in last frame.");
                t_explain.SetText("За текущий фрейм вы выбили " + (count + lastCount) + "кегель. + 10 к этому за страйк в предыдущем фрейме.");
                score += lastCount + count + 10;
                gameScore[currentFrame - 1].total += lastCount + count + 10;
            }
        }

        if (spare)
        {
            score += 10;
            gameScore[currentFrame - 1].total += 10 + count;
            Debug.Log("Giving 10 extra points for spare in last frame.");
            t_explain.SetText("+10 очков за Spare в предыдущем фрейме.");
        }

        if (turn > 0 && count + lastCount == 10)
        {
            Debug.Log("Spare!");
            t_special.SetText("Spare!");
            t_special.color = new Color(1, 1, 1);
            t_special.DOColor(new Color(1, 1, 1, 0), 5f);

            spare = true;
        }
        else
        {
            spare = false;
        }

        if (count == 10 && turn == 0)
        {
            Debug.Log("Strike!");
            t_special.SetText("Strike!");
            currentFrame++;
            t_special.color = new Color(1, 1, 1);
            t_special.DOColor(new Color(1, 1, 1, 0), 5f);
            strike = true;
        }
        else
            if (turn == 1) strike = false;

        t_count.SetText((count + lastCount).ToString() + " Кегель");
        t_score.SetText((score).ToString() + " Очков");

        if (turn == 0)
            lastCount = count;
        else lastCount = 0;
        //if(strike) lastCount = 0;
        if (turn == 1) currentFrame++;
        turn++;
        updateText();
        //Debug.Log(score);
    }
}
