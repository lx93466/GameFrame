using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFrame
{
    class MsgManager : Singleton<MsgManager>
    {
        public class MsgId
        {
            int m_msgId;

            public MsgId(int id)
            {
                m_msgId = id;
            }

            public static bool operator ==(MsgId msg1, MsgId msg2)
            {
                bool bEqual = false;

                if (msg1.m_msgId == msg2.m_msgId)
                {
                    bEqual = true;
                }
                return bEqual;
            }

            public static bool operator !=(MsgId msg1, MsgId msg2)
            {             
                return !(msg1 == msg2);
            }
        }

        List<MsgId> m_allMsgIds = new List<MsgId>();

        public static MsgId GenerateMsgId()
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse("1970-1-1");

            MsgId msgId = new MsgId(ts.Milliseconds);

            while (MsgManager.GetInstance().m_allMsgIds.Contains(msgId))
            {
                ts = DateTime.Now - DateTime.Parse("1970-1-1");

                msgId = new MsgId(ts.Milliseconds);
            }
            return msgId;
        }
    }
}
