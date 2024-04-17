public class SupportCard : Card
{
    public bool staysOnField; // 0 = no, 1 = yes
    public int fastRp, originalFastRp;

    void modifyFastRp(int change)
    {
        fastRp += change;
    }
    // called when a card is activated
    // void activate() {}
    // void effect() {}
}