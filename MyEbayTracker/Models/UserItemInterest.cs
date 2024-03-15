public class UserItemInterest
{
    public string UserId { get; set; }
    public virtual User User { get; set; }
    public int ItemOfInterestId { get; set; }
    public virtual ItemOfInterest ItemOfInterest { get; set; }
}
