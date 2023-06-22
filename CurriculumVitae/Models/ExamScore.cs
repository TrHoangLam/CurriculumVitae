namespace CurriculumVitae.Models
{
    public class ExamScore
    {



        public string? Id { get; set; }
        public string? Subject { get; set; }

        public string? TeacherName { get; set; }
        public float OralExam { get; set; }

        public float FifteenMinScore { get; set; }

        public float MidtermExam { get; set; }

        public float FinalExam { get; set; }

        public float ToltalScore { get; set; }
        public string? ReviewAndEvaluation { get; set; }
        public academicReview AcademicReview { get; set; }
        public conductcomments ConductComments { get; set; }


    }
}
public enum academicReview { EXCELLENT, GOOD, BAD }
public enum conductcomments { GOOD, BAD }
