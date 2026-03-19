using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        private readonly string m_customerName;
        private double m_balance;
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        private BankAccount() { }
        /// <summary>
        /// Базовый конструктор BankAccount создает ФИО и баланс счета клиента.
        /// </summary>
        /// <param name="customerName">ФИО клиента.</param>
        /// <param name="balance">Баланс счета клиента.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        /// <summary>
        /// Свойство CustomerName получает ФИО клиента.
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }
        /// <summary>
        /// Свойство Balance получает значение баланса клиента.
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Метод Debit, который вызывается, когда денежные средства снимаются со счета.
        /// </summary>
        /// <param name="amount">Сумма денежных средств, которые требуется снять.</param>
        /// <exception cref="ArgumentOutOfRangeException">Исключение возникающее при отрицательном значении суммы и/или превышении баланса.</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }
        /// <summary>
        /// Метод Credit, который вызывается, когда денежные средства поступают на счет.
        /// </summary>
        /// <param name="amount">Сумма денежных средств, которые требуется начислить.</param>
        /// <exception cref="ArgumentOutOfRangeException">Исключение возникающее при отрицательном значении суммы.</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }
        /// <summary>
        /// Главная функция Main.
        /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}
