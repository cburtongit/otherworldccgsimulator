using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public Player p1, p2;
    public GameObject p1HealthManaText;
    public int turnPlayer, turnStage;

    void Start()
    {
        p1.hp = p2.hp = 1000;
        GenPlayerDecks_debug(p1);
        GenPlayerDecks_debug(p2);
        
    }

    void Update()
    {
        p1HealthManaText.GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + p1.hp + " | RP: " + p1.rp;
    }

    public void GenPlayerDecks_debug(Player player)
    {
        Sprite testPic = Resources.Load<Sprite>("Images/artwork/DarkProwler");
        
        for (int i = 0; i < 45; i++) {
            // create new object, add components
            GameObject card = new GameObject();
            card.name = "Dark Prowler-" + i + " (playerID: " + player.playerId + ")";
            card.AddComponent<RectTransform>();
            card.AddComponent<MonsterCard>();
            card.AddComponent<SpriteRenderer>();
            
            /* ASSIGN STATS */
            card.GetComponent<Card>().controller = card.GetComponent<Card>().owner = player;
            card.GetComponent<Card>().cardName = card.GetComponent<MonsterCard>().originalName = "Dark Prowler " + i + " (playerID: " + player.playerId + ")";
            card.GetComponent<Card>().rPCost = card.GetComponent<MonsterCard>().originalRPCost = 2;
            card.GetComponent<Card>().alignments.Add("Dark");
            card.GetComponent<Card>().alignments.Add("Beast");
            card.GetComponent<Card>().originalAlignments = card.GetComponent<MonsterCard>().alignments;
            card.GetComponent<Card>().serial = "00000" + i;
            card.GetComponent<MonsterCard>().sP = card.GetComponent<MonsterCard>().originalSP = 125;
            card.GetComponent<MonsterCard>().isDestroyBattleImmune = card.GetComponent<MonsterCard>().isDestroyEffectImmune = card.GetComponent<MonsterCard>().isCountered = card.GetComponent<MonsterCard>().isTethered = false;
            
            card.GetComponent<SpriteRenderer>().sprite = testPic; // assignArtwork
            card.SetActive(false);
            player.deck.Add(card);
        }
    }
}
