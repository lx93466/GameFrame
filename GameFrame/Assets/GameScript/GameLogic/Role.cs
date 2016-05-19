using GameFrame;

public class Role : GameBehaviour
{
    public float m_attackDistance = 1;//攻击距离
    public int m_hp = 200;//血量
    public int m_speed = 3; //速度
    public int m_damage = 20; //攻击力	

    protected BattleController m_battleController = BattleController.GetInstance();

    protected override void Init()
    {
        base.Init();
        m_battleController.m_enermiesTransform.Add(transform);
    }

    protected override void Uninit()
    {
        base.Uninit();
        m_battleController.m_enermiesTransform.Remove(transform);
    }
}