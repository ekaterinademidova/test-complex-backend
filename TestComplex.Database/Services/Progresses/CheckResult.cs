//using System;
//using System.Threading.Tasks;
//using TestComplex.Domain.Infrastucture;
//using TestComplex.Domain.Models;

//namespace TestComplex.Database.Services.Progresses
//{
//    public class CheckResult
//    {
//        private readonly IProgressManager _progressManager;

//        public CheckResult(IProgressManager progressManager)
//        {
//            _progressManager = progressManager;
//        }

//        public async Task<Result> Do(Result result, Question[] data)
//        {
//            //await _progressManager.
//            //     CreateProgress(Progress progress);
//            //var progress = new Progress
//            //{
//            //    UserId = request.UserId,
//            //    TopicId = request.TopicId,
//            //    Date = request.Date,
//            //    TestTime = request.TestTime,
//            //    Mark = request.Mark
//            //};

//            //if (await _progressManager.CreateProgress(progress) <= 0)
//            //{
//            //    throw new Exception("Failed to create progress");
//            //}

//            //return new Response
//            //{
//            //    UserId = progress.UserId,
//            //    TopicId = progress.TopicId,
//            //    Date = progress.Date,
//            //    TestTime = progress.TestTime,
//            //    Mark = request.Mark
//            //};
//        }

//        //public class Request
//        //{
//        //    public long UserId { get; set; }
//        //    public long TopicId { get; set; }
//        //    public DateTime Date { get; set; }
//        //    public TimeSpan TestTime { get; set; }
//        //    public double Mark { get; set; }
//        //}

//        //public class Response
//        //{
//        //    public long Id { get; set; }
//        //    public long UserId { get; set; }
//        //    public long TopicId { get; set; }
//        //    public DateTime Date { get; set; }
//        //    public TimeSpan TestTime { get; set; }
//        //    public double Mark { get; set; }
//        //}

//        public class Result
//        {
//            public long TopicId { get; set; }
//            public Answers[] Answers { get; set; }
//        }

//        public class Answers
//        {
//            public long QuestionId { get; set; }
//            public long[] SelectedAnswers { get; set; }
//        }
//    }
//}
