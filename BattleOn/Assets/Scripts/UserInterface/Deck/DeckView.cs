using System;
using System.Collections.Generic;
using System.Linq;
using BattleOn;
using BattleOn.Engine;
using Deck = BattleOn.Engine.Deck;

namespace BattleOnGame
{
    public class DeckView : GameScreen
    {
        private const string NewDeckName = "new deck";
        public Func<CardInfo, bool> OnAdd = delegate { return true; };
        public Func<CardInfo, bool> OnRemove = delegate { return true; };
        private Deck _deck;

        public DeckView() { }

        public DeckView(Deck deck)
        {
            _deck = deck;
        }

        [Updates("Name")]
        public virtual bool IsSaved { get; protected set; }

        public virtual bool IsNew { get; protected set; }

        public virtual int Rating
        {
            get { return _deck.Rating ?? 3; }
            set
            {
                _deck.Rating = value;
                IsSaved = false;
            }
        }

        public virtual string Description
        {
            get { return _deck.Description; }
            set
            {
                _deck.Description = value;
                IsSaved = false;
            }
        }

        public IEnumerable<DeckRow> Creatures { get { return FilterRows(_deck, c => c.Is().Creature).ToList(); } }
        public IEnumerable<DeckRow> Spells { get { return FilterRows(_deck, c => !c.Is().Creature && !c.Is().Land).ToList(); } }
        public IEnumerable<DeckRow> Lands { get { return FilterRows(_deck, c => c.Is().Land).ToList(); } }

        public int CreatureCount { get { return FilterCards(_deck, c => c.Is().Creature).Count(); } }
        public int LandCount { get { return FilterCards(_deck, c => c.Is().Land).Count(); } }
        public int SpellCount { get { return FilterCards(_deck, c => !c.Is().Creature && !c.Is().Land).Count(); } }
        public int CardCount { get { return _deck.CardCount; } }
        public CardInfo SelectedCard { get; private set; }

        public string Name
        {
            get
            {
                var name = _deck.Name;

                if (!IsSaved)
                {
                    name = name + "*";
                }
                return name;
            }
        }

        public Deck Deck { get { return _deck; } }

        public override void Initialize()
        {
            IsSaved = true;

            if (_deck == null)
            {
                _deck = new Deck { Name = NewDeckName };
                SelectedCard = null;
                IsNew = true;
                return;
            }

            SelectedCard = _deck[RandomEx.Next(_deck.CardCount)];
        }

        public void ChangeSelectedCard(CardInfo cardInfo)
        {
            SelectedCard = cardInfo;
            SelectedCardChanged(this, EventArgs.Empty);
        }

        [Updates("Creatures", "Spells", "Lands", "CreatureCount", "LandCount", "SpellCount", "CardCount")]
        public virtual void AddCard(CardInfo cardInfo)
        {
            if (!OnAdd(cardInfo))
                return;

            _deck.AddCard(cardInfo);
            IsSaved = false;
        }

        [Updates("Creatures", "Spells", "Lands", "CreatureCount", "LandCount", "SpellCount", "CardCount")]
        public virtual bool RemoveCard(CardInfo cardInfo)
        {
            if (!OnRemove(cardInfo))
                return false;

            _deck.RemoveCard(cardInfo);
            IsSaved = false;
            return true;
        }

        public virtual void Save()
        {
            DeckLibrary.Write(_deck);
            IsSaved = true;
        }

        public virtual void SaveAs(string name)
        {
            _deck.Name = name;
            DeckLibrary.Write(_deck);

            IsSaved = true;
            IsNew = false;
        }

        public event EventHandler SelectedCardChanged = delegate { };

        private IEnumerable<DeckRow> FilterRows(IEnumerable<CardInfo> cards, Func<Card, bool> predicate)
        {
            return DeckRow.Group(FilterCards(cards, predicate)).OrderBy(x => x.Card.Name);
        }

        private IEnumerable<CardInfo> FilterCards(IEnumerable<CardInfo> cards, Func<Card, bool> predicate)
        {
            return cards.Where(x => predicate(Cards.All[x.Name]));
        }

        public interface IFactory
        {
            DeckView Create(Deck deck);
            DeckView Create();
        }
    }
}