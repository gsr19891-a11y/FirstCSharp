using LibrarySystem.Core.Enums;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {

        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Borrows.txt");

        public List<BorrowRecord> GetAll()
        {
            var BorrowRecords = new List<BorrowRecord>();
            var lines = File.ReadAllLines(_path);

            foreach (var line in lines) {

                var parts = line.Split('|').Select(x => x.Trim()).ToArray();

                string BorrowId = parts[0];
                int UserId = int.Parse(parts[1]);
                string Isbn = parts[2];
                DateTime ReturnDate = DateTime.Parse(parts[3]);
                BorrowStatus Status = (BorrowStatus)Enum.Parse(typeof(BorrowStatus), parts[4]);
       

                BorrowRecords.Add(new BorrowRecord(BorrowId, UserId, Isbn, ReturnDate, Status));

            }

            return BorrowRecords;
        }




        public List<BorrowRecord> GetByUserId(int userId)
        {
            var allRecords = GetAll();
            return allRecords.Where(r => r.UserId == userId).ToList();
        }


        public BorrowRecord GetByUserId(string userId) {
        var allRecords = GetAll();
            return allRecords.FirstOrDefault(r => r.UserId.ToString() == userId);
        }



        public void Add(BorrowRecord record)
        {
            var records = GetAll();
            records.Add(record);
            SaveAll(records);
        }


        public void Update(BorrowRecord record)
        {
            var records = GetAll();
            var existingRecord = records.FirstOrDefault(r => r.BorrowId.Equals(record.BorrowId, StringComparison.OrdinalIgnoreCase));
            if (existingRecord != null)
            {
                existingRecord.UserId = record.UserId;
                existingRecord.Isbn = record.Isbn;
                existingRecord.ReturnDate = record.ReturnDate;
                existingRecord.Status = record.Status;
                SaveAll(records);
            }
        }


        public BorrowRecord GetById(string borrowId)
        {
            return GetAll().FirstOrDefault(r => r.BorrowId.Equals(borrowId, StringComparison.OrdinalIgnoreCase));
        }


        private void SaveAll(List<BorrowRecord> records)
        {
            var lines = records.Select(r => $"{r.BorrowId} | {r.UserId} | {r.Isbn} | {r.ReturnDate:yyyy-MM-dd} | {r.Status}");
            File.WriteAllLines(_path, lines);
        }


    }
}
