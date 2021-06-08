using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Sprite[] _letters = new Sprite[26]; // массив спрайтов с буквами
    public string[] _ArrLetter = {"A", "B", "C", "D", "F", "G", "J", "I", "E", "H", "K", "L", "M", "R",
                                    "S", "U", "V", "O", "Q", "W", "T", "N", "P", "X", "Y", "Z"}; // массив всех возможных букв
    public Image _SpriteLetter; // Image с определённой буквой
    public static int _level = 1; // номер уровня
    public static string _arr = ""; 
    public Text _TaskText;
    public GameObject _Grid; // сетка, где отображаются и сортируются буквы
    public GameObject _UI_Window_pref; // префаб окна с буквой
    public List<string> _PullLetters; // лист всех попавшихся букв в уровне

    public static bool lvlWin = false; // булевое значение показывает, выигран ли уровень


    public 
    void Start()
    {
        NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        _TaskText.text = "Find: " + _arr;
        if (lvlWin == true)
        {
            lvlWin = false;
            NextLevel();
        }
    }

    public void NextLevel()
    {
        for (int i = 0; i < (_level * 3); i++)
        {
            GameObject pref = Instantiate(_UI_Window_pref, _UI_Window_pref.transform.position, Quaternion.identity) as GameObject;
            int num_sprite = Random.Range(0, 25);
            //SpriteLetter.sprite = letters[num_sprite];
            //SpriteLetter.sprite = letters[num_sprite];
            pref.GetComponent<Letters>()._SpriteLetter.sprite = _letters[num_sprite];
            _PullLetters.Add(_ArrLetter[num_sprite]); // добавляется буква в List
            pref.GetComponent<Letters>().setLetter(_ArrLetter[num_sprite]);
            pref.transform.SetParent(_Grid.transform);
            pref.tag = _ArrLetter[num_sprite].ToString();
            pref.GetComponent<Image>().color = new Color(Random.Range(50, 255) / 255.0f, Random.Range(50, 255) / 255.0f, Random.Range(50, 255) / 255.0f);
            pref.transform.localScale = new Vector3(1f, 1f, 1f);


        }
        _arr = _PullLetters[Random.Range(0, 3)];
        _TaskText.text = "Find: " + _arr;
    }
    

}
