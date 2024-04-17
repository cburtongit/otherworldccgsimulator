public class MonsterCard : Card
{

    public int sp, originalSp;
    public bool isTethered, canAttack, isAttackable;

    void Attack(MonsterCard target) {}
    void Summon() {}
    void ModifySP(int change) { sp += change; }
}