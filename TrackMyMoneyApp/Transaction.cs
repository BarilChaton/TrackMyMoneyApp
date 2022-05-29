using System;

namespace TrackMyMoneyApp
{
    class Transaction
    {
        public string TransactionType;
        public string TransactionProperty;
        public double TransactionValue;
        public DateTime TransactionMonth;


        public Transaction(string transactionType, string transactionProperty, double transactionValue, DateTime transactionMonth)
        {
            this.TransactionType = transactionType;
            this.TransactionProperty = transactionProperty;
            this.TransactionValue = transactionValue;
            this.TransactionMonth = transactionMonth;
        }

        public Transaction()
        {
        }

        public string setTransactionType(string transactionType)
        { this.TransactionType = transactionType; return this.TransactionType; }

        public string getTransactionType()
        { return this.TransactionType; }
        public string setTransactionProperty(string transactionProperty)
        { this.TransactionProperty = transactionProperty; return this.TransactionProperty; }

        public string getTransactionProperty()
        { return this.TransactionProperty; }
        public double setTransactionValue(double transactionValue)
        { this.TransactionValue = transactionValue; return this.TransactionValue; }
        public double getTransactionValue()
        { return this.TransactionValue; }

        public DateTime setTransactionMonth(DateTime transactionMonth)
        { this.TransactionMonth = transactionMonth; return this.TransactionMonth; }

        public DateTime getTransactionMonth()
        { return this.TransactionMonth; }

        public string toString()
        {
            return this.TransactionType + " " + this.TransactionProperty + " " + this.TransactionValue + " " + this.TransactionMonth;
        }
    }
}
