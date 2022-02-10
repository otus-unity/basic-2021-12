using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    CharacterComponent character;

    void Start()
    {
        character = GetComponentInParent<CharacterComponent>();
    }

    void ShootEnd()
    {
        character.SetState(CharacterComponent.State.Idle);
        character.AttackFinished();
    }

    void AttackEnd()
    {
        character.SetState(CharacterComponent.State.RunningFromEnemy);
    }
}
