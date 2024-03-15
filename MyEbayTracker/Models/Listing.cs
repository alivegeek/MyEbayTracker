using System;

public class Listing
{
    public int Id { get; set; }
    public int ItemOfInterestId { get; set; }
    public string Title { get; set; }
    public decimal PriceValue { get; set; }
    public string PriceCurrency { get; set; }
    public string Condition { get; set; }
    public string ImageUrl { get; set; }
    public string ListingUrl { get; set; }
    public string SellerUsername { get; set; }
    public double SellerFeedbackPercentage { get; set; }
    public int SellerFeedbackScore { get; set; }
    public decimal ShippingCostValue { get; set; }
    public string ShippingCostCurrency { get; set; }
    public DateTime MinEstimatedDeliveryDate { get; set; }
    public DateTime MaxEstimatedDeliveryDate { get; set; }
    public bool ReturnsAccepted { get; set; }
    public int ReturnPeriodValue { get; set; }
    public string ReturnPeriodUnit { get; set; }
    public virtual ItemOfInterest ItemOfInterest { get; set; }
}
