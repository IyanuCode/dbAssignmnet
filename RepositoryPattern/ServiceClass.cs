namespace dbAssignmnet.RepositoryPattern
{
    public class ServiceClass
    {
        private readonly IStudents _students;

        public ServiceClass(IStudents students)
        {
            _students = students;
        }

        public void ServiceMethod()
        {
            Students students = new();
            Console.WriteLine("Enter the table's name");
            string userInput = Console.ReadLine() ?? string.Empty;
            if (
                string.IsNullOrEmpty(userInput)
                || string.IsNullOrWhiteSpace(userInput)
                || userInput.Any(char.IsDigit)
            )
            {
                Console.WriteLine(
                    "Input Invalid, Please enter at least two character and connot be number"
                );
                return;
            }
            else
            {
                Console.WriteLine(_students.CreateDB(userInput));
            }
        }

        public void InsertInfo()
        {
            _students.InsertValues();
            Console.WriteLine("Value inserted successfully into the Table");
        }

        public void UpdateValue()
        {
            _students.Update();
            Console.WriteLine("Value Updated successfully");
        }

        public void DeleteValue()
        {
            _students.Delete();
            Console.WriteLine("Record deleted succesfully");
        }

        public void GetAllStudents()
        {
            var allStudents = _students.GetAll();
            foreach (var student in allStudents)
            {
                Console.WriteLine(student.ToString());
            }


            // THE FIRST METHOD 
            /*
            foreach (var student in allStudents)
            {
                Console.WriteLine("Id: " + student.Id);
                Console.WriteLine("Full Name: " + student.fullname);
                Console.WriteLine("Email: " + student.email);
                Console.WriteLine("Age: " + student.Age);
                Console.WriteLine("Gender: " + student.gender);
                Console.WriteLine("Date of Birth: " + student.date_of_birth);
                Console.WriteLine("Phone: " + student.phone);
                Console.WriteLine("Address: " + student.address);
                Console.WriteLine("Department: " + student.department);
                Console.WriteLine("Level: " + student.level);
                Console.WriteLine("Matric No: " + student.matric_no);
                Console.WriteLine("GPA: " + student.gpa);
                Console.WriteLine("Is Active: " + student.is_active);
                Console.WriteLine(new string('=', 40)); // separator
            }
            */

        }
        public void GetSingleId()
        {
            var studentById = _students.GetById();
            foreach (var student in studentById)
            {
                Console.WriteLine(student.ToString());
            }
        }

        
    }
}
