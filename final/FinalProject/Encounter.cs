public class Encounter
{
    private Party _party;
    private List<Enemy> _enemies;
    
    public Encounter(Party party, List<Enemy> enemies)
    {
        _party = party;
        _enemies = enemies;
    }

    public void Start()
    {
        Console.WriteLine("The battle begins!");
        while (_party.Members.Any(m => m.HitPoints > 0) && _enemies.Any(e => e.HitPoints > 0))
        {
            foreach (var member in _party.Members.Where(m => m.HitPoints > 0))
            {
                if (_enemies.Count == 0) break;
                Enemy target = _enemies.First();
                member.Attack(target);
                if (target.HitPoints <= 0)
                {
                    _enemies.Remove(target);
                }
            }

            foreach (var enemy in _enemies.Where(e => e.HitPoints > 0))
            {
                if (_party.Members.Count == 0) break;
                PlayerCharacter target = _party.Members.First();
                enemy.Attack(target);
                if (target.HitPoints <= 0)
                {
                    _party.RemoveMember(target);
                }
            }
        }

        Console.WriteLine(_party.Members.Any(m => m.HitPoints > 0) ? "The party is victorious!" : "The party has been defeated...");
    }
}
