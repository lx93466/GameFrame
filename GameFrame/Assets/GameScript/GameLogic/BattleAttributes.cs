using GameFrame;
/// <summary>
/// 战斗属性，当进入副本战斗时，每个敌人、英雄都要有此属性
/// </summary>
public class BattleAttributes : GameBehaviour 
{
    public float m_attackDistance = 0;//攻击距离
    public int m_hp = 0;//血量
    public int m_speed = 0; //速度
    public int m_attackDamage = 0; //攻击伤害
    public float m_attackTime = 2;//隔多少秒攻击一次

    //技能伤害
    public int m_skill1Damage = 0;
    public int m_skill2Damage = 0;
    public int m_skill3Damage = 0;

    public void Init(float attackDistance, 
        int hp, 
        int speed, 
        int attackDamage,
        int skill1Damage = 0, 
        int skill2Damage = 0, 
        int skill3Damage = 0 )
    {
        m_attackDistance = attackDistance;
        m_speed = speed;
        m_hp = hp;
        m_attackDamage = attackDamage;

        m_skill1Damage = skill1Damage;
        m_skill2Damage = skill2Damage;
        m_skill3Damage = skill3Damage;
    }
}

