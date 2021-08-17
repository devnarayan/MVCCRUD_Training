using MVCCRUD_Training.Models;
using MVCCRUD_Training.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUD_Training.Service
{
    public class StudentDataService
    {
        Models.WPGSMEntities db;
        public StudentDataService()
        {
            db = new WPGSMEntities();
        }
        public StudentDataService(WPGSMEntities _db)
        {
            db = _db;
        }
        //1. Add Student
        //2. Update Studnet
        //3. Get all Student
        //4. Get Single Student Info
        //5. Delete Student.

        public int AddAnswer(AnswerViewModel model)
        {
            MstAnswer answer = new MstAnswer()
            {
                Id = model.Id,
                AccessID = model.AccessID,
                AnswerName = model.AnswerName,
                AnswerValue = model.AnswerValue,
                FormTypeId = model.FormTypeId
            };

            db.MstAnswers.Add(answer);
            return db.SaveChanges(); //Success = 1, Fail = 0;
        }

        public int UpdateAnswer(AnswerViewModel model)
        {
            //Get existing record.
            var answer = db.MstAnswers.Where(s => s.Id == model.Id).FirstOrDefault();
            if (answer != null)
            {
                // Update data.
                answer.AnswerName = model.AnswerName;
                answer.AnswerValue = model.AnswerValue;

                //Save back to db.
                db.Entry<MstAnswer>(answer).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges(); //Success = 1, Fail = 0;
            }
            else
            {
                //-1 == Record not found.
                return -1;
            }
        }
        public List<AnswerViewModel> GetAnswerList()
        {
            var answers = db.MstAnswers.ToList();
            List<AnswerViewModel> vm = new List<AnswerViewModel>();
            foreach (var answer in answers)
            {
                AnswerViewModel answerView = new AnswerViewModel()
                {
                    AccessID = answer.AccessID,
                    AnswerName = answer.AnswerName,
                    AnswerValue = answer.AnswerValue,
                    FormTypeId = answer.FormTypeId,
                    Id = answer.Id
                };
                vm.Add(answerView);
            }
            return vm;
        }

        public AnswerViewModel GetAnswer(int id)
        {
            var answer = db.MstAnswers.Where(s => s.Id == id).FirstOrDefault();
            if(answer != null)
            {
                AnswerViewModel answerView = new AnswerViewModel()
                {
                    AccessID = answer.AccessID,
                    AnswerName = answer.AnswerName,
                    AnswerValue = answer.AnswerValue,
                    FormTypeId = answer.FormTypeId,
                    Id = answer.Id
                };
                return answerView;
            }
            else
            {
               return null;
            }
        }

        public int DeleteAnswer(int id)
        {
            var answer = db.MstAnswers.Where(s => s.Id == id).FirstOrDefault();
            if (answer != null)
            {
                db.MstAnswers.Remove(answer);
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}