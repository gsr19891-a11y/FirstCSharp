using Step.Domain.Interfaces;
using Step.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;

namespace Step.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {


        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }




        public ICollection<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            const string query = "SELECT * FROM Students";

            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(query, connection);

            connection.Open();

            using var reader = command.ExecuteReader(); //when read!!

            //using var reader = command.ExecuteNonQuery(); - when add or update or delete!!
            //using var reader = command.ExecuteScalar(); - when need function!!

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Age = reader.GetInt32(reader.GetOrdinal("Age")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Grade = reader.GetInt32(reader.GetOrdinal("Grade")).ToString(),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")), 
                    StatusIsActive = reader.GetBoolean(reader.GetOrdinal("StatusIsActive")) 
                });
            }

            return students;
        }



        public Student? GetById(int id)
        {
            const string query = "SELECT * FROM Students WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            connection.Open();


            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Student
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Age = reader.GetInt32(reader.GetOrdinal("Age")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Grade = reader.GetInt32(reader.GetOrdinal("Grade")).ToString(),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                    StatusIsActive = reader.GetBoolean(reader.GetOrdinal("StatusIsActive"))
                };

            }
            return default;

        }


















    }
}
