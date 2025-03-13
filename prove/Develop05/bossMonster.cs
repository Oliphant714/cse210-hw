class BossMonster
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    private int _maxHealth;

    public BossMonster(string name, int health)
    {
        Name = name;
        Health = health;
        _maxHealth = health;
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }
    
    public bool IsDefeated()
    {
        return Health <= 0;
    }
    
    public string Status()
    {
        return $"{Name} - HP: {Health}/{_maxHealth}";
    }
}