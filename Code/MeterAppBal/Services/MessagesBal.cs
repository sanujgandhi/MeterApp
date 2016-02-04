using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;
using MeterAppEntity.Model;

namespace MeterAppBal.Services
{
    public class MessagesBal:BaseBal, IMessagesBal
    {
        

        public MeterAppEntity.Model.Messages GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Messages> GetMessageBySenderIdReceiverIdandProjectId(string senderId, string receiverId, int projectId)
        {
            using (var repo = UnitOfWork.GenericRepository<Messages>())
            {
                if (senderId != "" && receiverId!=""&&projectId!=null)
                {
                    var result = repo.GetAll().Where(a => a.SenderId == senderId && a.RecieverId == receiverId && a.ProjectId == projectId).ToList();
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public Messages Create(Messages messages)
        {
            using (var repo = UnitOfWork.GenericRepository<Messages>())
            {
                if (messages != null)
                {
                    repo.AutoSave = true;
                    repo.Create(messages);
                    return messages;
                }
                else
                {
                    return null;
                }
            }
        }

        public MeterAppEntity.Model.Messages Update(MeterAppEntity.Model.Messages objMessages)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Messages Delete(MeterAppEntity.Model.Messages objMessages)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeterAppEntity.Model.Messages> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
