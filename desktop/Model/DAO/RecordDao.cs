﻿using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;

namespace DicomLoader.Model.DAO
{
    class RecordDao : IRecord
    {
        private static readonly string s_connectionString = @"Data Source=.\tmp.db;";

        public RecordDao()
        {
            if (!File.Exists(s_connectionString))
            {
                using SQLiteConnection db = new SQLiteConnection(s_connectionString);
                using SQLiteCommand Command = db.CreateCommand();
                db.Open();
                Command.CommandText = "CREATE TABLE IF NOT EXISTS Records ( " +
                    "RecordId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                    "Email VARCHAR(250) NOT NULL," +
                    "PatientName VARCHAR(250) NOT NULL," +
                    "Image TEXT NOT NULL," +
                    "Description TEXT," +
                    "RecordDate  DATE);";
                Command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Add record to local DB
        /// </summary>
        /// <param name="Record">Record to be added to local db</param>
        /// <returns>
        ///     Task<Record> - DB operation was successfull
        ///     null - DB operation was unsuccessfull
        /// </returns>
        public async Task<Record> AddRecord(Record Record)
        {
            if(Record == null)
            {
                return null;
            }
            int AffectedRows = 0;
            await Task.Run(() =>
            {
                using (SQLiteConnection db = new SQLiteConnection(s_connectionString))
                using (SQLiteCommand Command = db.CreateCommand())
                {
                    db.Open();
                    Command.CommandText =
                        "INSERT INTO Records" +
                        "(Email,PatientName,Image,Description,RecordDate) " +
                        "VALUES" +
                        "(@Email, @PatientName, @Image, @Description, @RecordDate);";

                    Command.Parameters.Add("Email", DbType.String).Value = Record.Email;
                    Command.Parameters.Add("PatientName", DbType.String).Value = Record.PatientName;
                    Command.Parameters.Add("Image", DbType.String).Value = Record.Image;
                    Command.Parameters.Add("Description", DbType.String).Value = Record.Description;
                    Command.Parameters.Add("RecordDate", DbType.Date).Value = Record.RecordDate;

                    AffectedRows = Command.ExecuteNonQuery();
                }
            });

            return AffectedRows != 1 ? null : Record;
        }

        /// <summary>
        /// Delete record from local DB
        /// </summary>
        /// <param name="Record">Record to be deleted</param>
        /// <returns>
        ///     Task<Record> - DB operation was successfull
        ///     null - DB operation was unsuccessfull
        /// </returns>
        public async Task<Record> DeleteRecord(Record Record)
        {
            int Affectedrows = 0;
            await Task.Run(() => 
            {
                
                using (SQLiteConnection db = new SQLiteConnection(s_connectionString))
                using(SQLiteCommand Command = db.CreateCommand())
                {
                    db.Open();
                    Command.CommandText = "DELETE FROM Records WHERE RecordId = @RecordId";
                    Command.Parameters.Add("RecordId", DbType.Int32).Value = Record.RecordId;
                    Command.ExecuteNonQuery();
                }
            });
            return Affectedrows != 1 ? null : Record;
        }
        /// <summary>
        /// List the stored Records form DB
        /// </summary>
        /// <returns>
        ///     Task<IList<Record>> - DB operation was successfull
        ///     null - DB operation was unsuccessfull
        /// </returns>
        public async Task<IList<Record>> ListRecord()
        {
            IList<Record> Records = null;
            await Task.Run(() =>
            {
                using SQLiteConnection db = new SQLiteConnection(s_connectionString);
                using SQLiteCommand Command = db.CreateCommand();
                Command.CommandText = "SELECT * FROM Records";
                db.Open();
                using SQLiteDataReader reader = Command.ExecuteReader();
                Records = ReadRecordsFromReader(reader);
            });          
            return Records;         
        }
        /// <summary>
        /// Read SQLiteDatareader
        /// </summary>
        /// <param name="reader">DataReader with the information</param>
        /// <returns>
        ///     IList<Record> - Record readed from RecordReader
        ///     null - Recordreader does not containt any infomation
        /// </returns>
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
