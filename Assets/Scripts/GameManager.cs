using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, Subject
{
    // 1. Singleton Pattern: Instance() method
    public static GameManager _instance;

    private Character[] characters;

    // 초기화 설정 바꾸지 말 것
    private int _gameRound = 0;
    private string _whoseTurn = "Enemy";
    private bool _isEnd = false;

    // delegate: TurnHandler, FinishHandler 선언
    delegate void TurnHandler();
    delegate void FinishHandler();

    private Enemy _enemy;
    private Player _player;

    void Start()
    {
        _instance = this;
        _enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    /// <summary>
    /// 2. RoundNotify:
    /// 1) 현재 턴이 Enemy이면 다음 gameRound로
    ///  + Debug.Log($"GameManager: Round {gameRound}.");
    /// 2) TurnNotify() 호출
    /// </summary>
    public void RoundNotify()
    {
        _gameRound++;
        Debug.Log($"GameManager: Round {_gameRound}.");
        TurnNotify();
    }

    /// <summary>
    /// 3. TurnNotify:
    /// 1) whoseTurn update
    ///  + Debug.Log($"GameManager: {_whoseTurn} turn.");
    /// 2) _turnHandler 호출
    /// </summary>
    public void TurnNotify()
    {
        if (_whoseTurn != "Player")
            _whoseTurn = "Player";
        else
            _whoseTurn = "Enemy";
        
        _enemy.TurnUpdate(_gameRound, _whoseTurn);
        _player.TurnUpdate(_gameRound, _whoseTurn);
        Debug.Log($"GameManager: {_whoseTurn} turn.");
        
    }

    /// <summary>
    /// 4. EndNotify: 
    /// 1) isEnd update
    ///  + Debug.Log("GameManager: The End");
    ///  + Debug.Log($"GameManager: {_whoseTurn} is Win!");
    /// 2) _finishHandler 호출
    /// </summary>
    public void EndNotify()
    {
        _isEnd = true;
        _enemy.FinishUpdate(_isEnd);
        _player.FinishUpdate(_isEnd);
        Debug.Log("GameManager: The End");
        Debug.Log($"GameManager: {_whoseTurn} is Win!");
    }

    // 5. AddCharacter: _turnHandler, _finishHandler 각각에 메소드 추가
    public void AddCharacter(Character character)
    {

    }
}
