using GameFrame;

public enum AttackDirection
{
    Forward,//攻击前方
    Around//攻击四周
}

public enum HeroAttackType
{
    Attack1,  //第一次攻击 
    Attack2,  //第二次连击
    Skill1,   //技能1攻击
    Skill2,   //技能2攻击
    Skill3    //技能3攻击
}

public class Hero
{
    public float m_attackDistance = 1;//攻击距离
    public int m_hp = 200;//血量
    public int m_speed = 3; //速度
    public int m_damage = 20; //攻击力	
}
