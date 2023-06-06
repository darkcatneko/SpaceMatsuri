using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : StateBase
{
    StageData data_;
    public GameOverState(StageManager m,StageData data) : base(m)
    {
        data_ = data;
    }

    public override  void OnEnter()
    {
        GameManager.Instance.PlayerGameOver(data_.GameResult);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
