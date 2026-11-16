using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Models.DTOs.MembersDTOs;
using System;

namespace FitZone.UI
{
    public class ClientMenu
    {
        private readonly IMemberService _memberService;
        private readonly IBookingService _bookingService;

        public ClientMenu(IMemberService memberService, IBookingService bookingService)
        {
            _memberService = memberService;
            _bookingService = bookingService;
        }

        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== FITZONE: CLIENT MENU ===");
                Console.WriteLine("1. View all members");
                Console.WriteLine("2. Register new member");
                Console.WriteLine("3. Book a workout session");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("\nSelect an option: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var members = _memberService.GetAllMembers();
                            Console.WriteLine("--- Members List ---");
                            foreach (var m in members)
                            {
                                Console.WriteLine(m);
                            }
                            break;

                        case "2":
                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();

                            var newMember = new CreateMemberDTO
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                MembershipTypeId = 1
                            };

                            _memberService.AddMember(newMember);
                            Console.WriteLine("Member successfully registered!");
                            break;

                        case "3":
                            Console.Write("Enter Member ID: ");
                            int memberId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Session ID: ");
                            int sessionId = int.Parse(Console.ReadLine());

                            _bookingService.BookSession(memberId, sessionId);
                            Console.WriteLine("Successfully booked the session!");
                            break;

                        case "0":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}