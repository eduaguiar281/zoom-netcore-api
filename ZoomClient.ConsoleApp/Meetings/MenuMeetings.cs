using System;
using System.Collections.Generic;
using System.Text;

namespace ZoomClient.ConsoleApp.Meetings
{
    public class MenuMeetings: MenuBase
    {
        public MenuMeetings(IItemMenu menuPai)
            :base(menuPai, "API ZOOM- Menu Meeting")
        {
            ItensMenu.Add(1, new CriarMeeting(this));
        }
    }
}
