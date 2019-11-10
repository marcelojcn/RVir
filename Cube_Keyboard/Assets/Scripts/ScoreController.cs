using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text _word;
    private Text _text;

    private string[] _words = {};
    private string[] _wordsEasy = { "OLÁ", "ABC", "VERDE", "AZUL", "DESERTO" };
    private string[] _wordsMedium = { "SUPER", "ADORÁVEL", "ESPAÇO", "MOCHILA", "TARTARUGA" };
    private string[] _wordsHard = { "HIPÓPOTAMO", "AÁÉÇ", "RESTAURAÇÃO", "ESTÁS", "COMPUTADOR" };

    private int _wordsWritten = 0;
    private int _lettersMistaken = 0;
    private int _backtrackingCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Manager = GameObject.Find("Manager");
        switch (Manager.GetComponent<GameManager>().difficulty)
        {
            case "medium":
                _words = _wordsMedium;
                break;
            case "hard":
                _words = _wordsHard;
                break;
            default:
                _words = _wordsEasy;
                break;
        }

        _text = GameObject.Find($"Text").gameObject.GetComponent<Text>();
        _word = GameObject.Find($"Word").gameObject.GetComponent<Text>();
        SelectWord();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && (_text.text.Length > 0))
        {
            _text.text = _text.text.Remove(_text.text.Length - 1);
            _backtrackingCount++;
        }
    }

    public void AddLetter(string value)
    {
        if (!_word.text.StartsWith(_text.text + value))
        {
            FindObjectOfType<AudioManager>().Play("Error");
            _lettersMistaken++;
            return;
        }

        _text.text = _text.text + value;

        if (_text.text.Equals(_word.text))
        {
            FindObjectOfType<AudioManager>().Play("Success");
            _text.text = string.Empty;
            _wordsWritten++;
            SelectWord();
        }
    }

    private void SelectWord()
    {
        _word.text = _words[Random.Range(0, _words.Length)];
    }
}
