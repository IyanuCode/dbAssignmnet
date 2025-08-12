using System.IO.Pipes;
using System.Net.Mail;
using Npgsql;

namespace dbAssignmnet.RepositoryPattern;

public class Students : IStudents
{
    /*
        Assignment
        Read on Regexs
        DateTimeStyles Enum fields
    */

    public string CreateDB(string TableName)
    {
        string sql =
            $@"
                CREATE TABLE IF NOT EXISTS {TableName} (
                id SERIAL PRIMARY KEY,
                fullname VARCHAR(100),
                email VARCHAR(100),
                age INT,
                gender VARCHAR(10),
                date_of_birth DATE,
                phone VARCHAR(15),
                address TEXT,
                department VARCHAR(100),
                level INT,
                matric_no VARCHAR(50),
                gpa DECIMAL(3,2),
                is_active BOOLEAN DEFAULT TRUE,
                created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
            )";
        var conn = Configuration.ConMethod();
        var cmd = new NpgsqlCommand(sql, conn);
        cmd.ExecuteNonQuery(); //Executes the command without expecting any result (i.e., it’s not a SELECT).
        conn.Close(); //closes the connection inorder to free the memory

        string output = $"{TableName} Succesfully created";
        return output;
    }

    public string Delete()
    {
        string? tableName;
        string? Id;
        int parsedId;

        while (true)
        {
            Console.WriteLine("Enter the Table Name");
            tableName = Console.ReadLine();

            if (string.IsNullOrEmpty(tableName) || tableName.Any(char.IsDigit) || tableName.Length < 3)
            {
                Console.WriteLine("Table Name cannot be empty, must be letters and should not be less than 3");
            }
            else
            {
                break;
            }
        }

         //Id
        while (true)
        {
            Console.Write("Enter Id of Record to be deleted: ");
            Id = Console.ReadLine();
            if (int.TryParse(Id, out parsedId))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Id: Id must be a number");
            }
        }


        string deleteSql = $@"DELETE FROM ""{tableName}"" WHERE Id = @Id";
        var conn = Configuration.ConMethod();
        //conn.Open();
        var cmd = new NpgsqlCommand(deleteSql, conn);
        cmd.Parameters.AddWithValue("Id", parsedId);
        cmd.ExecuteNonQuery();
        conn.Close();

        string output = "Record deleted successfully";
        return output;
    }

    public List<StudentModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public string InsertValues()
    {
        string? fullname;
        string? email;
        string? age;
        int parsedAge;
        string? gender;
        string? inputDOB;
        DateTime dateOfBirth;
        //int parsedPhoneNo;
        string? phone;
        string? address;
        string? department;
        string? level;
        int parsedLevel;
        string? matricNo;
        string? gpa;
        decimal parsedGpa;
        bool isActive;
        //string? input;
        string? tableName;

        //TABLENAME
        while (true)
        {
            Console.WriteLine("Enter the Table Name");
            tableName = Console.ReadLine();

            if (
                string.IsNullOrEmpty(tableName)
                || tableName.Any(char.IsDigit)
                || tableName.Length < 3
            )
            {
                Console.WriteLine(
                    "Table Name cannot be empty, must be letters and should not be less than 3"
                );
            }
            else
            {
                break;
            }
        }

        //FULLNAME
        while (true)
        {
            Console.Write("FullName: ");
            fullname = Console.ReadLine();
            if (string.IsNullOrEmpty(fullname) || fullname.Any(char.IsDigit) || fullname.Length < 3)
            {
                Console.WriteLine(
                    "Name cannot be empty, must be letters and should not be less than 3"
                );
            }
            else
            {
                break;
            }
        }
        //EMAIL
        while (true)
        {
            Console.Write("Email: ");
            email = Console.ReadLine();
            if (string.IsNullOrEmpty(email) || email.Length < 9)
            {
                Console.WriteLine("Email cannot be empty and shouldn't be less than 9 characters");
            }
            else
            {
                break;
            }
        }
        //AGE
        while (true)
        {
            Console.Write("Age: ");
            age = Console.ReadLine();
            //Convert.ToInt32(age);
            if (int.TryParse(age, out parsedAge))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Age: Age must be a number");
            }
        }

        //GENDER
        while (true)
        {
            Console.WriteLine("Enter your Gender in the Format: 'M' or 'F' ");
            Console.Write("Gender: ");
            gender = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(gender) || gender.Any(char.IsDigit) || gender.Length > 1)
            {
                Console.WriteLine("Invalid Input, follow the instruction above");
            }
            else
            {
                break;
            }
        }
        //DATE OF BIRTH
        while (true)
        {
            Console.Write("Date of birth (yyyy-MM-dd): ");
            inputDOB = Console.ReadLine();

            if (
                DateTime.TryParseExact(
                    inputDOB,
                    "yyyy-MM-dd",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out dateOfBirth
                )
            )
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Date: Please enter a valid date in format yyyy-MM-dd.");
            }
        }
        //PHONE
        while (true)
        {
            Console.Write("Phone: ");
            phone = Console.ReadLine();

            // Check if the phone is exactly 11 digits and contains only digits
            if (phone.Length == 11 && phone.All(char.IsDigit))
            {
                break; // Valid phone number
            }
            else
            {
                Console.WriteLine("Invalid Phone No: input must be exactly 11 numeric digits.");
            }
        }

        //ADDRESS
        while (true)
        {
            Console.Write("address: ");
            address = Console.ReadLine();
            if (string.IsNullOrEmpty(address) || address.Length < 2)
            {
                Console.WriteLine("Address cannot be empty and should be full word at least");
            }
            else
            {
                break;
            }
        }

        //DEPARTMENT
        while (true)
        {
            Console.Write("Department: ");
            department = Console.ReadLine();
            if (
                string.IsNullOrEmpty(department)
                || department.Any(char.IsDigit)
                || department.Length < 3
            )
            {
                Console.WriteLine(
                    "Department cannot be empty, must be letters and should not be less than 3"
                );
            }
            else
            {
                break;
            }
        }
        //LEVEL
        while (true)
        {
            Console.Write("Level: ");
            level = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(level) || level.Length < 3 || !level.Any(char.IsDigit))
            {
                Console.WriteLine("Level can only be 3 characters and should be number");
            }
            else if (int.TryParse(level, out parsedLevel))
            {
                break;
            }
            else if (
                parsedLevel != 100
                || parsedLevel != 200
                || parsedLevel != 300
                || parsedLevel != 400
                || parsedLevel != 500
            )
            {
                Console.WriteLine(
                    "Invalid! Level cannot be less than 100 and shouldn't be greater than 500"
                );
            }
            else
            {
                Console.WriteLine("Invalid - Level must be a number");
            }
        }
        //MATRIC NO
        while (true)
        {
            Console.Write("Matric No: ");
            matricNo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(matricNo))
            {
                Console.WriteLine("Matric No cannot be empty.");
            }
            else if (matricNo.Length != 5)
            {
                Console.WriteLine("Matric No must be exactly 5 characters.");
            }
            else
            {
                break;
            }
        }

        //GPA
        while (true)
        {
            Console.Write("GPA: ");
            gpa = Console.ReadLine();
            if (decimal.TryParse(gpa, out parsedGpa) && parsedGpa >= 1 && parsedGpa <= 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid GPA! GPA must be in the format 2.2");
            }
        }
        //isActive
        while (true)
        {
            Console.WriteLine("If active, press 1; else press 0.");
            var input = Console.ReadKey();
            Console.WriteLine();

            if (input.KeyChar == '1')
            {
                isActive = true;
                break;
            }
            else if (input.KeyChar == '0')
            {
                isActive = false;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, please press 1 (active) or 0 (inactive).");
            }
        }

        // Insert SQL statement with dynamic table name using string interpolation
        string insertSql =
            $@"INSERT INTO ""{tableName}"" (
                fullname, email, age, gender, date_of_birth, phone, address, department, level, matric_no, gpa, is_active
            ) VALUES 
                (@fullname, @email, @age, @gender, @date_of_birth, @phone, @address, @department, @level, @matric_no, @gpa, @is_active)";

        using (var conn = Configuration.ConMethod())
        {
            //conn.Open();
            using (var cmd = new NpgsqlCommand(insertSql, conn))
            {
                cmd.Parameters.AddWithValue("fullname", fullname);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("age", parsedAge);
                cmd.Parameters.AddWithValue("gender", gender);
                cmd.Parameters.AddWithValue("date_of_birth", dateOfBirth);
                cmd.Parameters.AddWithValue("phone", phone);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("department", department);
                cmd.Parameters.AddWithValue("level", parsedLevel);
                cmd.Parameters.AddWithValue("matric_no", matricNo);
                cmd.Parameters.AddWithValue("gpa", parsedGpa);
                cmd.Parameters.AddWithValue("is_active", isActive);

                cmd.ExecuteNonQuery();
            }
        }

        string output = "Data inserted successfully!";
        return output;
    }

    public string Update()
    {
        string? Id;
        int parsedId;
        string? fullname;
        string? email;
        string? age;
        int parsedAge;
        string? gender;
        string? inputDOB;
        DateTime dateOfBirth;
        string? phone;
        string? address;
        string? department;
        string? level;
        int parsedLevel;
        string? matricNo;
        string? gpa;
        decimal parsedGpa;
        bool isActive;
        string? tableName;

        //TABLENAME
        while (true)
        {
            Console.WriteLine("Enter the Table Name");
            tableName = Console.ReadLine();

            if (string.IsNullOrEmpty(tableName) || tableName.Any(char.IsDigit) || tableName.Length < 3)
            {
                Console.WriteLine("Table Name cannot be empty, must be letters and should not be less than 3");
            }
            else
            {
                break;
            }
        }

        //Id
        while (true)
        {
            Console.Write("Id: ");
            Id = Console.ReadLine();
            //Convert.ToInt32(age);
            if (int.TryParse(Id, out parsedId))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Id: Id must be a number");
            }
        }

        //FULLNAME
        while (true)
        {
            Console.Write("FullName: ");
            fullname = Console.ReadLine();
            if (string.IsNullOrEmpty(fullname) || fullname.Any(char.IsDigit) || fullname.Length < 3)
            {
                Console.WriteLine("Name cannot be empty, must be letters and should not be less than 3");
            }
            else
            {
                break;
            }
        }
        //EMAIL
        while (true)
        {
            Console.Write("Email: ");
            email = Console.ReadLine();
            if (string.IsNullOrEmpty(email) || email.Length < 9)
            {
                Console.WriteLine("Email cannot be empty and shouldn't be less than 9 characters");
            }
            else
            {
                break;
            }
        }
        //AGE
        while (true)
        {
            Console.Write("Age: ");
            age = Console.ReadLine();
            //Convert.ToInt32(age);
            if (int.TryParse(age, out parsedAge))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Age: Age must be a number");
            }
        }

        //GENDER
        while (true)
        {
            Console.WriteLine("Enter your Gender in the Format: 'M' or 'F' ");
            Console.Write("Gender: ");
            gender = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(gender) || gender.Any(char.IsDigit) || gender.Length > 1)
            {
                Console.WriteLine("Invalid Input, follow the instruction above");
            }
            else
            {
                break;
            }
        }

        //DATE OF BIRTH
        while (true)
        {
            Console.Write("Date of birth (yyyy-MM-dd): ");
            inputDOB = Console.ReadLine();

            if (DateTime.TryParseExact(inputDOB, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateOfBirth))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Date: Please enter a valid date in format yyyy-MM-dd.");
            }
        }

        //PHONE
        while (true)
        {
            Console.Write("Phone: ");
            phone = Console.ReadLine();

            // Check if the phone is exactly 11 digits and contains only digits
            if (phone.Length == 11 && phone.All(char.IsDigit))
            {
                break; // Valid phone number
            }
            else
            {
                Console.WriteLine("Invalid Phone No: input must be exactly 11 numeric digits.");
            }
        }

        //ADDRESS
        while (true)
        {
            Console.Write("address: ");
            address = Console.ReadLine();
            if (string.IsNullOrEmpty(address) || address.Length < 2)
            {
                Console.WriteLine("Address cannot be empty and should be full word at least");
            }
            else
            {
                break;
            }
        }

        //DEPARTMENT
        while (true)
        {
            Console.Write("Department: ");
            department = Console.ReadLine();
            if (string.IsNullOrEmpty(department) || department.Any(char.IsDigit) || department.Length < 3)
            {
                Console.WriteLine("Department cannot be empty, must be letters and should not be less than 3");
            }
            else
            {
                break;
            }
        }
        //LEVEL
        while (true)
        {
            Console.Write("Level: ");
            level = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(level) || level.Length < 3 || !level.Any(char.IsDigit))
            {
                Console.WriteLine("Level can only be 3 characters and should be number");
            }
            else if (int.TryParse(level, out parsedLevel))
            {
                break;
            }
            else if (parsedLevel != 100 || parsedLevel != 200 || parsedLevel != 300 || parsedLevel != 400 || parsedLevel != 500)
            {
                Console.WriteLine("Invalid! Level cannot be less than 100 and shouldn't be greater than 500");
            }
            else
            {
                Console.WriteLine("Invalid - Level must be a number");
            }
        }

        //MATRIC NO
        while (true)
        {
            Console.Write("Matric No: ");
            matricNo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(matricNo))
            {
                Console.WriteLine("Matric No cannot be empty.");
            }
            else if (matricNo.Length != 5)
            {
                Console.WriteLine("Matric No must be exactly 5 characters.");
            }
            else
            {
                break;
            }
        }

        //GPA
        while (true)
        {
            Console.Write("GPA: ");
            gpa = Console.ReadLine();
            if (decimal.TryParse(gpa, out parsedGpa) && parsedGpa >= 1 && parsedGpa <= 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid GPA! GPA must be in the format 2.2");
            }
        }
        //isActive
        while (true)
        {
            Console.WriteLine("If active, press 1; else press 0.");
            var input = Console.ReadKey();
            Console.WriteLine();

            if (input.KeyChar == '1')
            {
                isActive = true;
                break;
            }
            else if (input.KeyChar == '0')
            {
                isActive = false;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, please press 1 (active) or 0 (inactive).");
            }
        }
        string updateSql =
        $@"UPDATE ""{tableName}"" SET fullname=@fullname, email=@email, age=@age, gender=@gender, date_of_birth=@date_of_birth, phone=@phone, address=@address, department=@department, level=@level, matric_no=@matric_no, gpa=@gpa, is_active=@is_active WHERE Id = @Id";
        var conn = Configuration.ConMethod();
        var cmd = new NpgsqlCommand(updateSql, conn);
        // conn.Open();
        cmd.Parameters.AddWithValue("fullname", fullname);
        cmd.Parameters.AddWithValue("Id", parsedId);
        cmd.Parameters.AddWithValue("email", email);
        cmd.Parameters.AddWithValue("age", parsedAge);
        cmd.Parameters.AddWithValue("gender", gender);
        cmd.Parameters.AddWithValue("date_of_birth", dateOfBirth);
        cmd.Parameters.AddWithValue("phone", phone);
        cmd.Parameters.AddWithValue("address", address);
        cmd.Parameters.AddWithValue("department", department);
        cmd.Parameters.AddWithValue("level", parsedLevel);
        cmd.Parameters.AddWithValue("matric_no", matricNo);
        cmd.Parameters.AddWithValue("gpa", parsedGpa);
        cmd.Parameters.AddWithValue("is_active", isActive);

        cmd.ExecuteNonQuery();
        conn.Close();

        string output = "Data inserted successfully!";
        return output;
    }


}
