using System.Collections.Generic;

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public Dictionary<ZombieEnum, EnemyState> stateDictionary = new Dictionary<ZombieEnum, EnemyState>();

    public Enemy _enemy;
    public void Initalize(ZombieEnum startState, Enemy enemy)
    {
        _enemy = enemy;
        CurrentState = stateDictionary[startState];
        CurrentState.Enter();
    }

    public void ChangeState(ZombieEnum newState, bool forceMode = false)
    {
        if (!_enemy.CanStateChangeable && !forceMode) return;
        if (_enemy.IsDead) return;

        CurrentState.Exit();
        CurrentState = stateDictionary[newState];
        CurrentState.Enter();
    }

    public void AddState(ZombieEnum stateEnum, EnemyState enemyState)
    {
        stateDictionary.Add(stateEnum, enemyState);
    }
}
