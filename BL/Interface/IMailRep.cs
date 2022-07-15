using System.Linq;
using WebApplication7.Models;

namespace WebApplication7.BL.Interface
{
    public interface IMailRep
    {
        IQueryable<MailVM> Get();
        void Add(MailVM mail);


    }
}
