﻿using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        void MessageAddBL(Message message);
        Message GetByID(int id);//id ye göre get kategory metodu
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
