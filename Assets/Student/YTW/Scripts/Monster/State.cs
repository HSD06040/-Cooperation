using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Monster _monster;
    protected StateMachine _stateMachine;

    public State(Monster monster, StateMachine stateMachine)
    {
        _monster = monster;
        _stateMachine = stateMachine;
    }

    // ���¿� ���� �� �ѹ� ȣ��
    public virtual void Enter() { }

    // ���°� Ȱ��ȭ�� ���� �� ������ ȣ��
    public virtual void Execute() { }

    // ���¿��� �������� �� �ѹ� ȣ��
    public virtual void Exit() { }
}
