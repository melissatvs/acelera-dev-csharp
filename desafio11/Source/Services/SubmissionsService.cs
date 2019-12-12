using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private CodenationContext context;
        public SubmissionService(CodenationContext context)
        {
            this.context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return context.Candidates.
                Where(x => x.AccelerationId == accelerationId).
                Select(x => x.User).
                SelectMany(x => x.Submissions).
                Where(x => x.ChallengeId == challengeId).
                Distinct().
                ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return context.Submissions.
                Where(x => x.ChallengeId == challengeId).
                Max(x => x.Score);
        }

        public Submission Save(Submission submission)
        {
            var found = context.Submissions.Find(submission.UserId, submission.ChallengeId);
            if (found == null)
                context.Submissions.Add(submission);
            else
                found.Score = submission.Score;
            context.SaveChanges();
            return submission;
        }
    }
}
