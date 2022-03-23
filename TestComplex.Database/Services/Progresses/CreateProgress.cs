using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Database.Services.Progresses
{
    public class CreateProgress
    {
        private readonly IProgressManager _progressManager;
        private readonly IAnswerManager _answerManager;

        public CreateProgress(IProgressManager progressManager, IAnswerManager answerManager)
        {
            _progressManager = progressManager;
            _answerManager = answerManager;
        }

        public async Task<Response> Do(Request request, Question[] data)
        {
            int score = 0;
            int k = 0;
            List<long> wrongs = new List<long>();
            for (int i = 0; i < data.Length; i++)
            {
                Answers userAnswer = request.UserAnswers
                    .Where(x => x.QuestionId == data[i].Id)
                    .FirstOrDefault();

                AnswerViewModel[] dataAnswers = _answerManager.GetAnswers(data[i].Id, x => new AnswerViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Status = x.Status,
                    QuestionId = x.QuestionId
                }).ToArray();

                for (int j = 0; j < dataAnswers.Length; j++)
                {
                    if (userAnswer.SelectedAnswers.Contains(dataAnswers[j].Id))
                    {
                        if (dataAnswers[j].Status)
                        {
                            score++;
                        } else
                        {
                            wrongs.Add(data[i].Id);
                        }
                    }
                    else if (dataAnswers[j].Status)
                    {
                        wrongs.Add(data[i].Id);
                    }

                    if (dataAnswers[j].Status)
                    {
                        k++;
                    }
                }
            }

            var progress = new Progress
            {
                UserId = request.UserId,
                TopicId = request.TopicId,
                Date = DateTime.Now,
                TestTime = new TimeSpan(request.UserTime.Hours, request.UserTime.Minutes, request.UserTime.Seconds),
                Mark = (double) score / k * 100
            };

            var result = new Result
            {
                Progress = progress,
                WrongQuestions = wrongs.Distinct().ToList()
            };

            if (await _progressManager.CreateProgress(result) <= 0)
            {
                throw new Exception("Failed to create progress");
            }

            return new Response
            {
                Progress = result.Progress,
                WrongQuestions = result.WrongQuestions
            };
        }

        public class Request
        {
            public long UserId { get; set; }
            public long TopicId { get; set; }
            public Time UserTime { get; set; }
            public Answers[] UserAnswers { get; set; }
        }

        public class Response
        {
            public Progress Progress { get; set; }
            public List<long> WrongQuestions { get; set; }
        }

        public class Time
        {
            public int Hours { get; set; }
            public int Minutes { get; set; }
            public int Seconds { get; set; }
        }

        public class Answers
        {
            public long QuestionId { get; set; }
            public long[] SelectedAnswers { get; set; }
        }

        public class AnswerViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public bool Status { get; set; }
            public long QuestionId { get; set; }
        }

        //public class ProgressViewModel
        //{
        //    public long Id { get; set; }
        //    public long UserId { get; set; }
        //    public long TopicId { get; set; }
        //    public DateTime Date { get; set; }
        //    public TimeSpan TestTime { get; set; }
        //    public double Mark { get; set; }
        //}
    }
}
