using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Board Board = null;

    private bool _isWinning = false;

    private void Awake()
    {
        Picker.ElementPicked += Picker_ElementPicked;
    }

    private void Start()
    {
        ScoreManager.ResetScore();
    }

    private void OnDestroy()
    {
        Picker.ElementPicked -= Picker_ElementPicked;
    }

    private void Picker_ElementPicked(ElementDef elementDef)
    {
        if (_isWinning)
            return;

        Board.Fill(elementDef);
        ScoreManager.AddPoints(1);

        if (Board.IsFilled)
        {
            _isWinning = true;

            StartCoroutine(Win());
        }
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);

        ScoreManager.SetHighScore(isLowerBetter: true);

        yield return StartCoroutine(MainMenu.GoToScene("Win"));
    }
}
