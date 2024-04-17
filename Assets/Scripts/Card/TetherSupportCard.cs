public class TetherSupportCard : SupportCard
{

    public MonsterCard target; // the monster card that this card is tethered to
    
    void Start() {
        staysOnField = true;
    }
}