namespace CompanyEmployees.Extensions
{
    public static class Test
    {
        public static void Text(string name, int age)
        {
            Console.WriteLine($"My name is {name}");
            var currentYear = DateTime.Now.Year;
            var DOB = currentYear - age;
            Console.WriteLine($"Age is:\t{DOB}");
        }
    }
}
