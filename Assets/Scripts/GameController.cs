using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CharacterComponent[] playerCharacters;
    [SerializeField] private CharacterComponent[] enemyCharacters;

    private Coroutine gameLoop;

    private void Start()
    {
        gameLoop = StartCoroutine(GameLoop());
    }
    
    private IEnumerator GameLoop()
    {
        Coroutine turn = StartCoroutine(Turn(playerCharacters, enemyCharacters));

        yield return new WaitUntil(() =>
        playerCharacters.FirstOrDefault(c => !c.HealthComponent.IsDead) == null ||
        enemyCharacters.FirstOrDefault(c => !c.HealthComponent.IsDead) == null);

        StopCoroutine(turn);
        GameOver();
    }

    private CharacterComponent GetTarget(CharacterComponent[] characterComponents)
    {
        return characterComponents.FirstOrDefault(c => !c.HealthComponent.IsDead);
    }

    private void GameOver()
    {
        bool isPlayerCharacherAlive = false;
        bool isEnemyCharacherAlive = false;

        bool isVictory;

        for (int i = 0; i < playerCharacters.Length; i++)
        {
            if (!playerCharacters[i].HealthComponent.IsDead)
            {
                isPlayerCharacherAlive = true;
            }
        }

        for (int i = 0; i < enemyCharacters.Length; i++)
        {
            if (!enemyCharacters[i].HealthComponent.IsDead)
            {
                isEnemyCharacherAlive = true;
            }
        }

        isVictory = isPlayerCharacherAlive && !isEnemyCharacherAlive;

        Debug.Log(isVictory ? "Victory" : "Defeat");
    }

    private IEnumerator Turn(CharacterComponent[] playerCharacters, CharacterComponent[] enemyCharacters)
    {
        int turnCounter = 0;
        while (true)
        {
            for (int i = 0; i < playerCharacters.Length; i++)
            {
                if(playerCharacters[i].HealthComponent.IsDead)
                {
                    Debug.Log("Character: " + playerCharacters[i].name + " is dead");
                    continue;
                }
                
                playerCharacters[i].SetTarget(GetTarget(enemyCharacters).HealthComponent);
                
                //TODO: hotfix
                yield return null; // ugly fix need to investigate
                playerCharacters[i].StartTurn();
               
                
                
                
                yield return new WaitUntilCharacterAttack(playerCharacters[i]);
                
                
                
                
                Debug.Log("Character: " + playerCharacters[i].name + " finished turn");
            }

            yield return new WaitForSeconds(.5f);

            for (int i = 0; i < enemyCharacters.Length; i++)
            {
                if (enemyCharacters[i].HealthComponent.IsDead)
                {
                    Debug.Log("Enemy character: " + enemyCharacters[i].name + " is dead");
                    continue;
                }
               
                enemyCharacters[i].SetTarget(GetTarget(playerCharacters).HealthComponent);
                enemyCharacters[i].StartTurn();
                
                yield return new WaitUntilCharacterAttack(enemyCharacters[i]);
                Debug.Log("Enemy character: " + enemyCharacters[i].name + " finished turn");
            }

            yield return new WaitForSeconds(.5f);

            turnCounter++;
            Debug.Log("Turn #" + turnCounter + " has been ended");
        }
    }
}
