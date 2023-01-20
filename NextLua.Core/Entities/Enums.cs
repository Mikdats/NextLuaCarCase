using System.ComponentModel.DataAnnotations;

namespace NextLua.Core.Entities;

public static class Enums
{
    public enum PaymentStatus
    {
        [Display(Name = "Completed")] Completed = 1,

        [Display(Name = "InProcess")] InProcess = 2
    }
    public enum PurchaseStatus
    {
        [Display(Name = "Approved")] Approved = 1,

        [Display(Name = "Waiting")] Waiting = 2
    }
}