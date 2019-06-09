using NLayerKSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.DAL.Repositories
{
    public class SelectionRepository : IRepository<Selection>
    {
        private KSysContext db;

        public SelectionRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Selection item)
        {
            db.Selection.Add(item);
        }

        public void Delete(int id)
        {
            Selection selection = db.Selection.Find(id);
            if (selection != null)
            {
                db.Selection.Remove(selection);
            }
        }

        public void Update(Selection item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Selection Get(int id)
        {
            return db.Selection.Find(id);
        }

        public IEnumerable<Selection> GetAll()
        {
            return db.Selection;
        }

        public IEnumerable<Selection> Find(Func<Selection, bool> predicate)
        {
            return db.Selection.Where(predicate).ToList();
        }

        public IEnumerable<object> FindJoin(Selection selection)
        {
            var result = (from user in db.User
                          join ed in db.Education on user.Id equals ed.UserId into temp_ed from sub_ed in temp_ed.DefaultIfEmpty()
                          join exp in db.Experience on user.Id equals exp.UserId into temp_exp from sub_exp in temp_exp.DefaultIfEmpty()
                          join tr in db.Training on user.Id equals tr.UserId into temp_tr from sub_tr in temp_tr.DefaultIfEmpty()
                          join cer in db.CertificationTest on user.Id equals cer.UserId into temp_cer from sub_cer in temp_cer.DefaultIfEmpty()
                          join sp in db.SportProgramming on user.Id equals sp.UserId into temp_sp from sub_sp in temp_sp.DefaultIfEmpty()
                          where (selection.EducationId == null || (from exist_ed in db.Education where exist_ed.UserId == user.Id && exist_ed.Id == selection.EducationId select exist_ed).Any()) && 
                                (selection.ExperienceId == null || (from exist_exp in db.Experience where exist_exp.UserId == user.Id && exist_exp.Id == selection.ExperienceId select exist_exp).Any()) &&
                                (selection.TrainingId == null || (from exist_tr in db.Training where exist_tr.UserId == user.Id && exist_tr.Id == selection.TrainingId select exist_tr).Any()) &&
                                (selection.CertificationTestId == null || (from exist_cer in db.CertificationTest where exist_cer.UserId == user.Id && exist_cer.Id == selection.CertificationTestId select exist_cer).Any()) &&
                                (selection.SportProgrammingId == null || (from exist_sp in db.SportProgramming where exist_sp.UserId == user.Id && exist_sp.Id == selection.SportProgrammingId select exist_sp).Any()) &&
                                user.RoleId == 1 // Developer RoleId = 1
                          select new SelectionJoinQueryResult() { User = user, Education = sub_ed, Experience = sub_exp, Training = sub_tr, CertificationTest = sub_cer, SportProgramming = sub_sp }).ToList();

            return result;
        }

        public IEnumerable<Selection> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Selection GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Selection GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Selection CheckToExistUserEmail(Selection model)
        {
            throw new NotImplementedException();
        }

        public Selection CheckToExistUserEmailAndPassword(Selection model)
        {
            throw new NotImplementedException();
        }

        public Selection GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public class SelectionJoinQueryResult
        {
            public User User { get; set; }
            public Education Education { get; set; }
            public Experience Experience { get; set; }
            public Training Training { get; set; }
            public CertificationTest CertificationTest { get; set; }
            public SportProgramming SportProgramming { get; set; }
        }
    }

}
