namespace dz8_Authenticator
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }

    public class AuthenticationService
    {
        private List<User> users;

        public AuthenticationService()
        {
            users = new List<User>
            {
                new User { Username = "user1", Password = "password1", Age = 25, Height = 170, Weight = 70 },
                new User { Username = "user2", Password = "password2", Age = 30, Height = 180, Weight = 80 }
            };
        }

        public bool Authenticate(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUser(string username)
        {
            return users.Find(u => u.Username == username);
        }

        public bool Register(string username, string password, int age, double height, double weight)
        {
            if (users.Exists(u => u.Username == username))
            {
                Console.WriteLine("User with this login already exists!");
                return false;
            }

            users.Add(new User { Username = username, Password = password, Age = age, Height = height, Weight = weight });
            Console.WriteLine("User successfully registered!");
            return true;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            AuthenticationService authService = new AuthenticationService();

            Console.WriteLine("Choose operation:");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Create acount");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter login:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                if (authService.Authenticate(username, password))
                {
                    User user = authService.GetUser(username);
                    Console.WriteLine($"Loin: {user.Username}");
                    Console.WriteLine($"Password: {user.Password}");
                    Console.WriteLine($"Age: {user.Age}");
                    Console.WriteLine($"Height: {user.Height}");
                    Console.WriteLine($"Weight: {user.Weight}");
                }
                else
                {
                    Console.WriteLine("Incorrect Login or Password!");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter login:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                Console.WriteLine("Enter age:");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Error: Incorrect format of age!");
                    return;
                }

                Console.WriteLine("Enter your height in cm:");
                if (!double.TryParse(Console.ReadLine(), out double height))
                {
                    Console.WriteLine("Error: Incorrect format of height!");
                    return;
                }

                Console.WriteLine("Enter weight in kg:");
                if (!double.TryParse(Console.ReadLine(), out double weight))
                {
                    Console.WriteLine("Error: Incorrect format weight!");
                    return;
                }

                authService.Register(username, password, age, height, weight);
            }
            else
            {
                Console.WriteLine("Incorrect choice!");
            }
        }
    }
}
