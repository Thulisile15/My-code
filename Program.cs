using BankingAppSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount("Alice", 1000);
            BankAccount acc2 = new BankAccount("Bob", 500);
            ATMInvoker atm = new ATMInvoker();

            ATMSubject atmSystem = new ATMSubject();
            atmSystem.Attach(new BankServerObserver());
            atmSystem.Attach(new LoggerObserver());
            atmSystem.Attach(new SecurityObserver());

            bool continueUsingATM = true;

            while (continueUsingATM)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to the ATM System ===");
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Transfer Funds");
                Console.WriteLine("5. Exit");
                Console.Write("Please select an option (1-5): ");

                string choice = Console.ReadLine();
                ICommand command = null;

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter amount to withdraw: R");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        command = new WithdrawCommand(acc1, withdrawAmount);
                        command = new SMSNotificationDecorator(new TwoFactorAuthDecorator(command));
                        command = AskForReceipt(command);
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: R");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        command = new DepositCommand(acc1, depositAmount);
                        command = new SMSNotificationDecorator(command);
                        command = AskForReceipt(command);
                        break;

                    case "3":
                        command = new CheckBalanceCommand(acc1);
                        break;

                    case "4":
                        Console.Write("Enter amount to transfer to Bob: R");
                        decimal transferAmount = decimal.Parse(Console.ReadLine());
                        command = new TransferFundsCommand(acc1, acc2, transferAmount);
                        command = new SMSNotificationDecorator(new TwoFactorAuthDecorator(command));
                        command = AskForReceipt(command);
                        break;

                    case "5":
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadLine();
                        continue;
                }

                atmSystem.Notify("Transaction started...");
                atm.SetCommand(command);
                atm.ExecuteCommand();
                atmSystem.Notify("Transaction completed.");

                Console.Write("\nDo you want to perform another transaction? (y/n): ");
                string again = Console.ReadLine().ToLower();
                if (again != "y" && again != "yes")
                {
                    continueUsingATM = false;
                    Console.WriteLine("Thank you for using the ATM. Goodbye!");
                }
            }
        }

        // Helper method to ask if user wants a receipt
        static ICommand AskForReceipt(ICommand command)
        {
            Console.Write("Do you want a receipt? (y/n): ");
            string input = Console.ReadLine().ToLower();

            if (input == "y" || input == "yes")
            {
                return new ReceiptDecorator(command);
            }

            return command;
        }
    }



}



