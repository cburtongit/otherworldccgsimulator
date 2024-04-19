public class MonsterCard : Card
{

    public int sP, originalSP;
    public bool isTethered, canAttack, isAttackable, isSacrificeable;

    void Attack(MonsterCard target) {}
    void Summon() {}
    void ModifySP(int change) {sP += change;}
}