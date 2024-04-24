namespace WeddingWise_Core.Enums
{
    public static class WeddingWiseLookups
    {
        public enum UserType
        {
            Admin = 101,
            Employee,
            Agent,
            Client
        }
        public enum SweetType
        {
            PremiumCake = 101,
            Cake,
            PremiumKunafa,
            Kunafa
        }

        public enum BeverageType
        {
            SoftDrink = 101,
            Juice

        }

        public enum City
        {
            Amman = 101,
            Irbid,
            Zarqa,
            Aqaba
        }

        public enum Status
        {
            Pending = 101,   //A booking request has been made but not yet paid.
            Confirmed, //The booking request has been accepted.
            Cancelled, //The booking has been cancelled(Not Paid).
            Completed, //The event has taken place and the booking is now closed.
            Refunded   //The booking was cancelled and the payment was refunded.
        }

        public enum PaymentMethod
        {
            Visa = 101,
            PayPal,
            Wallet
        }

        public enum TransactionType
        {
            Income = 101,
            Outcome
        }
    }
}
