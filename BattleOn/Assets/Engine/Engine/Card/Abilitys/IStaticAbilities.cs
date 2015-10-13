namespace BattleOn.Engine
{
    public interface IStaticAbilities
    {
        bool Null{ get; }
        bool Heal{ get; }
        bool Shield{ get; }
        bool LifeSteal{ get; }
        bool Stacks{ get; }
        bool Thorns{ get; }
        bool Immunity{ get; }
        bool Stealth{ get; }
        bool SpellShield{ get; }
        bool Nuke{ get; }
        bool GrievousWounds{ get; }
        bool Stun{ get; }
        bool Silence{ get; }
        bool Bleed{ get; }
        bool Empower{ get; }
        bool ArmorPenetration{ get; }
        bool ArmorShread{ get; }
        bool Amplify{ get; }
        bool Mobility{ get; }
        bool DoubleStrike{ get; }
        bool KnockBack{ get; }
        bool Swap{ get; }
        bool Cleave{ get; }
        bool Exhaust{ get; }
        bool Repair { get; }
        bool Charge { get; }
        bool Has(Ability ability);
    }
}
