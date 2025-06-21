using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using System.Data.SQLite;

namespace UnicomTIC_MS.Repositories
{
    public static class DbInitializer
    {
        public static void InitializeTables()
        {
            var con = DbCon.GetConnection();

            // 1. Users-------------------------------------------------------------------
            var usersCmd = con.CreateCommand();
            usersCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL
                );";
            usersCmd.ExecuteNonQuery();

            // 2. Courses-------------------------------------------------------------------
            var courseCmd = con.CreateCommand();
            courseCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Courses (
                    CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                    CourseName TEXT NOT NULL
                );";
            courseCmd.ExecuteNonQuery();

            // 3. Subjects-------------------------------------------------------------------
            var subjectCmd = con.CreateCommand();
            subjectCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Subjects (
                    SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectName TEXT NOT NULL,
                    CourseID INTEGER,
                    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                );";
            subjectCmd.ExecuteNonQuery();

            // 4. Students-------------------------------------------------------------------
            var studentCmd = con.CreateCommand();
            studentCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Students (
                    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Age INTEGER,
                    Email TEXT,
                    NIC TEXT,
                    Gender TEXT,
                    Course TEXT,
                    Role TEXT
                );";
            studentCmd.ExecuteNonQuery();

            // 5. Lecturers-------------------------------------------------------------------
            var lecturerCmd = con.CreateCommand();
            lecturerCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Lecturers (
                    LecturerID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Email TEXT,
                    NIC TEXT,
                    Gender TEXT
                );";
            lecturerCmd.ExecuteNonQuery();

            // 6. Sections-------------------------------------------------------------------
            var sectionCmd = con.CreateCommand();
            sectionCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Sections (
                    SectionID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SectionName TEXT NOT NULL
                );";
            sectionCmd.ExecuteNonQuery();

            // 7. Exams-------------------------------------------------------------------
            var examCmd = con.CreateCommand();
            examCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Exams (
                    ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ExamName TEXT NOT NULL,
                    SubjectID INTEGER,
                    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                );";
            examCmd.ExecuteNonQuery();

            // 8. Marks-------------------------------------------------------------------
            var markCmd = con.CreateCommand();
            markCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Marks (
                    MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER,
                    ExamID INTEGER,
                    Score INTEGER,
                    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
                );";
            markCmd.ExecuteNonQuery();

            // 9. Rooms-------------------------------------------------------------------
            var roomCmd = con.CreateCommand();
            roomCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Rooms (
                    RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomName TEXT NOT NULL,
                    RoomType TEXT NOT NULL
                );";
            roomCmd.ExecuteNonQuery();

            // 10. Timetables-------------------------------------------------------------------
            var timetableCmd = con.CreateCommand();
            timetableCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Timetables (
                    TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectID INTEGER,
                    TimeSlot TEXT,
                    RoomID INTEGER,
                    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
                    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
                );";
            timetableCmd.ExecuteNonQuery();

            // 11. StudentCourse-------------------------------------------------------------------
            var scCmd = con.CreateCommand();
            scCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS StudentCourse (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER,
                    CourseID INTEGER,
                    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                );";
            scCmd.ExecuteNonQuery();

            // 12. StudentExam-------------------------------------------------------------------
            var seCmd = con.CreateCommand();
            seCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS StudentExam (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER,
                    ExamID INTEGER,
                    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
                );";
            seCmd.ExecuteNonQuery();

            // 13. StudentSection-------------------------------------------------------------------
            var ssCmd = con.CreateCommand();
            ssCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS StudentSection (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER,
                    SectionID INTEGER,
                    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                    FOREIGN KEY (SectionID) REFERENCES Sections(SectionID)
                );";
            ssCmd.ExecuteNonQuery();

            // 14. StudentLecturer-------------------------------------------------------------------
            var slCmd = con.CreateCommand();
            slCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS StudentLecturer (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER,
                    LecturerID INTEGER,
                    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                    FOREIGN KEY (LecturerID) REFERENCES Lecturers(LecturerID)
                );";
            slCmd.ExecuteNonQuery();

            con.Close(); 
        }
    }
}
