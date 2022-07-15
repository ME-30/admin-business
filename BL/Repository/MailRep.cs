using System.Linq;
using WebApplication7.BL.Interface;
using WebApplication7.Models;
using WebApplication7.DAL.Database;
using WebApplication7.DAL.Entities;
using AutoMapper;
using System;

namespace WebApplication7.BL.Repository
{
    public class MailRep : IMailRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public MailRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }
       
        public void Add(MailVM Mail)
        {
            // Mapping
            var data = mapper.Map<Mail>(Mail);

            db.Mail.Add(data);
            db.SaveChanges();
        }

        public IQueryable<MailVM> Get()
        {
            IQueryable<MailVM> data = GetAllMails();
            return data;
        }

        private IQueryable<MailVM> GetAllMails()
        {
            return db.Mail
                       .Select(a => new MailVM { id = a.id, Title = a.Title, Massege = a.Massege , Customer =a.Customer});
        }
    }
}
