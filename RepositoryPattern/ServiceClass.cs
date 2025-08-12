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
    }
}
