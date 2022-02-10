using UnityEngine;

public sealed class WaitUntilCharacterAttack : CustomYieldInstruction
{
    private readonly CharacterComponent character;
        
    private bool isKeepWaiting = true;
        
    public WaitUntilCharacterAttack(global::CharacterComponent character)
    {
        this.character = character;
        this.character.AttackComponent.OnAttackFinished += this.OnAttackFinished;
    }

    private void OnAttackFinished()
    {
        this.character.AttackComponent.OnAttackFinished -= OnAttackFinished;
        isKeepWaiting = false;
    }

    public override bool keepWaiting
    {
        get { return isKeepWaiting; }
    }
}