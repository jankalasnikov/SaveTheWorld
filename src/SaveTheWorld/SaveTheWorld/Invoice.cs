using System;
namespace SaveTheWorld
{
    class Invoice
    {
        private int InvoiceNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public double TotalPrice { get; set; }

        public Invoice()
        {

        }

        public Invoice(int invoiceNo, DateTime paymentDate, double totalPrice)
        {
            this.InvoiceNo = invoiceNo;
            this.PaymentDate = paymentDate;
            this.TotalPrice = totalPrice; 
        }
    }
}
