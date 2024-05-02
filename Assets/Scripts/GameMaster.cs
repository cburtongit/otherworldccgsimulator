using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameMaster : MonoBehaviour
{

    public GameObject p1, p2;
    public int turnPlayer, turnStage;

    void Start()
    {
        p1.GetComponent<Player>().hp = p2.GetComponent<Player>().hp = 1000;
        GenPlayerDecks_debug(p1);
        GenPlayerDecks_debug(p2);
        
    }

    void Update()
    {
        
    }

    public void GenPlayerDecks_debug(GameObject player)
    {
        Sprite testPic = Resources.Load<Sprite>("Images/artwork/DarkProwler");
        
        for (int i = 0; i < 45; i++) {
            // create new object, add components
            GameObject card = new GameObject();
            card.name = "Dark Prowler-" + i + " (P " + player.GetComponent<Player>().playerId + ")";
            card.AddComponent<RectTransform>();
            card.AddComponent<MonsterCard>();
            card.AddComponent<SpriteRenderer>();
            card.AddComponent<UnityEngine.UI.Image>();
            
            /* ASSIGN STATS */
            card.GetComponent<Card>().controller = card.GetComponent<Card>().owner = player.GetComponent<Player>();
            card.GetComponent<Card>().cardName = card.GetComponent<MonsterCard>().originalName = "Dark Prowler " + i + " (playerID: " + player.GetComponent<Player>().playerId + ")";
            card.GetComponent<Card>().rPCost = card.GetComponent<MonsterCard>().originalRPCost = 2;
            card.GetComponent<Card>().alignments.Add("Dark");
            card.GetComponent<Card>().alignments.Add("Beast");
            card.GetComponent<Card>().originalAlignments = card.GetComponent<MonsterCard>().alignments;
            card.GetComponent<Card>().serial = "00000" + i;
            card.GetComponent<MonsterCard>().sP = card.GetComponent<MonsterCard>().originalSP = 125;
            card.GetComponent<MonsterCard>().isDestroyBattleImmune = card.GetComponent<MonsterCard>().isDestroyEffectImmune = card.GetComponent<MonsterCard>().isCountered = card.GetComponent<MonsterCard>().isTethered = false;
            
            card.GetComponent<SpriteRenderer>().sprite = testPic; // assignArtwork
            card.GetComponent<UnityEngine.UI.Image>().sprite = testPic; // ui image
            card.SetActive(false);
            player.GetComponent<Player>().deck.Add(card);
            card.transform.SetParent(player.transform);
        }
    }
}
