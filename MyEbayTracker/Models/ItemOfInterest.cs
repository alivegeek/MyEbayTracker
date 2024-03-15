public class ItemOfInterest
{
    public int Id { get; set; }
    public string EbayItemId { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<UserItemInterest> UserItemInterests { get; set; }
}