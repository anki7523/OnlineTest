namespace OnlineTest.Models
{
    public class WinnerModel
    {
        public List<Top3WinnerModel> Top3WinnerList { get; set; }
        public int[] Top3WinnerPrize { get; set; }
        
    }
    public class Top3WinnerModel
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int TotalCorrectAnswers { get; set; }
    }

}
