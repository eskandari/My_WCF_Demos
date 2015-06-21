using System;
using System.Collections.Generic;
using System.Text;
using AccountNumberClient.localhost;
using System.ServiceModel;
using Extensions;

namespace AccountNumberClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the accountNumber lookup program!");
            Console.WriteLine("Enter a accountNumber in the following format: #####-#######");
            Console.WriteLine("Or enter 'quit' to close the program.\n");
            Console.WriteLine("Some sample account numbers: 12341-1234561, 12342-1234562, 12343-1234563\n");

            AccountNumberServiceClient client = new AccountNumberServiceClient();

            string accountNumber = Console.ReadLine();

            while (!accountNumber.Equals("quit"))
            {
                try
                {
                    Console.WriteLine(client.Lookup(accountNumber));
                }
				catch (FaultException<BadAccountNumberSubmission> fe)
                {
                    Console.WriteLine(fe.Message);
                }

				catch (FaultException fe)
                {
                    Console.WriteLine(fe.Message);
                }
				catch(Exception ex)
				{
					 Console.WriteLine(ex.Message);
				}
                accountNumber = Console.ReadLine();
            }
        }
    }
}
