using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dbAssignmnet.RepositoryPattern
{
    public class StudentModel
    {

        public int Id { get; set; }
        public string fullname { get; set; }
        public int Age { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string date_of_birth { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public int level { get; set; }
        public string matric_no { get; set; }
        public decimal gpa { get; set; }
        public bool is_active { get; set; }
        public TimeOnly time { get; set; }




        public override string ToString()
        {
            return $"Id: {Id}, Full Name: {fullname}, Email: {email}, Age: {Age}, matric_no: {matric_no}, GPA: {gpa}, Is Active: {is_active}, phone: {phone}, Address: {address}, Department: {department}, Level: {level},";

        }
    }
}