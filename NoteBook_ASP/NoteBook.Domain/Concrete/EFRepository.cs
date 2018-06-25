using NoteBook.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBook.Domain.Entity;

namespace NoteBook.Domain.Concrete
{
    public class EFRepository : IRepository
    {
        private EFDbContext db = new EFDbContext();

        //private NoteBookEntities db = new NoteBookEntities();

        public IQueryable<State> States { get { return db.States; } }
        public IQueryable<AnOrder> Orders { get { return db.AnOrders; } }
        public IQueryable<UserType> UserTypes { get { return db.UserTypes; } }
        public IQueryable<User> Users { get { return db.Users; } }

        public AnOrder SaveOrder(AnOrder _order)
        {
            AnOrder result = null;
            try
            {
                AnOrder dbEntry = db.AnOrders.Find(_order.id);
                //Если запись о проекте существует - обновляем ее данные
                if (dbEntry != null)
                {
                    dbEntry.customer_name = _order.customer_name;
                    dbEntry.description = _order.description;
                }
                //Если нет - создаем запись
                else
                {
                    db.AnOrders.Add(_order);
                }
                db.SaveChanges();
                result = db.AnOrders.Find(_order.id);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public void AddOrder(AnOrder _order)
        {
            
                AnOrder dbEntry = db.AnOrders.Add(_order);
                if (dbEntry != null)
                {
                    dbEntry.customer_name = _order.customer_name;
                    dbEntry.description = _order.description;
                    dbEntry.state_id = _order.state_id;
                    dbEntry.created_at = _order.created_at;
                }
                //Если нет - создаем запись
                else
                {
                    db.AnOrders.Add(_order);
                }
                db.SaveChanges();
           



        }
       
        public void addState(State _states)
        {
           
            State dbEntry = db.States.Add(_states);
            if (dbEntry != null)
            {
               dbEntry.name = _states.name;
              
            }
            //Если нет - создаем запись
            else
            {
                db.States.Add(_states);
            }
            db.SaveChanges();
           
        }

        public void addLogin(User _users)
        {
            User dbEntry = db.Users.Add(_users);
            if (dbEntry != null)
            {
                dbEntry.login = _users.login;
                //dbEntry.login = "misha";
                dbEntry.password = _users.password;
               // dbEntry.password = "1111";
                dbEntry.user_type_id = 1;
                Console.WriteLine("test");
                
            }
            else
            {
                db.Users.Add(_users);
            }
            db.SaveChanges();
            
        }

        public void DelOrder(int _orderId)
        {
            try
            {
                AnOrder anOrder = db.AnOrders.Find(_orderId);
                db.AnOrders.Remove(anOrder);
                db.SaveChanges();
            }

            catch (Exception ex)
            {

            }
        }

        public void DelState(int _stateId)
        {
            try
            {
                State state = db.States.Find(_stateId);
                db.States.Remove(state);
                db.SaveChanges();
            }

            catch (Exception ex)
            {

            }
        }
    }
}

