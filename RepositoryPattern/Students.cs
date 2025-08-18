using System.IO.Pipes;
using System.Net.Mail;
using Npgsql;


namespace dbAssignmnet.RepositoryPattern;

/*
    Module 5: Data Handling in C#
Working with files and streams
Collections and generics

*/

public class Students : IStudents
{
    //CreateDB
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

    //Delete
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

    //GetAll
    public List<StudentModel> GetAll()
    {
        string? tableName;

        while (true)
        {
            Console.WriteLine("Enter the Table Name");
            tableName = "csharpstudent";//Console.ReadLine();

            if (string.IsNullOrEmpty(tableName) || tableName.Any(char.IsDigit) || tableName.Length < 3)
            {
                Console.WriteLine("Table Name cannot be empty, must be letters and should not be less than 3");
            }
            else
            {
                break;
            }
        }

        var studentModel = new List<StudentModel>();
        string sql = $@"SELECT id, fullname, email, age, gender, date_of_birth, phone, address, department, level, matric_no, gpa, is_active FROM {tableName}";

        var conn = Configuration.ConMethod();
        //conn.Open();
        var cmd = new NpgsqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var student = new StudentModel
            {
                Id = reader.GetInt32(0),
                fullname = reader.GetString(1),
                email = reader.GetString(2),
                Age = reader.GetInt32(3),
                gender = reader.GetString(4),
                date_of_birth = reader.GetDateTime(5).ToString("dd/MM/yyyy"),
                phone = reader.GetString(6),
                address = reader.GetString(7),
                department = reader.GetString(8),
                level = reader.GetInt32(9),
                matric_no = reader.GetString(10),
                gpa = reader.GetDecimal(11),
                is_active = reader.GetBoolean(12)
            };
            studentModel.Add(student);
        }

        conn.Close();

        return studentModel;
    }

    //InsertValue
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

    //GetById
    public List<StudentModel> GetById()
    {
        string? tableName;
        int parsedId;
        string? Id;

        // ID
        while (true)
        {
            Console.Write("Enter Id of Record to be retrieved: ");
            Id = Console.ReadLine();
            if (int.TryParse(Id, out parsedId))
                break;
            Console.WriteLine("Invalid Id: Id must be a number");
        }

        // TABLE NAME
        while (true)
        {
            Console.WriteLine("Enter the Table Name");
            tableName = Console.ReadLine();

            if (string.IsNullOrEmpty(tableName) || tableName.Any(char.IsDigit) || tableName.Length < 3)
                Console.WriteLine("Table Name cannot be empty, must be letters and should not be less than 3");
            else
                break;
        }
        var conn = Configuration.ConMethod();
        var studentModel = new List<StudentModel>();

        // Correct Query: select all columns for the given ID
        string sql = $@"SELECT id, fullname, email, age, gender, date_of_birth, phone, address, department, level, matric_no, gpa, is_active FROM {tableName} WHERE Id = @Id";
        var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", parsedId);

        var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            var student = new StudentModel
            {
                Id = reader.GetInt32(0),
                fullname = reader.GetString(1),
                email = reader.GetString(2),
                Age = reader.GetInt32(3),
                gender = reader.GetString(4),
                date_of_birth = reader.GetDateTime(5).ToString("dd/MM/yyyy"),
                phone = reader.GetString(6),
                address = reader.GetString(7),
                department = reader.GetString(8),
                level = reader.GetInt32(9),
                matric_no = reader.GetString(10),
                gpa = reader.GetDecimal(11),
                is_active = reader.GetBoolean(12)
            };
            studentModel.Add(student);
        }
        else
        {
            Console.WriteLine("ID does not exist in the database.");
        }
        reader.Close();
        conn.Close();
        return studentModel;
    }

    //Update
    public string Update()
    {
        string? tableName;
        int parsedId = 0;

        // Ask for table name
        while (true)
        {
            Console.WriteLine("Enter the Table Name");
            tableName = Console.ReadLine();

            if (string.IsNullOrEmpty(tableName) || tableName.Any(char.IsDigit) || tableName.Length < 3)
            {
                Console.WriteLine("Table Name cannot be empty, must be letters and should not be less than 3");
            }
            else break;
        }

        // Ask for Id
        while (true)
        {
            Console.Write("Enter Id of Record to be updated: ");
            string? Id = Console.ReadLine();
            if (int.TryParse(Id, out parsedId))
                break;
            else
                Console.WriteLine("Invalid Id: Id must be a number");
        }

        // Show Menu
        Console.WriteLine("Select the field you want to update:");
        Console.WriteLine("Press 1 to Update Fullname\nPress 2 to Update Email\nPress 3 to Update Age\nPress 4 to Update Gender\nPress 5 to Update Date of Birth\nPress 6 to Update Phone\nPress 7 to Update Address\nPress 8 to Update Department\nPress 9 to Update Level\nPress 10 to Update Matric No\nPress 11 to Update GPA\nPress 12 to Update Is Active\nPress 0 to Exit");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                return UpdateFullname(tableName, parsedId);
            case "2":
                return UpdateEmail(tableName, parsedId);
            case "3":
                return UpdateAge(tableName, parsedId);
            case "4":
                return UpdateGender(tableName, parsedId);
            case "5":
                return UpdateDateOfBirth(tableName, parsedId);
            case "6":
                return UpdatePhone(tableName, parsedId);
            case "7":
                return UpdateAddress(tableName, parsedId);
            case "8":
                return UpdateDepartment(tableName, parsedId);
            case "9":
                return UpdateLevel(tableName, parsedId);
            case "10":
                return UpdateMatricNo(tableName, parsedId);
            case "11":
                return UpdateGPA(tableName, parsedId);
            case "12":
                return UpdateIsActive(tableName, parsedId);
            case "0": return "Update cancelled.";
            default: return "Invalid option!";
        }
    }



    //UpdateFullName
    public string UpdateFullname(string tableName, int id)
    {
        string? fullname;
        while (true)
        {
            Console.Write("Enter the new FullName: ");
            fullname = Console.ReadLine();
            if (string.IsNullOrEmpty(fullname) || fullname.Any(char.IsDigit) || fullname.Length < 3)
                Console.WriteLine("Name cannot be empty, must be letters and should not be less than 3");
            else break;
        }

        string updateSql = $@"UPDATE ""{tableName}"" SET fullname=@fullname WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("fullname", fullname);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();

        string? output = "Fullname updated successfully";
        return output;
    }

    //UpdateEmail
    public string UpdateEmail(string tableName, int id)
    {
        string? email;
        while (true)
        {
            Console.Write("Enter the new Email: ");
            email = Console.ReadLine();
            if (string.IsNullOrEmpty(email) || email.Length < 9)
                Console.WriteLine("Email cannot be empty and shouldn't be less than 9 characters");
            else break;
        }
        string updateSql = $@"UPDATE ""{tableName}"" SET email=@email WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("email", email);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();

        string? output = "Email updated successfully";
        return output;


    }

    //UpdateAge
    public string UpdateAge(string tableName, int id)
    {
        int parsedAge;
        while (true)
        {
            Console.Write("Enter the new Age: ");
            string? age = Console.ReadLine();
            if (int.TryParse(age, out parsedAge))
                break;
            else
                Console.WriteLine("Invalid Age: Age must be a number");
        }
        string updateSql = $@"UPDATE ""{tableName}"" SET age=@age WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("age", parsedAge);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Age updated successfully";
        return output;



    }

    //UpdateGender
    public string UpdateGender(string tableName, int id)
    {
        string? gender;
        while (true)
        {
            Console.Write("Enter Gender (M/F): ");
            gender = Console.ReadLine()?.ToUpper();
            if (string.IsNullOrEmpty(gender) || gender.Any(char.IsDigit) || gender.Length > 1)
                Console.WriteLine("Invalid Input, please enter M or F");
            else break;
        }
        string updateSql = $@"UPDATE ""{tableName}"" SET gender=@gender WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("gender", gender);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Gender Updated successfully";
        return output;


    }

    //UpdateDateOfBirth
    public string UpdateDateOfBirth(string tableName, int id)
    {
        DateTime dob;
        while (true)
        {
            Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            string? dobInput = Console.ReadLine();
            if (DateTime.TryParseExact(dobInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dob))
                break;
            else
                Console.WriteLine("Invalid Date. Use yyyy-MM-dd format.");
        }
        string updateSql = $@"UPDATE ""{tableName}"" SET date_of_birth=@date_of_birth WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("date_of_birth", dob);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Date of Birth updated successfully";
        return output;
    }

    //UpdatePhone
    public string UpdatePhone(string tableName, int id)
    {
        string? phone;
        while (true)
        {
            Console.Write("Enter Phone (11 digits): ");
            phone = Console.ReadLine();
            if (!string.IsNullOrEmpty(phone) && phone.Length == 11 && phone.All(char.IsDigit))
                break;
            else
                Console.WriteLine("Phone must be 11 numeric digits.");
        }
        string updateSql = $@"UPDATE ""{tableName}"" SET phone=@phone WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("phone", phone);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Phone updated successfully";
        return output;
    }
    //UpdateAddress
    public string UpdateAddress(string tableName, int id)
    {
        string? address;
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
        string updateSql = $@"UPDATE ""{tableName}"" SET address=@address WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("address", address);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Address updated successfully";
        return output;


    }

    //UpdateDepartment
    public string UpdateDepartment(string tableName, int id)
    {
        string? department;
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
        string updateSql = $@"UPDATE ""{tableName}"" SET department=@department WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("department", department);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Department updated successfully";
        return output;






    }

    //UpdateLevel
    public string UpdateLevel(string tableName, int id)
    {
        int parsedLevel;
        while (true)
        {
            Console.Write("Level: ");
            string? level = Console.ReadLine();
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
        string updateSql = $@"UPDATE ""{tableName}"" SET level=@level WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("level", parsedLevel);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Level updated successfully";
        return output;
    }

    //UpdateMatricNo
    public string UpdateMatricNo(string tableName, int id)
    {
        string? matricNo;
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

        string updateSql = $@"UPDATE ""{tableName}"" SET matric_no=@matric_no WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("matric_no", matricNo);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Matric No updated successfully";
        return output;
    }

    //UpdateGPA
    public string UpdateGPA(string tableName, int id)
    {
        string? gpa;
        decimal parsedGpa;
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

        string updateSql = $@"UPDATE ""{tableName}"" SET gpa=@gpa WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("gpa", parsedGpa);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "GPA updated successfully";
        return output;
    }

    //UpdateIsActive
    public string UpdateIsActive(string tableName, int id)
    {
        bool isActive;
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

        string updateSql = $@"UPDATE ""{tableName}"" SET is_active=@is_active WHERE Id = @Id";
        using var conn = Configuration.ConMethod();
        using var cmd = new NpgsqlCommand(updateSql, conn);
        cmd.Parameters.AddWithValue("is_active", isActive);
        cmd.Parameters.AddWithValue("Id", id);
        cmd.ExecuteNonQuery();
        string? output = "Is Active status updated successfully";
        return output;
    }
}