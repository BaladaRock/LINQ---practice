namespace LINQ_applications
{
    public class TestResults
    {
        public TestResults(string id, string familyId, int score)
        {
            Id = id;
            FamilyId = familyId;
            Score = score;
        }

        public string FamilyId { get; set; }

        public string Id { get; set; }

        public int Score { get; set; }
    }
}