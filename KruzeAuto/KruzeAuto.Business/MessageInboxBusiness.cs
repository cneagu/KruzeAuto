using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class MessageInboxBusiness
    {
        #region Methdos
        public void Insert(MessageInbox messageInbox)
        {
            BusinessContext.Current.RepositoryContext.MessageInboxRepository.Insert(messageInbox);
        }

        public void Update(MessageInbox messageInbox)
        {
            BusinessContext.Current.RepositoryContext.MessageInboxRepository.Update(messageInbox);
        }

        public void Delete(Guid messageID)
        {
            BusinessContext.Current.RepositoryContext.MessageInboxRepository.Delete(messageID);
        }

        public List<MessageInbox> ReadByUserID(Guid userID)
        {
            return BusinessContext.Current.RepositoryContext.MessageInboxRepository.ReadByUserID(userID);
        }

        public List<MessageInbox> ReadByAnnouncementsID(Guid annoucementID)
        {
            return BusinessContext.Current.RepositoryContext.MessageInboxRepository.ReadByAnnouncementsID(annoucementID);
        }

        public MessageInbox ReadByID(MessageInbox messageID)
        {
            return BusinessContext.Current.RepositoryContext.MessageInboxRepository.ReadByID(messageID);
        }
        #endregion
    }
}
