
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Models.DTOs.MembersDTOs;
using System.Linq;
using System;

namespace FitZone.UI
{
    public class ClientMenu
    {
        private readonly IMemberService _memberService;
        private readonly IBookingService _bookingService;
        private readonly IWorkoutSessionService _sessionService;

        public ClientMenu(
            IMemberService memberService,
            IBookingService bookingService,
            IWorkoutSessionService sessionService)
        {
            _memberService = memberService;
            _bookingService = bookingService;
            _sessionService = sessionService;
        }

        public void Show()
        {
            int memberId = 0;

            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("=== FITZONE CLIENT MENU ===");
                if (memberId > 0)
                {
                    Console.WriteLine($"Logged in | Member ID: {memberId}");
                }
                else
                {
                    Console.WriteLine("Not logged in");
                }
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Register new member");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. View available workout sessions");
                Console.WriteLine("4. Book a workout session");
                Console.WriteLine("5. View my bookings");
                Console.WriteLine("6. Cancel booking");
                Console.WriteLine("7. View my profile");
                Console.WriteLine("8. Logout");
                Console.WriteLine("0. Back to Main Menu");

                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            RegisterMember();
                            break;

                        case "2":
                            memberId = LoginMember();
                            break;

                        case "3":
                            ViewAvailableSessions();
                            break;

                        case "4":
                            if (CheckMember(memberId))
                                BookSession(memberId);
                            break;

                        case "5":
                            if (CheckMember(memberId))
                                ViewMyBookings(memberId);
                            break;

                        case "6":
                            if (CheckMember(memberId))
                                CancelBooking(memberId);
                            break;

                        case "7":
                            if (CheckMember(memberId))
                                ViewProfile(memberId);
                            break;

                        case "8":
                            if (memberId > 0)
                            {
                                memberId = 0;
                                Console.WriteLine("\nYou have successfully logged out!");
                            }
                            else
                            {
                                Console.WriteLine("\nYou are not logged in.");
                            }
                            break;

                        case "0":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("ERROR: " + ex.Message);

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("\nINNER EXCEPTION:");
                        Console.WriteLine(ex.InnerException.Message);
                    }

                    Console.ResetColor();
                }


                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private bool CheckMember(int memberId)
        {
            if (memberId <= 0)
            {
                Console.WriteLine("Please register or enter a valid Member ID.");
                return false;
            }

            _memberService.GetMemberById(memberId);

            return true;
        }


        private void RegisterMember()
        {
            Console.Clear();

            Console.WriteLine("=== MEMBER REGISTRATION ===");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? "";

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            Console.WriteLine("\n=== CHOOSE MEMBERSHIP ===");

            Console.WriteLine("1. Basic - 12 visits / 30 days");
            Console.WriteLine("2. Premium - Unlimited / 30 days");

            Console.Write("Choose membership: ");

            int.TryParse(Console.ReadLine(), out int membershipTypeId);

            var newMember = new CreateMemberDTO
            {
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                Email = email.Trim(),
                Password = password,
                MembershipTypeId = membershipTypeId
            };

            int memberId = _memberService.AddMember(newMember);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nRegistration successful!");
            Console.WriteLine($"Your Member ID: {memberId}");

            Console.ResetColor();
        }


        private void ViewAvailableSessions()
        {
            Console.Clear();

            Console.WriteLine("=== AVAILABLE WORKOUT SESSIONS ===");

            var sessions = _sessionService.GetAllActiveSessions();

            if (sessions.Count == 0)
            {
                Console.WriteLine("No available sessions.");
                return;
            }

            foreach (var session in sessions)
            {
                int booked = session.Bookings.Count(
                    b => b.Status == "Active");

                int available = session.Capacity - booked;

                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Session ID: {session.Id}");
                Console.WriteLine($"Type: {session.Type}");
                Console.WriteLine($"Trainer: {session.Trainer?.FullName}");
                Console.WriteLine($"Date: {session.StartDateTime:dd.MM.yyyy}");
                Console.WriteLine($"Time: {session.StartDateTime:HH:mm}");
                Console.WriteLine($"Duration: {session.DurationMinutes} minutes");
                Console.WriteLine($"Capacity: {session.Capacity}");
                Console.WriteLine($"Available places: {available}");
            }
        }

        private void BookSession(int memberId)
        {
            Console.Clear();

            Console.WriteLine("=== BOOK WORKOUT SESSION ===");

            ViewAvailableSessions();

            Console.Write("\nEnter Session ID: ");

            if (!int.TryParse(Console.ReadLine(), out int sessionId))
            {
                Console.WriteLine("Invalid Session ID!");
                return;
            }

            _bookingService.BookSession(memberId, sessionId);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSession booked successfully!");
            Console.ResetColor();
        }

        private void ViewMyBookings(int memberId)
        {
            Console.Clear();

            Console.WriteLine("=== MY BOOKINGS ===");

            var bookings = _bookingService.GetMyBookings(memberId)
                .Where(b => b.Status == "Active")
                .ToList();

            if (bookings.Count == 0)
            {
                Console.WriteLine("You have no active bookings.");
                return;
            }

            foreach (var booking in bookings)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Booking ID: {booking.Id}");
                Console.WriteLine($"Session ID: {booking.SessionId}");
                Console.WriteLine($"Workout: {booking.WorkoutSession.Type}");
                Console.WriteLine(
                    $"Date: {booking.WorkoutSession.StartDateTime:dd.MM.yyyy}");
                Console.WriteLine(
                    $"Time: {booking.WorkoutSession.StartDateTime:HH:mm}");
                Console.WriteLine($"Status: {booking.Status}");
            }
        }

        private void CancelBooking(int memberId)
        {
            Console.Clear();

            Console.WriteLine("=== CANCEL BOOKING ===");

            ViewMyBookings(memberId);

            Console.Write("\nEnter Booking ID: ");

            if (!int.TryParse(Console.ReadLine(), out int bookingId))
            {
                Console.WriteLine("Invalid Booking ID!");
                return;
            }

            _bookingService.CancelBooking(bookingId, memberId);

            Console.WriteLine("\nBooking cancelled successfully!");
        }

        private void ViewProfile(int memberId)
        {
            Console.Clear();

            Console.WriteLine("=== MY PROFILE ===");

            var member = _memberService.GetMemberById(memberId);

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"ID: {member.Id}");
            Console.WriteLine($"First Name: {member.FirstName}");
            Console.WriteLine($"Last Name: {member.LastName}");
            Console.WriteLine($"Membership Type ID: {member.MembershipTypeId}");
        }





        private int LoginMember()
        {
            Console.Clear();

            Console.WriteLine("=== MEMBER LOGIN ===");

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            var member = _memberService.Login(email, password);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nLogin successful!");
            Console.WriteLine($"Welcome, {member.FirstName} {member.LastName}!");
            Console.WriteLine($"Member ID: {member.Id}");

            Console.ResetColor();

            return member.Id;
        }











    }
}
