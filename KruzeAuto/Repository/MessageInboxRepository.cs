using KruseAuto.Repository.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace KruseAuto.Repository
{
    public class MessageInboxRepository : BaseRepository<MessageInbox>
    {
        #region Methdos
        public void Insert(MessageInbox messageInbox)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MessageID", messageInbox.MessageID),
                new SqlParameter("@UserID", messageInbox.UserID),
                new SqlParameter("@AnnoucementID", messageInbox.AnnoucementID),
                new SqlParameter("@CreationDate", messageInbox.CreationDate),
                new SqlParameter("@Read", messageInbox.Read),
                new SqlParameter("@MesageContent", messageInbox.MesageContent) };
            Procedure("dbo.MessageImbox_Insert", parameters);
        }

        public void Update(MessageInbox messageInbox)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MessageID", messageInbox.MessageID),
                new SqlParameter("@Read", messageInbox.Read),
                new SqlParameter("@MesageContent", messageInbox.MesageContent) };
            Procedure("dbo.MessageImbox_UpdateByID", parameters);
        }

        public void DeleteByID(Guid messageID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MessageID", messageID) };
            Procedure("dbo.MessageImbox_DeleteByID", parameters);
        }

        public List<MessageInbox> ReadByUserID(Guid userID)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserID", userID) };
            return ReadAll("dbo.MessageImbox_ReadByUserID");
        }

        public List<MessageInbox> ReadByAnnouncementsID(Guid annoucementID)
        {
            SqlParameter[] parameters = { new SqlParameter("@AnnoucementID", annoucementID) };
            return ReadAll("dbo.MessageImbox_ReadByAnnouncementsID");
        }

        public MessageInbox ReadByID(MessageInbox messageID)
        {
            List<MessageInbox> result = new List<MessageInbox>();
            SqlParameter[] parameters = { new SqlParameter("@MessageID", messageID) };
            result = ReadAll("dbo.MessageImbox_ReadByID", parameters);
            return result[0];
        }

        protected override MessageInbox GetModelFromReader(SqlDataReader reader)
        {
            MessageInbox messageImbox = new MessageInbox();
            messageImbox.MessageID = reader.GetGuid(reader.GetOrdinal("MessageID"));
            messageImbox.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            messageImbox.AnnoucementID = reader.GetGuid(reader.GetOrdinal("AnnoucementID"));
            messageImbox.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            messageImbox.Read = reader.GetBoolean(reader.GetOrdinal("Read"));
            messageImbox.MesageContent = reader.GetString(reader.GetOrdinal("MesageContent"));
            return (messageImbox);
        }
        #endregion
    }
}
