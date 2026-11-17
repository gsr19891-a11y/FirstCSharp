
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
            Console.Write("Enter your Member ID (0 if you are new): ");

            int.TryParse(Console.ReadLine(), out int memberId);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("=== FITZONE CLIENT MENU ===");
                Console.WriteLine($"Member ID: {memberId}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Register new member");
                Console.WriteLine("2. View available workout sessions");
                Console.WriteLine("3. Book a workout session");
                Console.WriteLine("4. View my bookings");
                Console.WriteLine("5. Cancel booking");
                Console.WriteLine("6. View my profile");
                Console.WriteLine("0. Back to Main Menu");

                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            memberId = RegisterMember();
                            break;

                        case "2":
                            ViewAvailableSessions();
                            break;

                        case "3":
                            if (CheckMember(memberId))
                                BookSession(memberId);
                            break;

                        case "4":
                            if (CheckMember(memberId))
                                ViewMyBookings(memberId);
                            break;

                        case "5":
                            if (CheckMember(memberId))
                                CancelBooking(memberId);
                            break;

                        case "6":
                            if (CheckMember(memberId))
                                ViewProfile(memberId);
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

        private int RegisterMember()
        {
            Console.Clear();

            Console.WriteLine("=== MEMBER REGISTRATION ===");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            var member = new CreateMemberDTO
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                MembershipTypeId = 1
            };

            int newMemberId = _memberService.AddMember(member);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRegistration successful!");
            Console.WriteLine($"Your Member ID: {newMemberId}");
            Console.ResetColor();

            return newMemberId;
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
    }
}
