﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace DicomLoader.Model.DAO
{
    class RecordDao : IRecord
    {
        private static readonly string s_connectionString = @"Data Source=..\..\DB\tmp.db;";
        public async Task<Record> AddRecord(Record Record)
        {
            if(Record == null)
            {
                return null;
            }

            using (SQLiteConnection db = new SQLiteConnection(s_connectionString))
            using(SQLiteCommand Command = db.CreateCommand())
            {
                Command.CommandText = "INSERT INTO RECORDS (Email,PatientName,Image,Description,RecordDate) " +
                    "VALUES(@Email, @PatintName, @Image, @Description, @RecordDate);";

                Command.Parameters.Add("Email", DbType.String).Value = Record.Email;
                Command.Parameters.Add("PatientName", DbType.String).Value = Record.PatientName;
                Command.Parameters.Add("Image", DbType.String).Value = Record.Image;
                Command.Parameters.Add("Description", DbType.String).Value = Record.Description;
                Command.Parameters.Add("RecordDate", DbType.Date).Value = Record.RecordDate;

                int affectedRows = Command.ExecuteNonQuery();
                if (affectedRows != 1) return null;
            }
            return Record;
        }

        public IList<Record> ListRecord()
        {
            IList<Record> Records = null;
            using (SQLiteConnection db = new SQLiteConnection(s_connectionString)) 
            using(SQLiteCommand Command = db.CreateCommand())
            {
                Command.CommandText = "SELECT * FROM RECORDS";
                db.Open();

                using (SQLiteDataReader reader = Command.ExecuteReader())
                {
                    Records = ReadRecordsFromReader(reader);
                }
            }
            return Records;
            
        }

        private IList<Record> ReadRecordsFromReader(SQLiteDataReader reader)
        {
            List<Record> Records = new List<Record>();
            while (reader.Read())
            {
                Record Record = new Record
                {
                    RecordId = reader.GetInt32(reader.GetOrdinal("RecordId")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                    Image = reader.GetString(reader.GetOrdinal("Image")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    RecordDate = reader.GetDateTime(reader.GetOrdinal("RecordDate"))
                };

                Records.Add(Record);
            }
            return Records;
        }
    }
}
