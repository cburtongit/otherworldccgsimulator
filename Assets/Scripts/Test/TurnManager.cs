using System.Collections;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Player Player1;
    public Player Player2;
    public int turnCount = 1;

    private void Start()
    {
        StartCoroutine(TurnSequence());
    }

    private IEnumerator TurnSequence()
    {
        while (true) // Infinite loop to keep the game running until it ends
        {
            yield return StartCoroutine(DrawStage());
            //yield return StartCoroutine(SetupStage());
            //yield return StartCoroutine(CombatStage());

            // End of turn cleanup or checks here
            SwapPlayers();
            turnCount++;
        }
    }

    private IEnumerator DrawStage()
    {
        // Set RP to turn count * 2
        Player1.rp = turnCount * 2;

        // Draw a card
        Player1.DrawCard(1);

        yield return null; // Wait for the draw animation or logic to complete if needed
    }

    /* private IEnumerator SetupStage()
    {
        bool playersCanAct = true;
        while (playersCanAct)
        {
            // Assuming ActivateCard is a method that tries to activate a card and returns true if successful
            bool currentPlayerActed = Player1.ActivateCard(); // Let the current player act
            yield return new WaitUntil(() => Player1.hasResponded); // Assuming a flag that is set when the player finishes responding

            if (currentPlayerActed)
            {
                bool opponentActed = Player2.ActivateCard(); // Ask for opponent's response
                yield return new WaitUntil(() => Player2.hasResponded);

                if (!opponentActed)
                {
                    // If opponent didn't act, check if the current player wants to continue acting
                    currentPlayerActed = Player1.ActivateCard();
                    yield return new WaitUntil(() => Player1.hasResponded);
                    if (!currentPlayerActed)
                    {
                        playersCanAct = false;
                    }
                }
            }
            else
            {
                playersCanAct = false;
            }
        }
        yield return null;
    } */

    /* private IEnumerator CombatStage()
    {
        // Placeholder for combat logic. This will likely involve iterating over monsters that can attack and handling responses
        // Combat logic highly depends on your game's specific rules and mechanics

        // Example of attacking with one monster
        Player1.DeclareAttack();
        yield return new WaitUntil(() => Player2.hasResponded); // Wait for opponent to respond

        // Handle the result of the attack, possibly asking for more responses based on game mechanics

        yield return null;
    } */

    private void SwapPlayers()
    {
        // Swap the current player and opponent
        Player temp = Player1;
        Player1 = Player2;
        Player2 = temp;
    }
}
