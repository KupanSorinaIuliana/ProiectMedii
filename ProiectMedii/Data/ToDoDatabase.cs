using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using ProiectMedii.Models;

namespace ProiectMedii.Data
{
    public class ToDoDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ToDoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TypeOfCondition>().Wait();
            _database.CreateTableAsync<Priority>().Wait();
            _database.CreateTableAsync<Job>().Wait();
        }
        public Task<int> SavePriorityAsync(Priority priority)
        {
            if(priority.ID!=0)
            {
                return _database.UpdateAsync(priority);
            }
            else
            {
                return _database.InsertAsync(priority);
            }
        }
        public Task<List<Priority>> DeletePriorityAsync(Priority priority)
        {
            return _database.QueryAsync<Priority>("delete from Priority where Nume='" + priority.Nume + "'");

        }
        public Task<List<Priority>> GetPrioritiesAsync()
        {
            return _database.Table<Priority>().ToListAsync();
        }
        public Task<int> SaveTypeOfConditionAsync(TypeOfCondition condition)
        {
            if(condition.ID !=0)
            {
                return _database.UpdateAsync(condition);
            }
            else
            {
                return _database.InsertAsync(condition);
            }
        }
        public Task<List<TypeOfCondition>> DeleteTypeOfConditionAsync(TypeOfCondition condition)
        {
            return _database.QueryAsync<TypeOfCondition>("delete from TypeOfCondition where Tip='" + condition.Tip + "'");
        }
        public Task<List<TypeOfCondition>> GetTypeOfConditionAsync()
        {
            return _database.Table<TypeOfCondition>().ToListAsync();
        }
        public Task<int> SaveJobAsync(Job job)
        {
            if(job.ID != 0)
            {
                return _database.UpdateAsync(job);
            }
            else
            {
                return _database.InsertAsync(job);
            }
        }
        public Task<List<Job>> DeleteJobAsync(Job job)
        {
            return _database.QueryAsync<Job>("delete from Job where Nume='"+ job.Nume+"'"); 
        }
        public Task<List<Job>> GetJobAsync()
        {
            return _database.QueryAsync<Job>(
                "select Job.ID as ID, Job.Nume as Nume, Job.Descriere as Descriere , Job.Date as Date, PriorityId  from Job  ");
        }
        public Task<Job> GetJobIdAsync(int id)
        {
            return _database.Table<Job>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<List<TypeOfCondition>> GetConditionIdAsync(TypeOfCondition t)
        {
            return _database.QueryAsync<TypeOfCondition>("select TypeOfCondition.Tip from TypeOfCondition where ID='" + t.ID + "'");
           // return _database.Table<TypeOfCondition>()
             //   .Where(i => i.ID == t.ID)
               // .FirstOrDefaultAsync();
        }
        public Task<List<Job>> GetJobToDoAsync()
        {
            return _database.QueryAsync<Job>(
                "select Job.ID as ID, Job.Nume as Nume, Job.Descriere as Descriere , Job.Date as Date, PriorityId, TypeId from Job join Priority on Job.PriorityId=Priority.ID where Job.TypeId=1 ");
        }
        public Task<List<Job>> GetJobInProgressAsync()
        {
            return _database.QueryAsync<Job>(
                "select Job.ID as ID, Job.Nume as Nume, Job.Descriere as Descriere , Job.Date as Date, PriorityId, TypeId  from Job where Job.TypeId=2 ");
        }
        public Task<List<Job>> GetJobDoneAsync()
        {
            return _database.QueryAsync<Job>(
                "select Job.ID as ID, Job.Nume as Nume, Job.Descriere as Descriere , Job.Date as Date, PriorityId, TypeId  from Job where Job.TypeId=3 ");
        }
    }
}
//return _database.DeleteAsync(job);
//return _database.QueryAsync<Job>("delete from Job where Nume = ?",job.Nume);