using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementApp.Region
{
    public class RegionClass
    {
        #region Fields

        private int studentId;
        private string studentName;

        #endregion
             

        #region Properties

        public int StudentId 
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        #endregion


        #region Constructors
        public RegionClass()
        {
            studentId = 0;
            studentName = "Unknown";
        }

        public RegionClass(string studentName, int studentId)
        {
            this.studentId = studentId;
            this.studentName = studentName;
        }
        #endregion

       
        #region Methods
        public void DisplayRegionInfo()
        {
            try
            {
                Console.WriteLine($"Student Name: {StudentName}");
                Console.WriteLine($"Student ID: P{StudentId}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        #endregion


        #region DEBUG
        public void DebugInfo()
        {
            Console.WriteLine("Debugging RegionClass: StudentId = {0}, StudentName = {1}", studentId, studentName);
        }
        #endregion

    }
}
