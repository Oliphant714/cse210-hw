using System;
using System.Collections.Generic;

// Main program to simulate game
public class Program
{
    public static void Main()
    {
        GameManager gameManager = new GameManager();

        // Create some characters
        PlayerCharacter warrior = new PlayerCharacter("Warrior", 100, 25, 10, "Warrior");
        PlayerCharacter mage = new PlayerCharacter("Mage", 80, 30, 5, "Mage");
        Enemy goblin = new Enemy("Goblin", 50, 15, 5, "Goblin", 3);

        // Create a party and add characters
        Party party = new Party("Heroes");
        party.AddCharacter(warrior);
        party.AddCharacter(mage);

        // Save party
        gameManager.SaveParty(party);

        // Create an encounter and add players and enemies
        Encounter encounter = new Encounter();
        encounter.Players.Add(warrior);
        encounter.Players.Add(mage);
        encounter.Enemies.Add(goblin);

        // Save encounter
        gameManager.SaveEncounter(encounter);

        // Start encounter
        encounter.StartEncounter();

        // Simulate turns
        encounter.ProcessTurn();
        encounter.ProcessTurn();
    }
}
