using System;
using System.Collections.Generic;
using UnityEngine;

enum BallType
{
    AllBalls = 1,
    Red = 2,
    Green = 3,
    White = 4
}

public class Quiz : MonoBehaviour
{
    [SerializeField] private List<Ball> _ballsOnScene;

    private Dictionary<BallType, List<Ball>> _ballLists = new Dictionary<BallType, List<Ball>>();
    private BallType _winCondition;

    private bool isConditionSelected = false;
    private bool _isWon = false;

    private void Start()
    {
        ShotWinCondition();
    }

    private void Update()
    {
        if(isConditionSelected)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _winCondition = BallType.AllBalls;
            _ballLists[BallType.AllBalls] = _ballsOnScene.FindAll(ball => ball is Ball);
            StartQuiz(_winCondition);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _winCondition = BallType.Red;
            _ballLists[BallType.Red] = _ballsOnScene.FindAll(ball => ball is RedBall);
            StartQuiz(BallType.Red);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _winCondition = BallType.Green;
            _ballLists[BallType.Green] = _ballsOnScene.FindAll(ball => ball is GreenBall);
            StartQuiz(BallType.Green);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _winCondition = BallType.White;
            _ballLists[BallType.White] = _ballsOnScene.FindAll(ball => ball is WhiteBall);
            StartQuiz(_winCondition);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ResetQuiez();
        }

        isConditionSelected = false;
    }

    private void StartQuiz(BallType winCondition)
    {
        if (_ballLists.ContainsKey(winCondition) == false)
        {
            Debug.LogError("Неправильное условие победы");
            return;
        }

        List<Ball> selectedBalls = _ballLists[winCondition];
        foreach (Ball ball in selectedBalls)
        {
            ball.Bursted += OnBursted;
        }
    }

    private void OnBursted(Ball burstedBall)
    {
        if(_isWon)
        {
            return;
        }

        burstedBall.Bursted -= OnBursted;
        _ballLists[_winCondition].Remove(burstedBall);

        if (_ballLists[_winCondition].Count == 0)
        {
            _isWon = true;
            Debug.Log("Победа!");
        }
        else
        {
            Debug.Log($"Осталось лопнуть {_ballsOnScene.Count} шаров");
        }
    }

    private void ShotWinCondition()
    {
        Debug.Log("Выберите условие победы:" +
    "1 - лопунуть все шарики" +
    "2 - лопнуть шарики красного цвета" +
    "3 - лопнуть шарики зеленого цвета" +
    "4 - лопнуть шарики белого цвета" +
    "5 - перезапустить викторину");
    }

    public void ResetQuiez()
    {
        ShotWinCondition();

        foreach (var item in _ballsOnScene)
        {
            item.gameObject.SetActive(true);
        }

        isConditionSelected = false;
        _isWon = false;
    }
}