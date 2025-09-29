﻿using Microsoft.Data.SqlClient;
using Dapper;

namespace Project2.Models
{
    public class UserModel
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

 }
