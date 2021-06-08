using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    //public Sprite[] letters = new Sprite[26];
    public Image _SpriteLetter;
    private string _letter;
    public Animation _Letter_fade_in, _ease_in_bounce;

    public Letters (string letter)
    {
        this._letter = letter;
    }

    public string getLetter() { return _letter; }
    public void setLetter(string let) { _letter = let; }

    void OnMouseDown()
    {
        transform.localScale = new Vector3(0.950f, 0.950f, 0.950f);
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        clickOnLetter();

    }

    public static void NextLevel() // функция повышения уровня
    {
        if (Game._level < 3)
        {
            Game.lvlWin = true;
            Game._level += 1;
            
        }
    }

    public void clickOnLetter()
    {
        if (gameObject.tag != Game._arr)
        {
            //Game._arr = ".;fffffff";
            _ease_in_bounce.Play("ease_In_Bounce");
        }
        else
        {
            Game._arr = "You win! Next lvl...";
            Game._level += 1;
            Thread.Sleep(200);
            NextLevel();
        }
    }



}