using MVC_QA_Contest.Custom_Model;
using MVC_QA_Contest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace MVC_QA_Contest.Controllers
{
    public class QAController : Controller
    {
        sahilEntities _db = new sahilEntities();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult CreateTest()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult CreateTest(testTable newTest)
        {
            if (ModelState.IsValid)
            {
                _db.testTables.Add(newTest);
                _db.SaveChanges();
                int id = newTest.test_id;
                return RedirectToAction("AddQuestion", new { id = id });
            }
            else
            {
                return View(newTest);
            }
        }

        public ActionResult AddQuestion(int id)
        {
            Question question = new Question
            {
                test_id = id
            };
            return View(question);
        }

        [HttpPost]
        public ActionResult AddQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                _db.Questions.Add(question);
                _db.SaveChanges();
                return RedirectToAction("AddQuestion", new { id = question.test_id });
            }
            else
            {
                return View(question);
            }
        }


        public ActionResult ListOfTest()
        {
            List<testTable> testTables = _db.testTables.ToList();
            return View(testTables);
        }

        public ActionResult StartTest(int id)
        {
            List<Question> testQuestions = _db.Questions.Where(q => q.test_id == id).OrderBy(x => x.id).ToList();
            return View(testQuestions[0]);
        }

        [HttpPost]
        public ActionResult GetQuestion(Question ans, int count)
        {

            Test answer = new Test();
            answer.question_id = ans.id;
            answer.answer = ans.Uans;
            answer.test_id = Convert.ToInt32(ans.test_id);

            answer.id = string.Concat(answer.test_id.ToString(), answer.question_id.ToString());

            _db.Tests.AddOrUpdate(answer);
            _db.SaveChanges();

            Question testQuestion = _db.Questions.Where(x => x.test_id == ans.test_id).OrderBy(x => x.id).Skip(count).Take(1).FirstOrDefault();
            if (testQuestion == null)
            {
                return RedirectToAction("Result", new { id = answer.test_id });
            }

            else
            {
                return PartialView("GetQuestion", testQuestion);
            }
        }

        public ActionResult Result(int id)
        {
            Result result = new Result();

            List<Test> test = _db.Tests.Where(t => t.test_id == id).ToList();

            result.totalQuestion = test.Count;

            result.skipped = _db.Tests.Where(t => t.answer == 0).Count();
            result.test_id = id;
            result.id = id;
            result.Total = 0;

            foreach (var item in test)
            {
                int ans = Convert.ToInt32(item.answer);

                int que_ans = Convert.ToInt32(_db.Questions.Where(q => q.test_id == id && q.id==item.question_id).Select(q => q.answer).FirstOrDefault());
                if (que_ans == ans)
                {
                    result.Total++;
                }
            }

            _db.Results.AddOrUpdate(result);
            _db.SaveChanges();
            return View(result);
        }



        public ActionResult ListOfQuestions()
        {
            var questions = _db.Questions.Select(q => new SelectListItem
            {
                Value = q.id.ToString(),
                Text = q.question1,
            }).ToList();

            var viewModel = new QuestionList
            {
                Questions = questions
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GetTestQuestions()
        {
            return View();
        }
    }
}