using Microsoft.AspNetCore.Mvc;

namespace PrimeNumber
{
    public class PrimeNumberController : Controller
    {
        public static string Name = "PrimeNumber";
        public static string ActionIndex = "Index";
        public static string ActionCheckPrime = "CheckPrime";

        private static List<PrimeNumberModel> Results = new ();
        public IActionResult Index()
        {
            return View(Results);
        }

        [HttpPost]
        public IActionResult CheckPrime(int number)
        {
            bool isPrime = IsPrime(number);
            PrimeNumberModel model = new() { Number = number, IsPrime = isPrime };
            Results.Add(model);
            return RedirectToAction("Index");
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
