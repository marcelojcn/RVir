using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text _word;
    private Text _text;

    private string[] _words = { "OLÁ", "ABC", "VERDE", "AZUL", "DESERTO" };

    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.Find($"Text").gameObject.GetComponent<Text>();
        _word = GameObject.Find($"Word").gameObject.GetComponent<Text>();
        SelectWord();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLetter(string value)
    {
        if (!(_word.text).StartsWith(_text.text + value))
        {
            FindObjectOfType<AudioManager>().Play("Error");
            return;
        }

        _text.text = _text.text + value;

        if (_text.text.Equals(_word.text))
        {
            FindObjectOfType<AudioManager>().Play("Success");
            _text.text = string.Empty;

            SelectWord();
        }
    }

    private void SelectWord() 
    {
        _word.text = _words[Random.Range(0, _words.Length - 1)];
    }
}
