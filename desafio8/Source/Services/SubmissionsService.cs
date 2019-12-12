using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private CodenationContext db;

        public SubmissionService(CodenationContext context)
        {
            db = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return db.Submissions
                .Where(s => s.ChallengeId == challengeId)
                .Distinct()
                .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return db.Submissions
                .Where(x => x.ChallengeId == challengeId)
                .Max(s => s.Score);
        }

        private Submission FindById(int userId, int challengeId)
        {
            return db.Submissions.FirstOrDefault(x => x.UserId == userId && x.ChallengeId == challengeId);
        }

        public Submission Save(Submission submission)
        {
            Submission Result;
            Submission submissionFind = FindById(submission.UserId, submission.ChallengeId);

            if (submissionFind == null)
            {
                db.Submissions.Add(submission);

                Result = submission;
            }
            else
            {
                Result = submissionFind;

                Result.Score = submission.Score;
                Result.CreateAt = submission.CreateAt;
            }

            db.SaveChanges();

            return Result;
        }
    }
}
