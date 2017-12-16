using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IMessageInboxRepository
    {
        void Insert(MessageInbox messageInbox);
        void Update(MessageInbox messageInbox);
        void Delete(Guid messageID);
        List<MessageInbox> ReadByUserID(Guid userID);
        List<MessageInbox> ReadByAnnouncementsID(Guid annoucementID);
        MessageInbox ReadByID(MessageInbox messageID);
    }
}
