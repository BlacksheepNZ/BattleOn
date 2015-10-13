namespace BattleOn.Engine
{
    public interface IZone
    {
        Zone Name { get; }

        void Remove(Card card);
        void AfterRemove(Card card);
        void AfterAdd(Card card);
    }

    public static class Zones { }

    public enum Zone
    {
        None = 0,
        Library = 1,
        Hand = 2,
        Battlefield = 3,
        Graveyard = 4,
        Stack = 5,
        Exile = 6,
    }

    public static class ZoneHelpers
    {
        public static bool IsHiddenZone(this Zone zone)
        {
            return zone == Zone.Library || zone == Zone.Hand;
        }
    }
}
