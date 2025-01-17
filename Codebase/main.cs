global using System;
global using System.Collections.Generic;

// Define Brigade class
class Brigade {
    public int HP
    public int ATK
    public int DEF
    public int SPD
    public int Skill1
    public boolean isAlive() {
        return HP > 0
    }
}

// Define player and enemy brigades
Brigade playerBrigade = new Brigade()
Brigade enemyBrigade = new Brigade()

// Define scalar variables
double playerScalar = 1.0
double enemyScalar = 1.0
double playerDRScalar = 1.0
double enemyDRScalar = 1.0

// Function to determine turn order
function turnOrder(playerBrigade: Brigade, enemyBrigade: Brigade): String {
    if (playerBrigade.SPD >= enemyBrigade.SPD) {
        return "player"
    } else {
        return "enemy"
    }
}

// Function to check status
function checkStatus(playerBrigade: Brigade, enemyBrigade: Brigade) {
    Console.WriteLine("Player HP: ${playerBrigade.HP}")
    Console.WriteLine("Enemy HP: ${enemyBrigade.HP}")
}

// Function for skill resolution
function skillResolution(playerBrigade: Brigade, enemyBrigade: Brigade) {
    if (playerBrigade.Skill1 == 1) {
        Console.WriteLine("Player Brigade used Skill 1")
    }
    // TODO: Add code to check if skill is a hit, crit, etc
    // TODO: If skill fails, perform regular attack
}

// Function for enemy skill resolution
function enemySkillResolution(playerBrigade: Brigade, enemyBrigade: Brigade) {
    if (enemyBrigade.Skill1 == 1) {
        Console.WriteLine("Enemy Brigade used Skill 1")
    }
    // TODO: Add code to check if skill is a hit, crit, etc
    // TODO: If skill fails, perform regular attack
}

// Function for attack
function attack(playerBrigade: Brigade, enemyBrigade: Brigade) {
    // TODO: Add code to determine target
    int playerAttack = playerBrigade.ATK * playerScalar
    int enemyAttack = enemyBrigade.ATK * enemyScalar
    int playerDR = playerBrigade.DEF * playerDRScalar
    int enemyDR = enemyBrigade.DEF * enemyDRScalar
    int finalPlayerAttack = playerAttack - enemyDR
    int finalEnemyAttack = enemyAttack - playerDR
    
    // Update enemy and player HP
    enemyBrigade.HP = enemyBrigade.HP - finalPlayerAttack
    playerBrigade.HP = playerBrigade.HP - finalEnemyAttack
}

// Main game loop
while (playerBrigade.isAlive() && enemyBrigade.isAlive()) {
    if (turnOrder(playerBrigade, enemyBrigade) == "player") {
        checkStatus(playerBrigade, enemyBrigade)
        skillResolution(playerBrigade, enemyBrigade)
        attack(playerBrigade, enemyBrigade)
    } else {
        checkStatus(playerBrigade, enemyBrigade)
        enemySkillResolution(playerBrigade, enemyBrigade)
        attack(playerBrigade, enemyBrigade)
    }
}

// Game over
if (playerBrigade.isAlive()) {
    Console.WriteLine("Player wins!")
} else {
    Console.WriteLine("Enemy wins!")
}
