using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : ActorStats
{
    
    [Header("Experience")]
    public int experience=0;
    public int experienceToNextLevel=100;
    public int level=1;
    

    public override void Awake()
    {
        base.Awake();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        level++;
        experience -= experienceToNextLevel;
        experienceToNextLevel = calculateExperienceToNextLevel(level);
        
        //Increase stats
        // currentHealth += 10;
        // currentMoveSpeed += 0.1f;
        // currentArmor += 0.1f;
    }
    private int calculateExperienceToNextLevel(int level)
    {
        return 100 * level;
    }
}
